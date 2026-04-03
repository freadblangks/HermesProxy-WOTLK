namespace HermesProxy.World.Server.Packets;

public class RepopRequest : ClientPacket
{
	public bool CheckInstance;

	public RepopRequest(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.CheckInstance = base._worldPacket.HasBit();
	}
}
