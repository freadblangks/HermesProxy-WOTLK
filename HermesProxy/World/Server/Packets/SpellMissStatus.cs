using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public struct SpellMissStatus
{
	public SpellMissInfo Reason;

	public SpellMissInfo ReflectStatus;

	public SpellMissStatus(SpellMissInfo reason, SpellMissInfo reflectStatus)
	{
		this.Reason = reason;
		this.ReflectStatus = reflectStatus;
	}

	public void Write(WorldPacket data)
	{
		data.WriteBits((byte)this.Reason, 4);
		if (this.Reason == SpellMissInfo.Reflect)
		{
			data.WriteBits(this.ReflectStatus, 4);
		}
		data.FlushBits();
	}
}
