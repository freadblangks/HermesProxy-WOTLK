namespace HermesProxy.World.Server.Packets;

public class MailTakeItem : ClientPacket
{
	public WowGuid128 Mailbox;

	public uint MailID;

	public uint AttachID;

	public MailTakeItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Mailbox = base._worldPacket.ReadPackedGuid128();
		this.MailID = base._worldPacket.ReadUInt32();
		this.AttachID = base._worldPacket.ReadUInt32();
	}
}
