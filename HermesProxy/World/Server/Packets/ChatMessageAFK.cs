namespace HermesProxy.World.Server.Packets;

public class ChatMessageAFK : ClientPacket
{
	public string Text;

	public ChatMessageAFK(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint len = base._worldPacket.ReadBits<uint>(9);
		this.Text = base._worldPacket.ReadString(len);
	}
}
