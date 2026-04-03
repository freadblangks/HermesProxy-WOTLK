namespace HermesProxy.World.Server.Packets;

internal class ChannelCommand : ClientPacket
{
	public string ChannelName;

	public ChannelCommand(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.ChannelName = base._worldPacket.ReadString(base._worldPacket.ReadBits<uint>(7));
	}
}
