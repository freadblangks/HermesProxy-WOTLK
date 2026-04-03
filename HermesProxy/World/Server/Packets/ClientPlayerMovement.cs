using HermesProxy.World.Objects;

namespace HermesProxy.World.Server.Packets;

public class ClientPlayerMovement : ClientPacket
{
	public WowGuid128 Guid;

	public MovementInfo MoveInfo;

	public ClientPlayerMovement(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Guid = base._worldPacket.ReadPackedGuid128();
		this.MoveInfo = new MovementInfo();
		this.MoveInfo.ReadMovementInfoModern(base._worldPacket);
	}
}
