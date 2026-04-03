namespace HermesProxy.World.Server.Packets;

public class SignPetition : ClientPacket
{
	public WowGuid128 PetitionGUID;

	public byte Choice;

	public SignPetition(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PetitionGUID = base._worldPacket.ReadPackedGuid128();
		this.Choice = base._worldPacket.ReadUInt8();
	}
}
