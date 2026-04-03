namespace HermesProxy.World.Server.Packets;

public class GuildGetRanks : ClientPacket
{
	public WowGuid128 GuildGUID;

	public GuildGetRanks(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.GuildGUID = base._worldPacket.ReadPackedGuid128();
	}
}
