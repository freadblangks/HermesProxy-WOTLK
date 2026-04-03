namespace HermesProxy.World.Server.Packets;

public class SetTradeGold : ClientPacket
{
	public ulong Coinage;

	public SetTradeGold(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Coinage = base._worldPacket.ReadUInt64();
	}
}
