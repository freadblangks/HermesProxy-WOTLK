namespace HermesProxy.World.Server.Packets;

public class GuildSetRankPermissions : ClientPacket
{
	public uint RankID;

	public uint RankOrder;

	public int WithdrawGoldLimit;

	public uint Flags;

	public uint OldFlags;

	public uint[] TabFlags = new uint[6];

	public uint[] TabWithdrawItemLimit = new uint[6];

	public string RankName;

	public GuildSetRankPermissions(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.RankID = base._worldPacket.ReadUInt32();
		this.RankOrder = base._worldPacket.ReadUInt32();
		this.Flags = base._worldPacket.ReadUInt32();
		this.WithdrawGoldLimit = base._worldPacket.ReadInt32();
		for (byte i = 0; i < 6; i++)
		{
			this.TabFlags[i] = base._worldPacket.ReadUInt32();
			this.TabWithdrawItemLimit[i] = base._worldPacket.ReadUInt32();
		}
		this.OldFlags = base._worldPacket.ReadUInt32();
		base._worldPacket.ResetBitPos();
		uint rankNameLen = base._worldPacket.ReadBits<uint>(7);
		this.RankName = base._worldPacket.ReadString(rankNameLen);
	}
}
