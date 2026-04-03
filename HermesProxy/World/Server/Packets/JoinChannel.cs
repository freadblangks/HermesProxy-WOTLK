namespace HermesProxy.World.Server.Packets;

public class JoinChannel : ClientPacket
{
	public string Password;

	public string ChannelName;

	public int ChatChannelId;

	public JoinChannel(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.ChatChannelId = base._worldPacket.ReadInt32();
		uint channelLength = base._worldPacket.ReadBits<uint>(7);
		uint passwordLength = base._worldPacket.ReadBits<uint>(7);
		base._worldPacket.ResetBitPos();
		this.ChannelName = base._worldPacket.ReadString(channelLength);
		this.Password = base._worldPacket.ReadString(passwordLength);
	}
}
