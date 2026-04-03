namespace HermesProxy.World.Server.Packets;

public struct AzeriteEssenceData
{
	public uint Index;

	public uint AzeriteEssenceID;

	public uint Rank;

	public bool SlotUnlocked;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.Index);
		data.WriteUInt32(this.AzeriteEssenceID);
		data.WriteUInt32(this.Rank);
		data.WriteBit(this.SlotUnlocked);
		data.FlushBits();
	}
}
