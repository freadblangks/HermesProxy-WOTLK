using System;

namespace HermesProxy.World.Server.Packets;

public class GuildRankData
{
	public byte RankID;

	public uint RankOrder;

	public uint Flags;

	public int WithdrawGoldLimit;

	public string RankName;

	public uint[] TabFlags = new uint[6];

	public uint[] TabWithdrawItemLimit = new uint[6];

	public void Write(WorldPacket data)
	{
		data.WriteUInt8(this.RankID);
		data.WriteUInt32(this.RankOrder);
		data.WriteUInt32(this.Flags);
		data.WriteInt32(this.WithdrawGoldLimit);
		for (byte i = 0; i < 6; i++)
		{
			data.WriteUInt32(this.TabFlags[i]);
			data.WriteUInt32(this.TabWithdrawItemLimit[i]);
		}
		data.WriteBits(this.RankName.GetByteCount(), 7);
		data.WriteString(this.RankName);
	}
}
