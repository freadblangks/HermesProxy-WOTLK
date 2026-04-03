using System;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class GuildRosterMemberData
{
	public WowGuid128 Guid;

	public long WeeklyXP;

	public long TotalXP;

	public int RankID;

	public int AreaID;

	public int PersonalAchievementPoints = -1;

	public int GuildReputation = -1;

	public int GuildRepToCap;

	public float LastSave;

	public string Name;

	public uint VirtualRealmAddress;

	public string Note;

	public string OfficerNote;

	public byte Status;

	public byte Level;

	public Class ClassID;

	public Gender SexID;

	public bool Authenticated;

	public bool SorEligible;

	public GuildRosterProfessionData[] Profession = new GuildRosterProfessionData[2];

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.Guid);
		data.WriteInt32(this.RankID);
		data.WriteInt32(this.AreaID);
		data.WriteInt32(this.PersonalAchievementPoints);
		data.WriteInt32(this.GuildReputation);
		data.WriteFloat(this.LastSave);
		for (byte i = 0; i < 2; i++)
		{
			this.Profession[i].Write(data);
		}
		data.WriteUInt32(this.VirtualRealmAddress);
		data.WriteUInt8(this.Status);
		data.WriteUInt8(this.Level);
		data.WriteUInt8((byte)this.ClassID);
		data.WriteUInt8((byte)this.SexID);
		data.WriteBits(this.Name.GetByteCount(), 6);
		data.WriteBits(this.Note.GetByteCount(), 8);
		data.WriteBits(this.OfficerNote.GetByteCount(), 8);
		data.WriteBit(this.Authenticated);
		data.WriteBit(this.SorEligible);
		data.WriteString(this.Name);
		data.WriteString(this.Note);
		data.WriteString(this.OfficerNote);
	}
}
