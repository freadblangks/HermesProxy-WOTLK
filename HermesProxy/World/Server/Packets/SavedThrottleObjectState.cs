namespace HermesProxy.World.Server.Packets;

public struct SavedThrottleObjectState
{
	public uint MaxTries;

	public uint PerMilliseconds;

	public uint TryCount;

	public uint LastResetTimeBeforeNow;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.MaxTries);
		data.WriteUInt32(this.PerMilliseconds);
		data.WriteUInt32(this.TryCount);
		data.WriteUInt32(this.LastResetTimeBeforeNow);
	}
}
