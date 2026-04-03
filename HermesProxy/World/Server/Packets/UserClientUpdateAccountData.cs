namespace HermesProxy.World.Server.Packets;

public class UserClientUpdateAccountData : ClientPacket
{
	public WowGuid128 PlayerGuid;

	public long Time;

	public uint Size;

	public uint DataType;

	public byte[] CompressedData;

	public UserClientUpdateAccountData(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PlayerGuid = base._worldPacket.ReadPackedGuid128();
		this.Time = base._worldPacket.ReadInt64();
		this.Size = base._worldPacket.ReadUInt32();
		if (ModernVersion.GetAccountDataCount() <= 8)
		{
			this.DataType = base._worldPacket.ReadBits<uint>(3);
		}
		else
		{
			this.DataType = base._worldPacket.ReadBits<uint>(4);
		}
		uint compressedSize = base._worldPacket.ReadUInt32();
		if (compressedSize != 0)
		{
			this.CompressedData = base._worldPacket.ReadBytes(compressedSize);
		}
	}
}
