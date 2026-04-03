namespace HermesProxy.World.Server.Packets;

internal class LearnTalent : ClientPacket
{
	public uint TalentID;

	public ushort Rank;

	public LearnTalent(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.TalentID = base._worldPacket.ReadUInt32();
		this.Rank = base._worldPacket.ReadUInt16();
	}
}
