import re, glob, os

# Parse all enums
with open('HermesProxy/World/Enums/V3_3_5a_12340/Opcode.cs', 'r') as f:
    legacy_text = f.read()
with open('HermesProxy/World/Enums/V3_4_3_54261/Opcode.cs', 'r') as f:
    modern_text = f.read()
with open('HermesProxy/World/Enums/Opcode.cs', 'r') as f:
    universal_text = f.read()

pattern = r'(\w+)\s*=\s*(\d+)u?'
legacy = dict(re.findall(pattern, legacy_text))
modern = dict(re.findall(pattern, modern_text))
universal = dict(re.findall(pattern, universal_text))

# Find all handlers across all files
handler_pattern = r'\[PacketHandler\(Opcode\.(\w+)'
all_handlers = {}
for fpath in glob.glob('HermesProxy/World/**/*.cs', recursive=True):
    with open(fpath, 'r') as fh:
        lines = fh.readlines()
    for i, line in enumerate(lines, 1):
        m = re.search(handler_pattern, line)
        if m:
            opcode_name = m.group(1)
            if opcode_name not in all_handlers:
                all_handlers[opcode_name] = []
            all_handlers[opcode_name].append((fpath.replace(os.sep, '/'), i))

# Extract packet structure info from handler methods
# For each handler, extract the method body to find read/write patterns
def extract_handler_body(filepath, handler_line):
    """Extract the method body after a PacketHandler attribute."""
    with open(filepath, 'r') as f:
        lines = f.readlines()

    # Find the method signature after the handler attribute
    start = handler_line  # 0-indexed would be handler_line - 1, but we want next line
    method_start = None
    brace_count = 0
    body_lines = []

    for i in range(handler_line, min(handler_line + 200, len(lines))):
        line = lines[i]
        if method_start is None:
            if '{' in line:
                method_start = i
                brace_count = line.count('{') - line.count('}')
                body_lines.append(line.rstrip())
        else:
            brace_count += line.count('{') - line.count('}')
            body_lines.append(line.rstrip())
            if brace_count <= 0:
                break

    return body_lines

def extract_packet_fields(body_lines):
    """Extract Read/Write field patterns from method body."""
    fields = []
    for line in body_lines:
        line = line.strip()
        # Look for Read patterns
        read_patterns = [
            (r'Read(UInt32|Int32|UInt16|Int16|UInt8|Byte|UInt64|Int64|Float|Single|Double|Bool|String|CString|PackedGuid|Guid|Vector3|Vector2)\(\)', 'read'),
            (r'ReadPackedGuid\(\)', 'PackedGuid'),
            (r'ReadGuid\(\)', 'Guid'),
            (r'\.(\w+)\s*=\s*packet\.Read(\w+)\(\)', 'assign_read'),
        ]
        # Look for Write patterns
        write_patterns = [
            (r'Write(UInt32|Int32|UInt16|Int16|UInt8|Byte|UInt64|Int64|Float|Single|Double|Bool|String|CString|PackedGuid|Guid|Vector3|Vector2)\(', 'write'),
            (r'WritePackedGuid\(', 'PackedGuid'),
            (r'WriteGuid\(', 'Guid'),
        ]

        for pat, kind in read_patterns:
            m = re.search(pat, line)
            if m:
                fields.append(line)
                break
        else:
            for pat, kind in write_patterns:
                m = re.search(pat, line)
                if m:
                    fields.append(line)
                    break

    return fields

# Now find packet class definitions in Server/Packets
packet_classes = {}  # class_name -> (file, fields_from_write)
for fpath in glob.glob('HermesProxy/World/Server/Packets/*.cs', recursive=True):
    with open(fpath, 'r') as fh:
        content = fh.read()
        lines = content.split('\n')

    # Find class definitions and their Write methods
    current_class = None
    for i, line in enumerate(lines):
        class_match = re.search(r'class\s+(\w+)\s*:', line)
        if class_match:
            current_class = class_match.group(1)

        if current_class and 'override void Write()' in line:
            # Extract the Write method body
            brace_count = 0
            method_lines = []
            started = False
            for j in range(i, min(i + 200, len(lines))):
                l = lines[j]
                if '{' in l:
                    started = True
                    brace_count += l.count('{') - l.count('}')
                    method_lines.append(l.strip())
                elif started:
                    brace_count += l.count('{') - l.count('}')
                    method_lines.append(l.strip())
                    if brace_count <= 0:
                        break

            packet_classes[current_class] = {
                'file': fpath.replace(os.sep, '/'),
                'write_body': method_lines
            }

print(f"Legacy opcodes: {len(legacy)}")
print(f"Modern opcodes: {len(modern)}")
print(f"Universal opcodes: {len(universal)}")
print(f"Handlers found: {len(all_handlers)}")
print(f"Packet classes found: {len(packet_classes)}")

