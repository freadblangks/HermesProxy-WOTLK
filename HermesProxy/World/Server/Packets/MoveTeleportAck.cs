namespace HermesProxy.World.Server.Packets;

internal class MoveTeleportAck : ClientPacket
{
	public WowGuid128 MoverGUID;

	public uint MoveCounter;

	public uint MoveTime;

	public MoveTeleportAck(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.MoverGUID = base._worldPacket.ReadPackedGuid128();
		this.MoveCounter = base._worldPacket.ReadUInt32();
		this.MoveTime = base._worldPacket.ReadUInt32();
	}
}
