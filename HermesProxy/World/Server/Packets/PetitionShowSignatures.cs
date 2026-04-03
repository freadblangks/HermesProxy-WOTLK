namespace HermesProxy.World.Server.Packets;

public class PetitionShowSignatures : ClientPacket
{
	public WowGuid128 Item;

	public PetitionShowSignatures(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Item = base._worldPacket.ReadPackedGuid128();
	}
}
