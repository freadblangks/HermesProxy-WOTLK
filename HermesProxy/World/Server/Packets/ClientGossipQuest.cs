using System;

namespace HermesProxy.World.Server.Packets;

public class ClientGossipQuest
{
	public uint QuestID;

	public uint ContentTuningID;

	public int QuestType;

	public int QuestLevel;

	public int QuestMaxLevel = 255;

	public bool Repeatable;

	public string QuestTitle;

	public uint QuestFlags = 8u;

	public uint QuestFlagsEx;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.QuestID);
		data.WriteUInt32(this.ContentTuningID);
		data.WriteInt32(this.QuestType);
		data.WriteInt32(this.QuestLevel);
		data.WriteInt32(this.QuestMaxLevel);
		data.WriteUInt32(this.QuestFlags);
		data.WriteUInt32(this.QuestFlagsEx);
		data.WriteBit(this.Repeatable);
		data.WriteBits(this.QuestTitle.GetByteCount(), 9);
		data.FlushBits();
		data.WriteString(this.QuestTitle);
	}

	public void WriteWotLK(WorldPacket data)
	{
		data.WriteInt32((int)this.QuestID);
		data.WriteInt32((int)this.ContentTuningID);
		data.WriteInt32(this.QuestType);
		data.WriteInt32(this.QuestLevel);
		data.WriteInt32(this.QuestMaxLevel);
		data.WriteInt32((int)this.QuestFlags);
		data.WriteInt32((int)this.QuestFlagsEx);
		data.WriteBit(this.Repeatable);
		data.WriteBit(bit: false);
		data.WriteBits(this.QuestTitle.GetByteCount(), 9);
		data.FlushBits();
		data.WriteString(this.QuestTitle);
	}
}
