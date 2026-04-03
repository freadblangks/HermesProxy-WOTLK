using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class MailAttachedItem
{
	public byte Position;

	public int AttachID;

	public ItemInstance Item = new ItemInstance();

	public uint Count;

	public int Charges;

	public uint MaxDurability;

	public uint Durability;

	public bool Unlocked;

	public List<ItemEnchantData> Enchants = new List<ItemEnchantData>();

	public List<ItemGemData> Gems = new List<ItemGemData>();

	public void Write(WorldPacket data)
	{
		data.WriteUInt8(this.Position);
		data.WriteInt32(this.AttachID);
		data.WriteUInt32(this.Count);
		data.WriteInt32(this.Charges);
		data.WriteUInt32(this.MaxDurability);
		data.WriteUInt32(this.Durability);
		this.Item.Write(data);
		data.WriteBits(this.Enchants.Count, 4);
		data.WriteBits(this.Gems.Count, 2);
		data.WriteBit(this.Unlocked);
		data.FlushBits();
		foreach (ItemGemData gem in this.Gems)
		{
			gem.Write(data);
		}
		foreach (ItemEnchantData en in this.Enchants)
		{
			en.Write(data);
		}
	}
}
