"""
Extract packet structure details for every handled opcode.
Appends structure info to oldopcodes.md and newopcodes.md
"""
import re, glob, os

# Parse enums
with open('HermesProxy/World/Enums/V3_3_5a_12340/Opcode.cs', 'r') as f:
    legacy_text = f.read()
with open('HermesProxy/World/Enums/V3_4_3_54261/Opcode.cs', 'r') as f:
    modern_text = f.read()

pattern = r'(\w+)\s*=\s*(\d+)u?'
legacy = dict(re.findall(pattern, legacy_text))
modern = dict(re.findall(pattern, modern_text))

# Find all handlers and extract their method bodies
handler_pattern = r'\[PacketHandler\(Opcode\.(\w+)'

def extract_method_after_handler(filepath, handler_line_num):
    """Extract method body starting from the handler attribute line."""
    with open(filepath, 'r') as f:
        lines = f.readlines()

    # Find method signature (could be on handler line or next few lines)
    method_sig = ""
    body_lines = []
    brace_count = 0
    started = False

    for i in range(handler_line_num - 1, min(handler_line_num + 300, len(lines))):
        line = lines[i]

        # Capture method signature
        if not started and re.search(r'(void|static)\s+\w+\s*\(', line):
            method_sig = line.strip()

        if '{' in line:
            started = True

        if started:
            brace_count += line.count('{') - line.count('}')
            body_lines.append(line.rstrip())
            if brace_count <= 0:
                break

    return method_sig, body_lines

def summarize_packet_fields(body_lines):
    """Extract field reads/writes from method body into a concise summary."""
    fields = []
    for line in body_lines:
        stripped = line.strip()

        # Skip empty, braces, comments
        if not stripped or stripped in ['{', '}'] or stripped.startswith('//'):
            continue

        # Read patterns
        read_matches = re.findall(r'\.Read(UInt32|Int32|UInt16|Int16|UInt8|Byte|UInt64|Int64|Float|Single|Double|Bool|String|CString|Bytes)\s*\(', stripped)
        for m in read_matches:
            # Try to find variable assignment
            assign = re.search(r'(?:var\s+)?(\w+)\s*=.*Read' + m, stripped)
            if assign:
                fields.append(f"Read{m} -> {assign.group(1)}")
            else:
                fields.append(f"Read{m}")

        # PackedGuid / Guid reads
        if 'ReadPackedGuid()' in stripped or 'ReadPackedGuid128()' in stripped:
            assign = re.search(r'(?:var\s+)?(\w+)\s*=.*ReadPackedGuid', stripped)
            fields.append(f"ReadPackedGuid -> {assign.group(1)}" if assign else "ReadPackedGuid")
        elif 'ReadGuid()' in stripped:
            assign = re.search(r'(?:var\s+)?(\w+)\s*=.*ReadGuid', stripped)
            fields.append(f"ReadGuid -> {assign.group(1)}" if assign else "ReadGuid")

        # Write patterns
        write_matches = re.findall(r'\.Write(UInt32|Int32|UInt16|Int16|UInt8|Byte|UInt64|Int64|Float|Single|Double|Bool|String|CString|Bytes|PackedGuid|Guid)\s*\(', stripped)
        for m in write_matches:
            # Try to find what's being written
            arg = re.search(r'Write' + m + r'\s*\(([^)]+)\)', stripped)
            if arg:
                fields.append(f"Write{m}({arg.group(1).strip()[:60]})")
            else:
                fields.append(f"Write{m}")

        # Vector3
        if 'ReadVector3()' in stripped:
            fields.append("ReadVector3")
        if 'WriteVector3(' in stripped:
            fields.append("WriteVector3")

        # New packet creation (sending to modern client)
        new_pkt = re.search(r'new\s+(\w+)\s*\(', stripped)
        if new_pkt and 'Packet' in new_pkt.group(1) or (new_pkt and new_pkt.group(1)[0].isupper()):
            # Check if it's a ServerPacket subclass
            pass

    return fields

# Collect all handler info
all_handler_info = {}  # opcode -> { files: [], fields: [], method_sig: "" }

for fpath in glob.glob('HermesProxy/World/**/*.cs', recursive=True):
    with open(fpath, 'r') as fh:
        file_lines = fh.readlines()

    for i, line in enumerate(file_lines, 1):
        m = re.search(handler_pattern, line)
        if m:
            opcode_name = m.group(1)
            method_sig, body = extract_method_after_handler(fpath, i)
            fields = summarize_packet_fields(body)

            if opcode_name not in all_handler_info:
                all_handler_info[opcode_name] = {
                    'locations': [],
                    'fields': [],
                    'method_sig': method_sig,
                    'body_preview': []
                }

            norm_path = fpath.replace(os.sep, '/')
            all_handler_info[opcode_name]['locations'].append(f"{norm_path}:{i}")
            if fields:
                all_handler_info[opcode_name]['fields'].extend(fields)
            # Store first 30 lines of body for reference
            if not all_handler_info[opcode_name]['body_preview']:
                all_handler_info[opcode_name]['body_preview'] = [l.strip() for l in body[:30]]

