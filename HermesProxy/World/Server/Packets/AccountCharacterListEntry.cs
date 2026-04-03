using System;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class AccountCharacterListEntry
{
	public WowGuid128 AccountId;

	public uint RealmVirtualAddress;

	public string RealmName;

	public WowGuid128 CharacterGuid;

	public string Name;

	public Race Race;

	public Class Class;

	public Gender Sex;

	public byte Level;

	public ulong LastLoginUnixSec;

	public uint Unk;

	public void Write(WorldPacket packet)
	{
		packet.WritePackedGuid128(this.AccountId);
		packet.WritePackedGuid128(this.CharacterGuid);
		packet.WriteUInt32(this.RealmVirtualAddress);
		packet.WriteUInt8((byte)this.Race);
		packet.WriteUInt8((byte)this.Class);
		packet.WriteUInt8((byte)this.Sex);
		packet.WriteUInt8(this.Level);
		packet.WriteUInt64(this.LastLoginUnixSec);
		if (ModernVersion.AddedInClassicVersion(1, 14, 1, 2, 5, 3))
		{
			packet.WriteUInt32(this.Unk);
		}
		packet.ResetBitPos();
		packet.WriteBits(this.Name.GetByteCount(), 6);
		packet.WriteBits(this.RealmName.GetByteCount(), 9);
		packet.WriteString(this.Name);
		packet.WriteString(this.RealmName);
	}
}
