namespace HermesProxy.World.Server.Packets;

public class ChatMessageWhisper : ClientPacket
{
	public uint Language = 0u;

	public string Text;

	public string Target;

	public ChatMessageWhisper(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Language = base._worldPacket.ReadUInt32();
		uint targetLen = base._worldPacket.ReadBits<uint>(9);
		uint textLen = base._worldPacket.ReadBits<uint>(9);
		this.Target = base._worldPacket.ReadString(targetLen);
		this.Text = base._worldPacket.ReadString(textLen);
	}
}
