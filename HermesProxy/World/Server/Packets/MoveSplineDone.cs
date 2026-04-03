using HermesProxy.World.Objects;

namespace HermesProxy.World.Server.Packets;

internal class MoveSplineDone : ClientPacket
{
	public WowGuid128 Guid;

	public MovementInfo MoveInfo;

	public int SplineID;

	public MoveSplineDone(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Guid = base._worldPacket.ReadPackedGuid128();
		this.MoveInfo = new MovementInfo();
		this.MoveInfo.ReadMovementInfoModern(base._worldPacket);
		this.SplineID = base._worldPacket.ReadInt32();
	}
}
