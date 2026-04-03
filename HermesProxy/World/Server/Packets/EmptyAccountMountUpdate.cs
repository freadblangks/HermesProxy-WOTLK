using Framework.Constants;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class EmptyAccountMountUpdate : ServerPacket
{
	public EmptyAccountMountUpdate()
		: base(Opcode.SMSG_ACCOUNT_MOUNT_UPDATE, ConnectionType.Instance)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteBit(bit: true);
		base._worldPacket.WriteUInt32(0u);
		base._worldPacket.FlushBits();
	}
}
