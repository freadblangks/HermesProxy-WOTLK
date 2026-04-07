using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class GMTicketSystemStatus : ServerPacket
{
	public int Status;

	public GMTicketSystemStatus()
		: base(Opcode.SMSG_GM_TICKET_SYSTEM_STATUS)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteInt32(this.Status);
	}
}
