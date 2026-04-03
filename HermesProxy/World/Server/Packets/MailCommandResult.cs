using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class MailCommandResult : ServerPacket
{
	public uint MailID;

	public MailActionType Command;

	public MailErrorType ErrorCode;

	public InventoryResult BagResult;

	public uint AttachID;

	public uint QtyInInventory;

	public MailCommandResult()
		: base(Opcode.SMSG_MAIL_COMMAND_RESULT)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteUInt32(this.MailID);
		base._worldPacket.WriteUInt32((uint)this.Command);
		base._worldPacket.WriteUInt32((uint)this.ErrorCode);
		base._worldPacket.WriteUInt32((uint)this.BagResult);
		base._worldPacket.WriteUInt32(this.AttachID);
		base._worldPacket.WriteUInt32(this.QtyInInventory);
	}
}
