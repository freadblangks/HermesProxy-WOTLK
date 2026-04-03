namespace HermesProxy.World.Server.Packets;

public class SwapItem : ClientPacket
{
	public InvUpdate Inv;

	public byte SlotA;

	public byte ContainerSlotB;

	public byte SlotB;

	public byte ContainerSlotA;

	public SwapItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Inv = new InvUpdate(base._worldPacket);
		this.ContainerSlotB = base._worldPacket.ReadUInt8();
		this.ContainerSlotA = base._worldPacket.ReadUInt8();
		this.SlotB = base._worldPacket.ReadUInt8();
		this.SlotA = base._worldPacket.ReadUInt8();
	}
}
