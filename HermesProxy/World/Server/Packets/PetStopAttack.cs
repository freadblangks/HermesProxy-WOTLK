namespace HermesProxy.World.Server.Packets;

internal class PetStopAttack : ClientPacket
{
	public WowGuid128 PetGUID;

	public PetStopAttack(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PetGUID = base._worldPacket.ReadPackedGuid128();
	}
}
