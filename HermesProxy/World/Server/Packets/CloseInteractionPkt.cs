namespace HermesProxy.World.Server.Packets;

public class CloseInteractionPkt : ClientPacket
{
	public CloseInteractionPkt(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
	}
}
