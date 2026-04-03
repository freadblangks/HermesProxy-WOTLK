namespace HermesProxy.World.Server.Packets;

internal class ActivateTaxi : ClientPacket
{
	public WowGuid128 FlightMaster;

	public uint Node;

	public uint GroundMountID;

	public uint FlyingMountID;

	public ActivateTaxi(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.FlightMaster = base._worldPacket.ReadPackedGuid128();
		this.Node = base._worldPacket.ReadUInt32();
		this.GroundMountID = base._worldPacket.ReadUInt32();
		this.FlyingMountID = base._worldPacket.ReadUInt32();
	}
}