# Categorize opcodes
both_sets = set(legacy.keys()) & set(modern.keys())
legacy_only = set(legacy.keys()) - set(modern.keys())
modern_only = set(modern.keys()) - set(legacy.keys())

# ============ GENERATE oldopcodes.md ============
with open('oldopcodes.md', 'w') as f:
    f.write("# Legacy Opcodes (3.3.5a Build 12340)\n\n")
    f.write(f"Total: {len(legacy)} opcodes\n\n")
    f.write("## Legend\n")
    f.write("- **HANDLED**: Has a packet handler in HermesProxy\n")
    f.write("- **UNHANDLED**: No handler exists\n")
    f.write("- **MODERN MATCH**: Also exists in 3.4.3 modern client\n")
    f.write("- **LEGACY ONLY**: Does NOT exist in modern client\n\n")

    # Sort by category then name
    cmsg = sorted([k for k in legacy if k.startswith('CMSG_')])
    smsg = sorted([k for k in legacy if k.startswith('SMSG_')])
    msg = sorted([k for k in legacy if k.startswith('MSG_')])
    other = sorted([k for k in legacy if not k.startswith('CMSG_') and not k.startswith('SMSG_') and not k.startswith('MSG_')])

    for category, opcodes in [("CMSG (Client -> Server)", cmsg), ("SMSG (Server -> Client)", smsg), ("MSG (Bidirectional)", msg), ("Other", other)]:
        f.write(f"## {category}\n\n")
        f.write(f"| Opcode | Value (Dec) | Value (Hex) | Handled | Modern Match | Handler Location |\n")
        f.write(f"|--------|-------------|-------------|---------|--------------|------------------|\n")

        for op in opcodes:
            val = int(legacy[op])
            hex_val = f"0x{val:04X}"
            handled = "YES" if op in all_handlers else "NO"
            has_modern = "YES" if op in modern else "NO"

            handler_loc = ""
            if op in all_handlers:
                locs = all_handlers[op]
                handler_loc = "; ".join([f"{fp}:{ln}" for fp, ln in locs[:2]])

            f.write(f"| {op} | {val} | {hex_val} | {handled} | {has_modern} | {handler_loc} |\n")

        f.write("\n")

    # Summary section
    f.write("## Summary\n\n")
    f.write(f"- Total legacy opcodes: {len(legacy)}\n")
    f.write(f"- CMSG: {len(cmsg)}\n")
    f.write(f"- SMSG: {len(smsg)}\n")
    f.write(f"- MSG: {len(msg)}\n")
    f.write(f"- Other: {len(other)}\n")
    f.write(f"- Handled: {len(set(legacy.keys()) & set(all_handlers.keys()))}\n")
    f.write(f"- Unhandled: {len(set(legacy.keys()) - set(all_handlers.keys()))}\n")
    f.write(f"- Also in modern: {len(both_sets)}\n")
    f.write(f"- Legacy only (no modern equivalent): {len(legacy_only)}\n")

print("Generated oldopcodes.md")

# ============ GENERATE newopcodes.md ============
with open('newopcodes.md', 'w') as f:
    f.write("# Modern Opcodes (3.4.3 Build 54261)\n\n")
    f.write(f"Total: {len(modern)} opcodes\n\n")
    f.write("## Legend\n")
    f.write("- **HANDLED**: Has a packet handler in HermesProxy\n")
    f.write("- **UNHANDLED**: No handler exists\n")
    f.write("- **LEGACY MATCH**: Also exists in 3.3.5a legacy server\n")
    f.write("- **MODERN ONLY**: Does NOT exist in legacy server\n")
    f.write("- **IN UNIVERSAL**: Exists in the universal opcode enum (required for translation)\n\n")

    cmsg = sorted([k for k in modern if k.startswith('CMSG_')])
    smsg = sorted([k for k in modern if k.startswith('SMSG_')])
    msg = sorted([k for k in modern if k.startswith('MSG_')])
    other = sorted([k for k in modern if not k.startswith('CMSG_') and not k.startswith('SMSG_') and not k.startswith('MSG_')])

    for category, opcodes in [("CMSG (Client -> Server)", cmsg), ("SMSG (Server -> Client)", smsg), ("MSG (Bidirectional)", msg), ("Other", other)]:
        f.write(f"## {category}\n\n")
        f.write(f"| Opcode | Value (Dec) | Value (Hex) | Handled | Legacy Match | In Universal | Handler Location |\n")
        f.write(f"|--------|-------------|-------------|---------|--------------|--------------|------------------|\n")

        for op in opcodes:
            val = int(modern[op])
            hex_val = f"0x{val:04X}"
            handled = "YES" if op in all_handlers else "NO"
            has_legacy = "YES" if op in legacy else "NO"
            in_universal = "YES" if op in universal else "**NO**"

            handler_loc = ""
            if op in all_handlers:
                locs = all_handlers[op]
                handler_loc = "; ".join([f"{fp}:{ln}" for fp, ln in locs[:2]])

            f.write(f"| {op} | {val} | {hex_val} | {handled} | {has_legacy} | {in_universal} | {handler_loc} |\n")

        f.write("\n")

    # Missing from universal - critical issues
    modern_not_universal = set(modern.keys()) - set(universal.keys())
    if modern_not_universal:
        f.write("## CRITICAL: Modern Opcodes Missing from Universal Enum\n\n")
        f.write("These opcodes exist in the modern client but have NO entry in the universal opcode enum.\n")
        f.write("They CANNOT be translated and will cause errors.\n\n")
        for op in sorted(modern_not_universal):
            val = int(modern[op])
            handled = "YES" if op in all_handlers else "NO"
            f.write(f"- **{op}** = {val} (0x{val:04X}) - Handled: {handled}\n")
        f.write("\n")

    # Summary
    f.write("## Summary\n\n")
    f.write(f"- Total modern opcodes: {len(modern)}\n")
    f.write(f"- CMSG: {len(cmsg)}\n")
    f.write(f"- SMSG: {len(smsg)}\n")
    f.write(f"- MSG: {len(msg)}\n")
    f.write(f"- Other: {len(other)}\n")
    f.write(f"- Handled: {len(set(modern.keys()) & set(all_handlers.keys()))}\n")
    f.write(f"- Unhandled: {len(set(modern.keys()) - set(all_handlers.keys()))}\n")
    f.write(f"- Also in legacy: {len(both_sets)}\n")
    f.write(f"- Modern only (no legacy equivalent): {len(modern_only)}\n")
    f.write(f"- Missing from universal enum: {len(modern_not_universal)}\n")

