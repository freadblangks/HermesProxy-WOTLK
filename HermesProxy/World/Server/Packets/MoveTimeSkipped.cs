namespace HermesProxy.World.Server.Packets;

internal class MoveTimeSkipped : ClientPacket
{
	public WowGuid128 MoverGUID;

	public uint TimeSkipped;

	public MoveTimeSkipped(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.MoverGUID = base._worldPacket.ReadPackedGuid128();
		this.TimeSkipped = base._worldPacket.ReadUInt32();
	}
}
