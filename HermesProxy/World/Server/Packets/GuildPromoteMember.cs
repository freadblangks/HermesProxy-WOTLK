namespace HermesProxy.World.Server.Packets;

public class GuildPromoteMember : ClientPacket
{
	public WowGuid128 Promotee;

	public GuildPromoteMember(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Promotee = base._worldPacket.ReadPackedGuid128();
	}
}
