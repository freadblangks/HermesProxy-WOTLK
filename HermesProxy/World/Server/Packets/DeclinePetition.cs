namespace HermesProxy.World.Server.Packets;

public class DeclinePetition : ClientPacket
{
	public WowGuid128 PetitionGUID;

	public DeclinePetition(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PetitionGUID = base._worldPacket.ReadPackedGuid128();
	}
}
