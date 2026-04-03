namespace HermesProxy.World.Server.Packets;

public class RequestForcedReactionsPkt : ClientPacket
{
	public RequestForcedReactionsPkt(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
	}
}
