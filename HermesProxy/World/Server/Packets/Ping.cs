namespace HermesProxy.World.Server.Packets;

internal class Ping : ClientPacket
{
	public uint Serial;

	public uint Latency;

	public Ping(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Serial = base._worldPacket.ReadUInt32();
		this.Latency = base._worldPacket.ReadUInt32();
	}
}
