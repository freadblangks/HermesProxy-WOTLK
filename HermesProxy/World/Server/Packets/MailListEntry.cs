using System;
using System.Collections.Generic;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class MailListEntry
{
	public int MailID;

	public MailType SenderType;

	public WowGuid128 SenderCharacter;

	public uint? AltSenderID;

	public ulong Cod;

	public int StationeryID;

	public ulong SentMoney;

	public uint Flags;

	public float DaysLeft;

	public int MailTemplateID;

	public string Subject = "";

	public string Body = "";

	public uint ItemTextId;

	public List<MailAttachedItem> Attachments = new List<MailAttachedItem>();

	public void Write(WorldPacket data)
	{
		data.WriteInt32(this.MailID);
		data.WriteUInt8((byte)this.SenderType);
		data.WriteUInt64(this.Cod);
		data.WriteInt32(this.StationeryID);
		data.WriteUInt64(this.SentMoney);
		data.WriteUInt32(this.Flags);
		data.WriteFloat(this.DaysLeft);
		data.WriteInt32(this.MailTemplateID);
		data.WriteInt32(this.Attachments.Count);
		data.WriteBit(this.SenderCharacter != null);
		data.WriteBit(this.AltSenderID.HasValue);
		data.WriteBits(this.Subject.GetByteCount(), 8);
		data.WriteBits(this.Body.GetByteCount(), 13);
		data.FlushBits();
		this.Attachments.ForEach(delegate(MailAttachedItem p)
		{
			p.Write(data);
		});
		if (this.SenderCharacter != null)
		{
			data.WritePackedGuid128(this.SenderCharacter);
		}
		if (this.AltSenderID.HasValue)
		{
			data.WriteUInt32(this.AltSenderID.Value);
		}
		data.WriteString(this.Subject);
		data.WriteString(this.Body);
	}
}
