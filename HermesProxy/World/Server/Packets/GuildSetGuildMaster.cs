namespace HermesProxy.World.Server.Packets;

public class GuildSetGuildMaster : ClientPacket
{
	public string NewMasterName;

	public GuildSetGuildMaster(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint nameLen = base._worldPacket.ReadBits<uint>(9);
		this.NewMasterName = base._worldPacket.ReadString(nameLen);
	}
}
