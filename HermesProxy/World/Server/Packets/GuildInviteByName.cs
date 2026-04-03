namespace HermesProxy.World.Server.Packets;

public class GuildInviteByName : ClientPacket
{
	public string Name;

	public uint ArenaTeamId;

	public GuildInviteByName(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint nameLen = base._worldPacket.ReadBits<uint>(9);
		bool isArena = base._worldPacket.HasBit();
		this.Name = base._worldPacket.ReadString(nameLen);
		if (isArena)
		{
			this.ArenaTeamId = base._worldPacket.ReadUInt32();
		}
	}
}
