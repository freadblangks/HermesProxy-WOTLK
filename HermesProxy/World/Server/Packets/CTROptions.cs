namespace HermesProxy.World.Server.Packets;

public struct CTROptions
{
	public uint ContentTuningConditionMask;

	public int Unused901;

	public uint ExpansionLevelMask;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.ContentTuningConditionMask);
		data.WriteInt32(this.Unused901);
		data.WriteUInt32(this.ExpansionLevelMask);
	}
}
