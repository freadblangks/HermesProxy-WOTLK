namespace HermesProxy.World.Server.Packets;

public class ArenaTeamRosterRequest : ClientPacket
{
	public uint TeamIndex;

	public ArenaTeamRosterRequest(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.TeamIndex = base._worldPacket.ReadUInt32();
	}
}
