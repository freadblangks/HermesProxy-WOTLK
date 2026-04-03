using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class AreaTriggerMessage : ServerPacket
{
	public uint AreaTriggerID = 0u;

	public AreaTriggerMessage()
		: base(Opcode.SMSG_AREA_TRIGGER_MESSAGE)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteUInt32(this.AreaTriggerID);
	}
}