# Also extract ServerPacket Write() structures
server_packet_classes = {}
for fpath in glob.glob('HermesProxy/World/Server/Packets/*.cs', recursive=True):
    with open(fpath, 'r') as fh:
        content = fh.read()
        lines = content.split('\n')

    current_class = None
    for i, line in enumerate(lines):
        class_match = re.search(r'class\s+(\w+)\s*:\s*ServerPacket', line)
        if class_match:
            current_class = class_match.group(1)

        if current_class and 'override void Write()' in line:
            # Get the Write body
            body = []
            brace = 0
            started = False
            for j in range(i, min(i + 200, len(lines))):
                l = lines[j]
                if '{' in l:
                    started = True
                    brace += l.count('{') - l.count('}')
                    body.append(l.strip())
                elif started:
                    brace += l.count('{') - l.count('}')
                    body.append(l.strip())
                    if brace <= 0:
                        break

            fields = summarize_packet_fields(body)
            server_packet_classes[current_class] = {
                'file': fpath.replace(os.sep, '/'),
                'fields': fields,
                'body': [l for l in body if l.strip()][:25]
            }
            current_class = None  # Reset after capturing

print(f"Handlers with info: {len(all_handler_info)}")
print(f"Server packet classes: {len(server_packet_classes)}")

# ============ Write packet_structures.md ============
with open('packet_structures.md', 'w') as f:
    f.write("# Packet Structures Reference\n\n")
    f.write("This file documents the packet structure (fields read/written) for each handled opcode.\n\n")
    f.write(f"Total handled opcodes: {len(all_handler_info)}\n")
    f.write(f"Total ServerPacket classes: {len(server_packet_classes)}\n\n")

    f.write("## Table of Contents\n\n")
    f.write("1. [CMSG Handlers (Client->Legacy Server reads)](#cmsg-handlers)\n")
    f.write("2. [SMSG Handlers (Legacy Server->Modern Client writes)](#smsg-handlers)\n")
    f.write("3. [MSG Handlers (Bidirectional)](#msg-handlers)\n")
    f.write("4. [ServerPacket Write Structures (Modern Client format)](#serverpacket-structures)\n\n")

    # Group by type
    cmsg_ops = sorted([k for k in all_handler_info if k.startswith('CMSG_')])
    smsg_ops = sorted([k for k in all_handler_info if k.startswith('SMSG_')])
    msg_ops = sorted([k for k in all_handler_info if k.startswith('MSG_')])

    for section_name, section_id, ops in [
        ("CMSG Handlers", "cmsg-handlers", cmsg_ops),
        ("SMSG Handlers", "smsg-handlers", smsg_ops),
        ("MSG Handlers", "msg-handlers", msg_ops)
    ]:
        f.write(f"## {section_name}\n\n")
        for op in ops:
            info = all_handler_info[op]
            leg_val = legacy.get(op, "N/A")
            mod_val = modern.get(op, "N/A")

            f.write(f"### {op}\n\n")
            f.write(f"- Legacy value: {leg_val}" + (f" (0x{int(leg_val):04X})" if leg_val != "N/A" else "") + "\n")
            f.write(f"- Modern value: {mod_val}" + (f" (0x{int(mod_val):04X})" if mod_val != "N/A" else "") + "\n")
            f.write(f"- Handler: {', '.join(info['locations'])}\n")

            if info['fields']:
                f.write(f"- Fields:\n")
                for field in info['fields']:
                    f.write(f"  - `{field}`\n")

            if info['body_preview']:
                f.write(f"\n```csharp\n")
                for line in info['body_preview']:
                    f.write(f"{line}\n")
                f.write(f"```\n")

            f.write("\n---\n\n")

    # ServerPacket classes
    f.write("## ServerPacket Structures\n\n")
    f.write("These are the Write() methods that serialize data for the modern client.\n\n")
    for cls in sorted(server_packet_classes.keys()):
        info = server_packet_classes[cls]
        f.write(f"### {cls}\n\n")
        f.write(f"- File: {info['file']}\n")
        if info['fields']:
            f.write(f"- Fields:\n")
            for field in info['fields']:
                f.write(f"  - `{field}`\n")

        if info['body']:
            f.write(f"\n```csharp\n")
            for line in info['body']:
                f.write(f"{line}\n")
            f.write(f"```\n")

        f.write("\n---\n\n")

print("Generated packet_structures.md")
