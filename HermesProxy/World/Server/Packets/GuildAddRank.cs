namespace HermesProxy.World.Server.Packets;

public class GuildAddRank : ClientPacket
{
	public string Name;

	public int RankOrder;

	public GuildAddRank(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint nameLen = base._worldPacket.ReadBits<uint>(7);
		base._worldPacket.ResetBitPos();
		this.RankOrder = base._worldPacket.ReadInt32();
		this.Name = base._worldPacket.ReadString(nameLen);
	}
}
