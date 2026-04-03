namespace HermesProxy.World.Server.Packets;

public class QueryCountdownTimerPkt : ClientPacket
{
	public QueryCountdownTimerPkt(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
	}
}
