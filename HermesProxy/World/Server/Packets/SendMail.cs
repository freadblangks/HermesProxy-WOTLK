using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class SendMail : ClientPacket
{
	public struct MailAttachment
	{
		public byte AttachPosition;

		public WowGuid128 ItemGUID;
	}

	public WowGuid128 Mailbox;

	public int StationeryID;

	public long SendMoney;

	public long Cod;

	public string Target;

	public string Subject;

	public string Body;

	public List<MailAttachment> Attachments = new List<MailAttachment>();

	public SendMail(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Mailbox = base._worldPacket.ReadPackedGuid128();
		this.StationeryID = base._worldPacket.ReadInt32();
		this.SendMoney = base._worldPacket.ReadInt64();
		this.Cod = base._worldPacket.ReadInt64();
		uint targetLength = base._worldPacket.ReadBits<uint>(9);
		uint subjectLength = base._worldPacket.ReadBits<uint>(9);
		uint bodyLength = base._worldPacket.ReadBits<uint>(11);
		uint count = base._worldPacket.ReadBits<uint>(5);
		this.Target = base._worldPacket.ReadString(targetLength);
		this.Subject = base._worldPacket.ReadString(subjectLength);
		this.Body = base._worldPacket.ReadString(bodyLength);
		for (int i = 0; i < count; i++)
		{
			MailAttachment att = new MailAttachment
			{
				AttachPosition = base._worldPacket.ReadUInt8(),
				ItemGUID = base._worldPacket.ReadPackedGuid128()
			};
			this.Attachments.Add(att);
		}
	}
}
