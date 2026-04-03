namespace HermesProxy.World.Server.Packets;

public class PartyLFGInfo
{
	public byte MyFlags;

	public uint Slot;

	public byte BootCount;

	public uint MyRandomSlot;

	public bool Aborted;

	public byte MyPartialClear;

	public float MyGearDiff;

	public byte MyStrangerCount;

	public byte MyKickVoteCount;

	public bool MyFirstReward;

	public void Write(WorldPacket data)
	{
		data.WriteUInt8(this.MyFlags);
		data.WriteUInt32(this.Slot);
		data.WriteUInt32(this.MyRandomSlot);
		data.WriteUInt8(this.MyPartialClear);
		data.WriteFloat(this.MyGearDiff);
		data.WriteUInt8(this.MyStrangerCount);
		data.WriteUInt8(this.MyKickVoteCount);
		data.WriteUInt8(this.BootCount);
		data.WriteBit(this.Aborted);
		data.WriteBit(this.MyFirstReward);
		data.FlushBits();
	}
}
