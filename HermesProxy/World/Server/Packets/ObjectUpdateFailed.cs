namespace HermesProxy.World.Server.Packets;

public class ObjectUpdateFailed : ClientPacket
{
	public WowGuid128 ObjectGuid;

	public ObjectUpdateFailed(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.ObjectGuid = base._worldPacket.ReadPackedGuid128();
	}
}
