using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class CriteriaDeleted : ServerPacket
{
	public uint CriteriaID;

	public CriteriaDeleted()
		: base(Opcode.SMSG_CRITERIA_DELETED)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteUInt32(this.CriteriaID);
	}
}
