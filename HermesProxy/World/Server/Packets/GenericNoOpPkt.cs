namespace HermesProxy.World.Server.Packets;

public class GenericNoOpPkt : ClientPacket
{
	public GenericNoOpPkt(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
	}
}
