namespace HermesProxy.World.Server.Packets;

public class GuildUpdateMotdText : ClientPacket
{
	public string MotdText;

	public GuildUpdateMotdText(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint textLen = base._worldPacket.ReadBits<uint>(11);
		this.MotdText = base._worldPacket.ReadString(textLen);
	}
}
