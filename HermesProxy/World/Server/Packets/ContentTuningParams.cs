namespace HermesProxy.World.Server.Packets;

internal class ContentTuningParams
{
	public enum ContentTuningType
	{
		CreatureToPlayerDamage = 1,
		PlayerToCreatureDamage = 2,
		CreatureToCreatureDamage = 4,
		PlayerToSandboxScaling = 7,
		PlayerToPlayerExpectedStat = 8
	}

	public enum ContentTuningFlags
	{
		NoLevelScaling = 1,
		NoItemLevelScaling = 2
	}

	public ContentTuningType TuningType;

	public short PlayerLevelDelta;

	public float PlayerItemLevel;

	public float TargetItemLevel = 0f;

	public ushort ScalingHealthItemLevelCurveID;

	public byte TargetLevel;

	public byte Expansion;

	public byte TargetMinScalingLevel;

	public byte TargetMaxScalingLevel;

	public sbyte TargetScalingLevelDelta;

	public ContentTuningFlags Flags = (ContentTuningFlags)3;

	public void Write(WorldPacket data)
	{
		data.WriteFloat(this.PlayerItemLevel);
		data.WriteFloat(this.TargetItemLevel);
		data.WriteInt16(this.PlayerLevelDelta);
		data.WriteUInt16(this.ScalingHealthItemLevelCurveID);
		data.WriteUInt8(this.TargetLevel);
		data.WriteUInt8(this.Expansion);
		data.WriteUInt8(this.TargetMinScalingLevel);
		data.WriteUInt8(this.TargetMaxScalingLevel);
		data.WriteInt8(this.TargetScalingLevelDelta);
		data.WriteUInt32((uint)this.Flags);
		data.WriteBits(this.TuningType, 4);
		data.FlushBits();
	}
}
