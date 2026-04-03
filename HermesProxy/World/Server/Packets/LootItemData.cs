using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class LootItemData
{
	public byte Type;

	public LootSlotTypeModern UIType;

	public uint Quantity;

	public byte LootItemType;

	public byte LootListID;

	public bool CanTradeToTapList;

	public ItemInstance Loot = new ItemInstance();

	public void Write(WorldPacket data)
	{
		data.WriteBits(this.Type, 2);
		data.WriteBits(this.UIType, 3);
		data.WriteBit(this.CanTradeToTapList);
		data.FlushBits();
		this.Loot.Write(data);
		data.WriteUInt32(this.Quantity);
		data.WriteUInt8(this.LootItemType);
		data.WriteUInt8(this.LootListID);
	}
}
