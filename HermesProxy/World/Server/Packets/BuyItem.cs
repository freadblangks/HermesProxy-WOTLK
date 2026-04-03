using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class BuyItem : ClientPacket
{
	public WowGuid128 VendorGUID;

	public ItemInstance Item;

	public uint Muid;

	public uint Slot;

	public uint BagSlot;

	public ItemVendorType ItemType;

	public uint Quantity;

	public WowGuid128 ContainerGUID;

	public BuyItem(WorldPacket packet)
		: base(packet)
	{
		this.Item = new ItemInstance();
	}

	public override void Read()
	{
		this.VendorGUID = base._worldPacket.ReadPackedGuid128();
		this.ContainerGUID = base._worldPacket.ReadPackedGuid128();
		this.Quantity = base._worldPacket.ReadUInt32();
		if (ModernVersion.ExpansionVersion >= 3)
		{
			this.Muid = base._worldPacket.ReadUInt32();
			this.Slot = base._worldPacket.ReadUInt32();
			this.ItemType = (ItemVendorType)base._worldPacket.ReadInt32();
			this.Item.Read(base._worldPacket);
		}
		else
		{
			this.Slot = base._worldPacket.ReadUInt32();
			this.BagSlot = base._worldPacket.ReadUInt32();
			this.Item.Read(base._worldPacket);
			this.ItemType = (ItemVendorType)base._worldPacket.ReadBits<int>(3);
		}
	}
}
