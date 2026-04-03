namespace HermesProxy.World.Server.Packets;

public class MovementSpeedAck : ClientPacket
{
	public WowGuid128 MoverGUID;

	public MovementAck Ack;

	public float Speed;

	public MovementSpeedAck(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.MoverGUID = base._worldPacket.ReadPackedGuid128();
		this.Ack.Read(base._worldPacket);
		this.Speed = base._worldPacket.ReadFloat();
	}
}
