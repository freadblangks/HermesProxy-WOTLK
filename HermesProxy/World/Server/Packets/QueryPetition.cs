namespace HermesProxy.World.Server.Packets;

public class QueryPetition : ClientPacket
{
	public WowGuid128 ItemGUID;

	public uint PetitionID;

	public QueryPetition(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PetitionID = base._worldPacket.ReadUInt32();
		this.ItemGUID = base._worldPacket.ReadPackedGuid128();
	}
}
