using System;
using Framework.Collections;

namespace HermesProxy.World.Server.Packets;

public class PetitionInfo
{
	public uint PetitionID;

	public WowGuid128 Petitioner;

	public string Title;

	public string BodyText;

	public uint MinSignatures;

	public uint MaxSignatures;

	public int DeadLine;

	public int IssueDate;

	public int AllowedGuildID;

	public int AllowedClasses;

	public int AllowedRaces;

	public short AllowedGender;

	public int AllowedMinLevel;

	public int AllowedMaxLevel;

	public int NumChoices;

	public int StaticType;

	public uint Muid = 0u;

	public StringArray Choicetext = new StringArray(10);

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.PetitionID);
		data.WritePackedGuid128(this.Petitioner);
		data.WriteUInt32(this.MinSignatures);
		data.WriteUInt32(this.MaxSignatures);
		data.WriteInt32(this.DeadLine);
		data.WriteInt32(this.IssueDate);
		data.WriteInt32(this.AllowedGuildID);
		data.WriteInt32(this.AllowedClasses);
		data.WriteInt32(this.AllowedRaces);
		data.WriteInt16(this.AllowedGender);
		data.WriteInt32(this.AllowedMinLevel);
		data.WriteInt32(this.AllowedMaxLevel);
		data.WriteInt32(this.NumChoices);
		data.WriteInt32(this.StaticType);
		data.WriteUInt32(this.Muid);
		data.WriteBits(this.Title.GetByteCount(), 7);
		data.WriteBits(this.BodyText.GetByteCount(), 12);
		for (byte i = 0; i < this.Choicetext.Length; i++)
		{
			data.WriteBits(this.Choicetext[i].GetByteCount(), 6);
		}
		data.FlushBits();
		for (byte i2 = 0; i2 < this.Choicetext.Length; i2++)
		{
			data.WriteString(this.Choicetext[i2]);
		}
		data.WriteString(this.Title);
		data.WriteString(this.BodyText);
	}
}
