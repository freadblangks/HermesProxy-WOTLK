using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class InstanceLock
{
	public uint MapID;

	public DifficultyModern DifficultyID;

	public ulong InstanceID;

	public int TimeRemaining;

	public uint CompletedMask = 1u;

	public bool Locked = true;

	public bool Extended;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.MapID);
		data.WriteUInt32((uint)this.DifficultyID);
		data.WriteUInt64(this.InstanceID);
		data.WriteInt32(this.TimeRemaining);
		data.WriteUInt32(this.CompletedMask);
		data.WriteBit(this.Locked);
		data.WriteBit(this.Extended);
		data.FlushBits();
	}
}
