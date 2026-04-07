namespace HermesProxy.World.Server.Packets;

internal class ChannelPassword : ClientPacket
{
	public string ChannelName;
	public string Password;

	public ChannelPassword(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint channelNameLength = base._worldPacket.ReadBits<uint>(7);
		uint passwordLength = base._worldPacket.ReadBits<uint>(7);
		this.ChannelName = base._worldPacket.ReadString(channelNameLength);
		this.Password = base._worldPacket.ReadString(passwordLength);
	}
}
