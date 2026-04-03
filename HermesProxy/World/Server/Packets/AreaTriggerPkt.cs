namespace HermesProxy.World.Server.Packets;

internal class AreaTriggerPkt : ClientPacket
{
	public uint AreaTriggerID;

	public bool Entered;

	public bool FromClient;

	public AreaTriggerPkt(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.AreaTriggerID = base._worldPacket.ReadUInt32();
		this.Entered = base._worldPacket.HasBit();
		this.FromClient = base._worldPacket.HasBit();
	}
}
