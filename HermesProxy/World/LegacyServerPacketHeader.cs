using System;
using Framework.IO;
using Framework.Util;

namespace HermesProxy.World;

public class LegacyServerPacketHeader
{
	public const int StructSize = 4;

	public ushort Size;

	public ushort Opcode;

	public void Read(byte[] buffer)
	{
		this.Size = NetworkUtility.EndianConvert(BitConverter.ToUInt16(buffer, 0));
		this.Opcode = BitConverter.ToUInt16(buffer, 2);
	}

	public void Write(ByteBuffer byteBuffer)
	{
		byteBuffer.WriteUInt16(this.Size);
		byteBuffer.WriteUInt16(this.Opcode);
	}
}
