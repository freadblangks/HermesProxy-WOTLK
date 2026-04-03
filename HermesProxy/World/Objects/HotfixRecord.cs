using Framework.IO;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Objects;

public class HotfixRecord
{
	public uint HotfixId;

	public uint UniqueId;

	public DB2Hash TableHash;

	public uint RecordId;

	public HotfixStatus Status;

	public ByteBuffer HotfixContent = new ByteBuffer();

	public void WriteAvailable(WorldPacket data)
	{
		data.WriteUInt32(this.HotfixId);
		data.WriteUInt32((uint)this.TableHash);
	}

	public void WriteHotFixMessageContent(WorldPacket data)
	{
		data.WriteUInt32(this.HotfixId);
		data.WriteUInt32(this.UniqueId);
		data.WriteUInt32((uint)this.TableHash);
		data.WriteUInt32(this.RecordId);
		data.WriteUInt32(this.HotfixContent.GetSize());
		data.WriteBits((byte)this.Status, 3);
		data.FlushBits();
	}
}
