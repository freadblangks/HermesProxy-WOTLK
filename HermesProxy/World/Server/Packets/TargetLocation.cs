using Framework.GameMath;

namespace HermesProxy.World.Server.Packets;

public class TargetLocation
{
	public WowGuid128 Transport = WowGuid128.Empty;

	public Vector3 Location;

	public void Read(WorldPacket data)
	{
		this.Transport = data.ReadPackedGuid128();
		this.Location = data.ReadVector3();
	}

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.Transport);
		data.WriteVector3(this.Location);
	}
}
