using System;
using Framework.GameMath;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class GossipPOI : ServerPacket
{
	public uint Id = 1u;

	public uint Flags;

	public Vector3 Pos;

	public uint Icon;

	public uint Importance;

	public uint Unknown905;

	public string Name;

	public GossipPOI()
		: base(Opcode.SMSG_GOSSIP_POI)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteUInt32(this.Id);
		base._worldPacket.WriteFloat(this.Pos.X);
		base._worldPacket.WriteFloat(this.Pos.Y);
		base._worldPacket.WriteFloat(this.Pos.Z);
		base._worldPacket.WriteUInt32(this.Icon);
		base._worldPacket.WriteUInt32(this.Importance);
		base._worldPacket.WriteUInt32(this.Unknown905);
		base._worldPacket.WriteBits(this.Flags, 14);
		base._worldPacket.WriteBits(this.Name.GetByteCount(), 6);
		base._worldPacket.FlushBits();
		base._worldPacket.WriteString(this.Name);
	}
}
