namespace HermesProxy.World.Server.Packets;

public class ChatMessageChannel : ClientPacket
{
	public uint Language;

	public WowGuid128 ChannelGUID;

	public string Text;

	public string Target;

	public ChatMessageChannel(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Language = base._worldPacket.ReadUInt32();
		this.ChannelGUID = base._worldPacket.ReadPackedGuid128();
		uint targetLen = base._worldPacket.ReadBits<uint>(9);
		uint textLen = base._worldPacket.ReadBits<uint>(9);
		this.Target = base._worldPacket.ReadString(targetLen);
		this.Text = base._worldPacket.ReadString(textLen);
	}
}
