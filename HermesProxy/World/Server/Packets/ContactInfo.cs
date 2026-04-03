using System;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class ContactInfo
{
	public WowGuid128 Guid;

	public WowGuid128 WowAccountGuid;

	public uint VirtualRealmAddr;

	public uint NativeRealmAddr;

	public SocialFlag TypeFlags;

	public FriendStatus Status;

	public uint AreaID;

	public uint Level;

	public Class ClassID;

	public bool Mobile;

	public string Note = "";

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.Guid);
		data.WritePackedGuid128(this.WowAccountGuid);
		data.WriteUInt32(this.VirtualRealmAddr);
		data.WriteUInt32(this.NativeRealmAddr);
		data.WriteUInt32((uint)this.TypeFlags);
		data.WriteUInt8((byte)this.Status);
		data.WriteUInt32(this.AreaID);
		data.WriteUInt32(this.Level);
		data.WriteUInt32((uint)this.ClassID);
		data.WriteBits(this.Note.GetByteCount(), 10);
		data.WriteBit(this.Mobile);
		data.FlushBits();
		data.WriteString(this.Note);
	}
}