print("Generated newopcodes.md")

# ============ GENERATE opcode_comparison.md ============
with open('opcode_comparison.md', 'w') as f:
    f.write("# Opcode Comparison: Legacy (3.3.5a) vs Modern (3.4.3)\n\n")

    # Section 1: Opcodes in BOTH
    f.write("## 1. Opcodes Present in BOTH Legacy and Modern\n\n")
    f.write(f"Count: {len(both_sets)}\n\n")
    f.write("| Opcode | Legacy Value | Modern Value | Handled | Handler Location |\n")
    f.write("|--------|-------------|--------------|---------|------------------|\n")
    for op in sorted(both_sets):
        lval = int(legacy[op])
        mval = int(modern[op])
        handled = "YES" if op in all_handlers else "NO"
        handler_loc = ""
        if op in all_handlers:
            locs = all_handlers[op]
            handler_loc = "; ".join([f"{fp}:{ln}" for fp, ln in locs[:2]])
        f.write(f"| {op} | {lval} (0x{lval:04X}) | {mval} (0x{mval:04X}) | {handled} | {handler_loc} |\n")

    # Section 2: Legacy ONLY
    f.write(f"\n## 2. Opcodes ONLY in Legacy (3.3.5a) - Not in Modern\n\n")
    f.write(f"Count: {len(legacy_only)}\n\n")
    f.write("These opcodes exist in the old server but have no modern client equivalent.\n\n")
    f.write("| Opcode | Legacy Value | Handled |\n")
    f.write("|--------|-------------|----------|\n")
    for op in sorted(legacy_only):
        lval = int(legacy[op])
        handled = "YES" if op in all_handlers else "NO"
        f.write(f"| {op} | {lval} (0x{lval:04X}) | {handled} |\n")

    # Section 3: Modern ONLY
    f.write(f"\n## 3. Opcodes ONLY in Modern (3.4.3) - Not in Legacy\n\n")
    f.write(f"Count: {len(modern_only)}\n\n")
    f.write("These opcodes exist in the modern client but have no legacy server equivalent.\n\n")
    f.write("| Opcode | Modern Value | Handled | In Universal |\n")
    f.write("|--------|--------------|---------|---------------|\n")
    for op in sorted(modern_only):
        mval = int(modern[op])
        handled = "YES" if op in all_handlers else "NO"
        in_uni = "YES" if op in universal else "**NO**"
        f.write(f"| {op} | {mval} (0x{mval:04X}) | {handled} | {in_uni} |\n")

    # Section 4: Unhandled but in both - these are the ones we should focus on
    unhandled_both = sorted(both_sets - set(all_handlers.keys()))
    f.write(f"\n## 4. PRIORITY: Unhandled Opcodes Present in Both Versions\n\n")
    f.write(f"Count: {len(unhandled_both)}\n\n")
    f.write("These opcodes exist in both legacy and modern but have NO handler.\n")
    f.write("They are the most likely candidates for missing functionality.\n\n")
    f.write("| Opcode | Legacy Value | Modern Value |\n")
    f.write("|--------|-------------|---------------|\n")
    for op in unhandled_both:
        lval = int(legacy[op])
        mval = int(modern[op])
        f.write(f"| {op} | {lval} (0x{lval:04X}) | {mval} (0x{mval:04X}) |\n")

print("Generated opcode_comparison.md")
