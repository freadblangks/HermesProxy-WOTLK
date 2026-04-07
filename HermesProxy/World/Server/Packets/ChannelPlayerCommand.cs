namespace HermesProxy.World.Server.Packets;

internal class ChannelPlayerCommand : ClientPacket
{
	public string ChannelName;
	public string Name;

	public ChannelPlayerCommand(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint channelNameLength = base._worldPacket.ReadBits<uint>(7);
		uint nameLength = base._worldPacket.ReadBits<uint>(9);
		this.ChannelName = base._worldPacket.ReadString(channelNameLength);
		this.Name = base._worldPacket.ReadString(nameLength);
	}
}
