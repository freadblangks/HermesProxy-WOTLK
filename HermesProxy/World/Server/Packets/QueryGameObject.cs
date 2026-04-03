namespace HermesProxy.World.Server.Packets;

public class QueryGameObject : ClientPacket
{
	public uint GameObjectID;

	public WowGuid128 Guid;

	public QueryGameObject(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.GameObjectID = base._worldPacket.ReadUInt32();
		this.Guid = base._worldPacket.ReadPackedGuid128();
	}
}
