namespace HermesProxy.World.Server.Packets;

internal class QueryPetName : ClientPacket
{
	public WowGuid128 UnitGUID;

	public QueryPetName(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.UnitGUID = base._worldPacket.ReadPackedGuid128();
	}
}
