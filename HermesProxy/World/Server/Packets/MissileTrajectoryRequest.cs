namespace HermesProxy.World.Server.Packets;

public struct MissileTrajectoryRequest
{
	public float Pitch;

	public float Speed;

	public void Read(WorldPacket data)
	{
		this.Pitch = data.ReadFloat();
		this.Speed = data.ReadFloat();
	}
}
