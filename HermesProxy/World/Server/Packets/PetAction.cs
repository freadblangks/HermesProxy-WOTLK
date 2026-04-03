using Framework.GameMath;

namespace HermesProxy.World.Server.Packets;

internal class PetAction : ClientPacket
{
	public WowGuid128 PetGUID;

	public uint Action;

	public WowGuid128 TargetGUID;

	public Vector3 ActionPosition;

	public PetAction(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PetGUID = base._worldPacket.ReadPackedGuid128();
		this.Action = base._worldPacket.ReadUInt32();
		this.TargetGUID = base._worldPacket.ReadPackedGuid128();
		this.ActionPosition = base._worldPacket.ReadVector3();
	}
}
