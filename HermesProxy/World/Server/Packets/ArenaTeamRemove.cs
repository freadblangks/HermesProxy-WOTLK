namespace HermesProxy.World.Server.Packets;

public class ArenaTeamRemove : ClientPacket
{
	public uint TeamId;

	public WowGuid128 PlayerGuid;

	public ArenaTeamRemove(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.TeamId = base._worldPacket.ReadUInt32();
		this.PlayerGuid = base._worldPacket.ReadPackedGuid128();
	}
}
