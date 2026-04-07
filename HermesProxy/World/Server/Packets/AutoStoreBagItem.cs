namespace HermesProxy.World.Server.Packets;

public class AutoStoreBagItem : ClientPacket
{
	public InvUpdate Inv;
	public byte ContainerSlotB;
	public byte ContainerSlotA;
	public byte SlotA;

	public AutoStoreBagItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Inv = new InvUpdate(base._worldPacket);
		this.ContainerSlotB = base._worldPacket.ReadUInt8();
		this.ContainerSlotA = base._worldPacket.ReadUInt8();
		this.SlotA = base._worldPacket.ReadUInt8();
	}
}
