namespace HermesProxy.World.Server.Packets;

public class LeaveChannel : ClientPacket
{
	public int ZoneChannelID;

	public string ChannelName;

	public LeaveChannel(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.ZoneChannelID = base._worldPacket.ReadInt32();
		this.ChannelName = base._worldPacket.ReadString(base._worldPacket.ReadBits<uint>(7));
	}
}
