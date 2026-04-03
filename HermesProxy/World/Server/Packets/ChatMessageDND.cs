namespace HermesProxy.World.Server.Packets;

public class ChatMessageDND : ClientPacket
{
	public string Text;

	public ChatMessageDND(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint len = base._worldPacket.ReadBits<uint>(9);
		this.Text = base._worldPacket.ReadString(len);
	}
}
