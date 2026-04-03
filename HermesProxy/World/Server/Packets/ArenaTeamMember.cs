using System;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal struct ArenaTeamMember
{
	public WowGuid128 MemberGUID;

	public bool Online;

	public int Captain;

	public byte Level;

	public Class ClassId;

	public uint WeekGamesPlayed;

	public uint WeekGamesWon;

	public uint SeasonGamesPlayed;

	public uint SeasonGamesWon;

	public uint PersonalRating;

	public string Name;

	public float? dword60;

	public float? dword68;

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.MemberGUID);
		data.WriteBool(this.Online);
		data.WriteInt32(this.Captain);
		data.WriteUInt8(this.Level);
		data.WriteUInt8((byte)this.ClassId);
		data.WriteUInt32(this.WeekGamesPlayed);
		data.WriteUInt32(this.WeekGamesWon);
		data.WriteUInt32(this.SeasonGamesPlayed);
		data.WriteUInt32(this.SeasonGamesWon);
		data.WriteUInt32(this.PersonalRating);
		data.WriteBits(this.Name.GetByteCount(), 6);
		data.WriteBit(this.dword60.HasValue);
		data.WriteBit(this.dword68.HasValue);
		data.FlushBits();
		data.WriteString(this.Name);
		if (this.dword60.HasValue)
		{
			data.WriteFloat(this.dword60.Value);
		}
		if (this.dword68.HasValue)
		{
			data.WriteFloat(this.dword68.Value);
		}
	}
}
