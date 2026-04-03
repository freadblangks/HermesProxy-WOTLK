namespace HermesProxy.World.Server.Packets;

public class VendorItem
{
	public int Slot;

	public int Type = 1;

	public ItemInstance Item = new ItemInstance();

	public int Quantity = -1;

	public ulong Price;

	public int Durability;

	public uint StackCount;

	public int ExtendedCostID;

	public int PlayerConditionFailed;

	public bool DoNotFilterOnVendor;

	public bool Refundable;

	public uint MuID;

	public void Write(WorldPacket data)
	{
		if (ModernVersion.ExpansionVersion >= 3)
		{
			this.WriteWotLK(data);
			return;
		}
		data.WriteInt32(this.Slot);
		data.WriteInt32(this.Type);
		data.WriteInt32(this.Quantity);
		data.WriteUInt64(this.Price);
		data.WriteInt32(this.Durability);
		data.WriteUInt32(this.StackCount);
		data.WriteInt32(this.ExtendedCostID);
		data.WriteInt32(this.PlayerConditionFailed);
		this.Item.Write(data);
		data.WriteBit(this.DoNotFilterOnVendor);
		data.WriteBit(this.Refundable);
		data.FlushBits();
	}

	private void WriteWotLK(WorldPacket data)
	{
		data.WriteUInt64(this.Price);
		data.WriteUInt32(this.MuID);
		data.WriteInt32(this.Type);
		data.WriteInt32(this.Durability);
		data.WriteInt32((int)this.StackCount);
		data.WriteInt32(this.Quantity);
		data.WriteInt32(this.ExtendedCostID);
		data.WriteInt32(this.PlayerConditionFailed);
		data.WriteBit(bit: false);
		data.WriteBit(this.DoNotFilterOnVendor);
		data.WriteBit(this.Refundable);
		data.FlushBits();
		this.Item.Write(data);
	}
}
