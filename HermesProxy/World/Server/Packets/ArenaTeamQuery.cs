namespace HermesProxy.World.Server.Packets;

public class ArenaTeamQuery : ClientPacket
{
	public uint TeamId;

	public ArenaTeamQuery(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.TeamId = base._worldPacket.ReadUInt32();
	}
}
