namespace HermesProxy.World.Server.Packets;

public class InitActiveMoverComplete : ClientPacket
{
	public uint Ticks;

	public InitActiveMoverComplete(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Ticks = base._worldPacket.ReadUInt32();
	}
}
