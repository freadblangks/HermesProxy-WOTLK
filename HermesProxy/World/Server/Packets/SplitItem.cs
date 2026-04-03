namespace HermesProxy.World.Server.Packets;

public class SplitItem : ClientPacket
{
	public byte ToSlot;

	public byte ToPackSlot;

	public byte FromPackSlot;

	public int Quantity;

	public InvUpdate Inv;

	public byte FromSlot;

	public SplitItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Inv = new InvUpdate(base._worldPacket);
		this.FromPackSlot = base._worldPacket.ReadUInt8();
		this.FromSlot = base._worldPacket.ReadUInt8();
		this.ToPackSlot = base._worldPacket.ReadUInt8();
		this.ToSlot = base._worldPacket.ReadUInt8();
		this.Quantity = base._worldPacket.ReadInt32();
	}
}
