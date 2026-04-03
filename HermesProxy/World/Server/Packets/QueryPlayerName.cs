namespace HermesProxy.World.Server.Packets;

public class QueryPlayerName : ClientPacket
{
	public WowGuid128 Player;

	public QueryPlayerName(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Player = base._worldPacket.ReadPackedGuid128();
	}
}
