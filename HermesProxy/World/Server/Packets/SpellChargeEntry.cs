namespace HermesProxy.World.Server.Packets;

public class SpellChargeEntry
{
	public uint Category;

	public uint NextRecoveryTime;

	public float ChargeModRate = 1f;

	public byte ConsumedCharges;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.Category);
		data.WriteUInt32(this.NextRecoveryTime);
		data.WriteFloat(this.ChargeModRate);
		data.WriteUInt8(this.ConsumedCharges);
	}
}
