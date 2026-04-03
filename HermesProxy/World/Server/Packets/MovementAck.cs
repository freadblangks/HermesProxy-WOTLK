using HermesProxy.World.Objects;

namespace HermesProxy.World.Server.Packets;

public struct MovementAck
{
	public MovementInfo MoveInfo;

	public uint MoveCounter;

	public void Read(WorldPacket data)
	{
		this.MoveInfo = new MovementInfo();
		this.MoveInfo.ReadMovementInfoModern(data);
		this.MoveCounter = data.ReadUInt32();
	}
}
