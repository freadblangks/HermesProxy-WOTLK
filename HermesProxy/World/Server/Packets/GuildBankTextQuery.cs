namespace HermesProxy.World.Server.Packets;

public class GuildBankTextQuery : ClientPacket
{
	public int Tab;

	public GuildBankTextQuery(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Tab = base._worldPacket.ReadInt32();
	}
}
