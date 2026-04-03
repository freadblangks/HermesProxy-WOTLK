namespace HermesProxy.World.Server.Packets;

internal class BattlemasterJoinSkirmish : ClientPacket
{
	public WowGuid128 Guid;

	public byte Roles;

	public byte TeamSize;

	public bool AsGroup;

	public bool Requeue;

	public BattlemasterJoinSkirmish(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Guid = base._worldPacket.ReadPackedGuid128();
		this.Roles = base._worldPacket.ReadUInt8();
		this.TeamSize = base._worldPacket.ReadUInt8();
		this.AsGroup = base._worldPacket.HasBit();
		this.Requeue = base._worldPacket.HasBit();
	}
}
