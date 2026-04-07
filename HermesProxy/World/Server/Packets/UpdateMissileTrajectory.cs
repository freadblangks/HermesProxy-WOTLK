using HermesProxy.World.Objects;

namespace HermesProxy.World.Server.Packets;

public class UpdateMissileTrajectory : ClientPacket
{
	public WowGuid128 Guid;
	public WowGuid128 CastID;
	public ushort MoveMsgID;
	public int SpellID;
	public float Pitch;
	public float Speed;
	public float FirePosX;
	public float FirePosY;
	public float FirePosZ;
	public float ImpactPosX;
	public float ImpactPosY;
	public float ImpactPosZ;

	public UpdateMissileTrajectory(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Guid = base._worldPacket.ReadPackedGuid128();
		this.CastID = base._worldPacket.ReadPackedGuid128();
		this.MoveMsgID = base._worldPacket.ReadUInt16();
		this.SpellID = base._worldPacket.ReadInt32();
		this.Pitch = base._worldPacket.ReadFloat();
		this.Speed = base._worldPacket.ReadFloat();
		this.FirePosX = base._worldPacket.ReadFloat();
		this.FirePosY = base._worldPacket.ReadFloat();
		this.FirePosZ = base._worldPacket.ReadFloat();
		this.ImpactPosX = base._worldPacket.ReadFloat();
		this.ImpactPosY = base._worldPacket.ReadFloat();
		this.ImpactPosZ = base._worldPacket.ReadFloat();
		// Optional MovementInfo follows but we skip it
	}
}
