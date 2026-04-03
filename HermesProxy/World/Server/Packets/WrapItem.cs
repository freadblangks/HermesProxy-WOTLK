namespace HermesProxy.World.Server.Packets;

public class WrapItem : ClientPacket
{
	public byte GiftBag;

	public byte GiftSlot;

	public byte ItemBag;

	public byte ItemSlot;

	public WrapItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		base._worldPacket.ReadUInt8();
		this.GiftBag = base._worldPacket.ReadUInt8();
		this.GiftSlot = base._worldPacket.ReadUInt8();
		this.ItemBag = base._worldPacket.ReadUInt8();
		this.ItemSlot = base._worldPacket.ReadUInt8();
	}
}
