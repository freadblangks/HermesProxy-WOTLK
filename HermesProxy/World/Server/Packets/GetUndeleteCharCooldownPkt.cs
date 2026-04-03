namespace HermesProxy.World.Server.Packets;

public class GetUndeleteCharCooldownPkt : ClientPacket
{
	public GetUndeleteCharCooldownPkt(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
	}
}
