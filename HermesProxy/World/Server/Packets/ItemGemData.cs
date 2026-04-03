namespace HermesProxy.World.Server.Packets;

public class ItemGemData
{
	public byte Slot;

	public ItemInstance Item = new ItemInstance();

	public void Write(WorldPacket data)
	{
		data.WriteUInt8(this.Slot);
		this.Item.Write(data);
	}

	public void Read(WorldPacket data)
	{
		this.Slot = data.ReadUInt8();
		this.Item.Read(data);
	}
}
