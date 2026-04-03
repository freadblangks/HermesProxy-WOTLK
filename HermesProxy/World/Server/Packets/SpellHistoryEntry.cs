namespace HermesProxy.World.Server.Packets;

public class SpellHistoryEntry
{
	public uint SpellID;

	public uint ItemID;

	public uint Category;

	public int RecoveryTime;

	public int CategoryRecoveryTime;

	public float ModRate = 1f;

	public bool OnHold;

	private uint? unused622_1;

	private uint? unused622_2;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.SpellID);
		data.WriteUInt32(this.ItemID);
		data.WriteUInt32(this.Category);
		data.WriteInt32(this.RecoveryTime);
		data.WriteInt32(this.CategoryRecoveryTime);
		data.WriteFloat(this.ModRate);
		data.WriteBit(this.unused622_1.HasValue);
		data.WriteBit(this.unused622_2.HasValue);
		data.WriteBit(this.OnHold);
		data.FlushBits();
		if (this.unused622_1.HasValue)
		{
			data.WriteUInt32(this.unused622_1.Value);
		}
		if (this.unused622_2.HasValue)
		{
			data.WriteUInt32(this.unused622_2.Value);
		}
	}
}
