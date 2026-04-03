namespace HermesProxy.World.Server.Packets;

public class CalendarGetNumPendingPkt : ClientPacket
{
	public CalendarGetNumPendingPkt(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
	}
}
