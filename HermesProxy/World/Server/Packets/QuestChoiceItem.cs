namespace HermesProxy.World.Server.Packets;

public class QuestChoiceItem
{
	public byte LootItemType;

	public ItemInstance Item = new ItemInstance();

	public uint Quantity;

	public void Read(WorldPacket data)
	{
		data.ResetBitPos();
		this.LootItemType = data.ReadBits<byte>(2);
		this.Item.Read(data);
		this.Quantity = data.ReadUInt32();
	}

	public void Write(WorldPacket data)
	{
		data.WriteBits(this.LootItemType, 2);
		this.Item.Write(data);
		data.WriteUInt32(this.Quantity);
	}
}
