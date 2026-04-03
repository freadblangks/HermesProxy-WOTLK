namespace HermesProxy.World.Server.Packets;

internal class BattlemasterJoinArena : ClientPacket
{
	public WowGuid128 Guid;

	public byte TeamIndex;

	public byte Roles;

	public BattlemasterJoinArena(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Guid = base._worldPacket.ReadPackedGuid128();
		this.TeamIndex = base._worldPacket.ReadUInt8();
		this.Roles = base._worldPacket.ReadUInt8();
	}
}
