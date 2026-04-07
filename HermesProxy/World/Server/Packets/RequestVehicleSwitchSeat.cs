using HermesProxy.World.Objects;

namespace HermesProxy.World.Server.Packets;

public class RequestVehicleSwitchSeat : ClientPacket
{
	public WowGuid128 Vehicle;
	public byte SeatIndex;

	public RequestVehicleSwitchSeat(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Vehicle = base._worldPacket.ReadPackedGuid128();
		this.SeatIndex = base._worldPacket.ReadUInt8();
	}
}
