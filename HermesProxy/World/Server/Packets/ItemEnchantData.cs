namespace HermesProxy.World.Server.Packets;

public class ItemEnchantData
{
	public uint ID;

	public uint Expiration;

	public int Charges;

	public byte Slot;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.ID);
		data.WriteUInt32(this.Expiration);
		data.WriteInt32(this.Charges);
		data.WriteUInt8(this.Slot);
	}
}
