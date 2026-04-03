namespace HermesProxy.World.Server.Packets;

public class GuildUpdateInfoText : ClientPacket
{
	public string InfoText;

	public GuildUpdateInfoText(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint textLen = base._worldPacket.ReadBits<uint>(11);
		this.InfoText = base._worldPacket.ReadString(textLen);
	}
}
