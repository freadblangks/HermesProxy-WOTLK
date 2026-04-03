namespace HermesProxy.World.Server.Packets;

internal class SetPvP : ClientPacket
{
	public bool Enable;

	public SetPvP(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Enable = base._worldPacket.HasBit();
	}
}
