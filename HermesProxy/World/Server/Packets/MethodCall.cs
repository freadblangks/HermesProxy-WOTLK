using Framework.IO;

namespace HermesProxy.World.Server.Packets;

public struct MethodCall
{
	public ulong Type;

	public ulong ObjectId;

	public uint Token;

	public uint GetServiceHash()
	{
		return (uint)(this.Type >> 32);
	}

	public uint GetMethodId()
	{
		return (uint)(this.Type & 0xFFFFFFFFu);
	}

	public void SetServiceHash(uint serviceHash)
	{
		this.Type = (this.Type & 0xFFFFFFFFu) | ((ulong)serviceHash << 32);
	}

	public void SetMethodId(uint methodId)
	{
		this.Type = (this.Type & 0xFFFFFFFF00000000uL) | methodId;
	}

	public void Read(ByteBuffer data)
	{
		this.Type = data.ReadUInt64();
		this.ObjectId = data.ReadUInt64();
		this.Token = data.ReadUInt32();
	}

	public void Write(ByteBuffer data)
	{
		data.WriteUInt64(this.Type);
		data.WriteUInt64(this.ObjectId);
		data.WriteUInt32(this.Token);
	}
}
