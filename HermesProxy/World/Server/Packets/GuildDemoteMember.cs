namespace HermesProxy.World.Server.Packets;

public class GuildDemoteMember : ClientPacket
{
	public WowGuid128 Demotee;

	public GuildDemoteMember(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Demotee = base._worldPacket.ReadPackedGuid128();
	}
}
