namespace HermesProxy.World.Server.Packets;

public struct MissileTrajectoryResult
{
	public uint TravelTime;

	public float Pitch;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.TravelTime);
		data.WriteFloat(this.Pitch);
	}
}
