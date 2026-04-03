namespace HermesProxy.World.Server.Packets;

public struct CriteriaProgressPkt
{
	public uint Id;

	public ulong Quantity;

	public WowGuid128 Player;

	public uint Flags;

	public long Date;

	public uint TimeFromStart;

	public uint TimeFromCreate;

	public ulong? RafAcceptanceID;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.Id);
		data.WriteUInt64(this.Quantity);
		data.WritePackedGuid128(this.Player);
		data.WritePackedTime(this.Date);
		data.WriteUInt32(this.TimeFromStart);
		data.WriteUInt32(this.TimeFromCreate);
		data.WriteBits(this.Flags, 4);
		data.WriteBit(this.RafAcceptanceID.HasValue);
		data.FlushBits();
		if (this.RafAcceptanceID.HasValue)
		{
			data.WriteUInt64(this.RafAcceptanceID.Value);
		}
	}
}
