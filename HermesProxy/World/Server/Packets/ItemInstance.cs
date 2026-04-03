namespace HermesProxy.World.Server.Packets;

public class ItemInstance
{
	public uint ItemID;

	public uint RandomPropertiesSeed;

	public uint RandomPropertiesID;

	public ItemBonuses ItemBonus;

	public ItemModList Modifications = new ItemModList();

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.ItemID);
		data.WriteUInt32(this.RandomPropertiesSeed);
		data.WriteUInt32(this.RandomPropertiesID);
		data.WriteBit(this.ItemBonus != null);
		data.FlushBits();
		this.Modifications.Write(data);
		if (this.ItemBonus != null)
		{
			this.ItemBonus.Write(data);
		}
	}

	public void Read(WorldPacket data)
	{
		this.ItemID = data.ReadUInt32();
		this.RandomPropertiesSeed = data.ReadUInt32();
		this.RandomPropertiesID = data.ReadUInt32();
		if (data.HasBit())
		{
			this.ItemBonus = new ItemBonuses();
		}
		data.ResetBitPos();
		this.Modifications.Read(data);
		if (this.ItemBonus != null)
		{
			this.ItemBonus.Read(data);
		}
	}
}
