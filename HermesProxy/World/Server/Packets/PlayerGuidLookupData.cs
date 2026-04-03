using System;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class PlayerGuidLookupData
{
	public bool IsDeleted;

	public WowGuid128 AccountID;

	public WowGuid128 BnetAccountID;

	public WowGuid128 GuidActual;

	public string Name = "";

	public ulong GuildClubMemberID;

	public uint VirtualRealmAddress;

	public Race RaceID = Race.None;

	public Gender Sex = Gender.None;

	public Class ClassID = Class.None;

	public byte Level;

	public byte Unused915;

	public DeclinedName DeclinedNames = new DeclinedName();

	public void Write(WorldPacket data)
	{
		data.WriteBit(this.IsDeleted);
		data.WriteBits(this.Name.GetByteCount(), 6);
		for (byte i = 0; i < 5; i++)
		{
			data.WriteBits(this.DeclinedNames.name[i].GetByteCount(), 7);
		}
		data.FlushBits();
		for (byte i2 = 0; i2 < 5; i2++)
		{
			data.WriteString(this.DeclinedNames.name[i2]);
		}
		data.WritePackedGuid128(this.AccountID);
		data.WritePackedGuid128(this.BnetAccountID);
		data.WritePackedGuid128(this.GuidActual);
		data.WriteUInt64(this.GuildClubMemberID);
		data.WriteUInt32(this.VirtualRealmAddress);
		data.WriteUInt8((byte)this.RaceID);
		data.WriteUInt8((byte)this.Sex);
		data.WriteUInt8((byte)this.ClassID);
		data.WriteUInt8(this.Level);
		data.WriteUInt8(this.Unused915);
		data.WriteString(this.Name);
	}
}
