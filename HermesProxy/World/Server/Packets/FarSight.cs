namespace HermesProxy.World.Server.Packets;

internal class FarSight : ClientPacket
{
	public bool Enable;

	public FarSight(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Enable = base._worldPacket.HasBit();
	}
}
