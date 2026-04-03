namespace HermesProxy.World.Server.Packets;

public class GuildBankSetTabText : ClientPacket
{
	public int Tab;

	public string TabText;

	public GuildBankSetTabText(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Tab = base._worldPacket.ReadInt32();
		this.TabText = base._worldPacket.ReadString(base._worldPacket.ReadBits<uint>(14));
	}
}
