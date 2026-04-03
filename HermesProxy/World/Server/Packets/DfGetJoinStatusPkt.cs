namespace HermesProxy.World.Server.Packets;

public class DfGetJoinStatusPkt : ClientPacket
{
	public DfGetJoinStatusPkt(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
	}
}
