using Framework.Constants;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class EmptyTalentData : ServerPacket
{
	public EmptyTalentData()
		: base(Opcode.SMSG_UPDATE_TALENT_DATA, ConnectionType.Instance)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteUInt32(0u);
		base._worldPacket.WriteUInt8(0);
		base._worldPacket.WriteUInt32(1u);
		base._worldPacket.WriteUInt8(0);
		base._worldPacket.WriteUInt32(0u);
		base._worldPacket.WriteUInt8(0);
		base._worldPacket.WriteUInt32(0u);
		base._worldPacket.WriteUInt8(0);
		base._worldPacket.WriteBit(bit: false);
		base._worldPacket.FlushBits();
	}
}
