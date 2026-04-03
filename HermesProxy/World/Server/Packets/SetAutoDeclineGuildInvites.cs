namespace HermesProxy.World.Server.Packets;

public class SetAutoDeclineGuildInvites : ClientPacket
{
	public bool GuildInvitesShouldGetBlocked;

	public SetAutoDeclineGuildInvites(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.GuildInvitesShouldGetBlocked = base._worldPacket.ReadBool();
	}
}
