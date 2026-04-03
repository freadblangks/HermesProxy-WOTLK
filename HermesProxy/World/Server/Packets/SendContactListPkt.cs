namespace HermesProxy.World.Server.Packets;

public class SendContactListPkt : ClientPacket
{
	public SendContactListPkt(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
	}
}
