using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class InspectItemData
{
	public WowGuid128 CreatorGUID = WowGuid128.Empty;

	public ItemInstance Item = new ItemInstance();

	public byte Index;

	public bool Usable;

	public List<InspectEnchantData> Enchants = new List<InspectEnchantData>();

	public List<ItemGemData> Gems = new List<ItemGemData>();

	public List<int> AzeritePowers = new List<int>();

	public List<AzeriteEssenceData> AzeriteEssences = new List<AzeriteEssenceData>();

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.CreatorGUID);
		data.WriteUInt8(this.Index);
		data.WriteInt32(this.AzeritePowers.Count);
		data.WriteInt32(this.AzeriteEssences.Count);
		foreach (int id in this.AzeritePowers)
		{
			data.WriteInt32(id);
		}
		this.Item.Write(data);
		data.WriteBit(this.Usable);
		data.WriteBits(this.Enchants.Count, 4);
		data.WriteBits(this.Gems.Count, 2);
		data.FlushBits();
		foreach (AzeriteEssenceData azeriteEssence in this.AzeriteEssences)
		{
			azeriteEssence.Write(data);
		}
		foreach (InspectEnchantData enchant in this.Enchants)
		{
			enchant.Write(data);
		}
		foreach (ItemGemData gem in this.Gems)
		{
			gem.Write(data);
		}
	}
}
