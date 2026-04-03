namespace HermesProxy.World.Server.Packets;

public class RequestAccountData : ClientPacket
{
	public WowGuid128 PlayerGuid;

	public uint DataType;

	public RequestAccountData(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PlayerGuid = base._worldPacket.ReadPackedGuid128();
		if (ModernVersion.GetAccountDataCount() <= 8)
		{
			this.DataType = base._worldPacket.ReadBits<uint>(3);
		}
		else
		{
			this.DataType = base._worldPacket.ReadBits<uint>(4);
		}
	}
}
