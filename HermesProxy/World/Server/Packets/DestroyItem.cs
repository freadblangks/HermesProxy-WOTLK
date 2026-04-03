namespace HermesProxy.World.Server.Packets;

public class DestroyItem : ClientPacket
{
	public uint Count;

	public byte SlotNum;

	public byte ContainerId;

	public DestroyItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Count = base._worldPacket.ReadUInt32();
		this.ContainerId = base._worldPacket.ReadUInt8();
		this.SlotNum = base._worldPacket.ReadUInt8();
	}
}
