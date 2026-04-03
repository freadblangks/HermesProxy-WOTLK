namespace HermesProxy.World.Server.Packets;

public class QueuedMessagesEndPkt : ClientPacket
{
	public QueuedMessagesEndPkt(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
	}
}
