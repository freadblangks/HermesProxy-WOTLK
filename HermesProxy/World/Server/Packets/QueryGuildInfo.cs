namespace HermesProxy.World.Server.Packets;

public class QueryGuildInfo : ClientPacket
{
	public WowGuid128 GuildGuid;

	public WowGuid128 PlayerGuid;

	public QueryGuildInfo(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.GuildGuid = base._worldPacket.ReadPackedGuid128();
		this.PlayerGuid = base._worldPacket.ReadPackedGuid128();
	}
}
