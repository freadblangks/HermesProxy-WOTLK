namespace HermesProxy.World.Server.Packets;

public class Inspect : ClientPacket
{
	public WowGuid128 Target;

	public Inspect(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Target = base._worldPacket.ReadPackedGuid128();
	}
}
