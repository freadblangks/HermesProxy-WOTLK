namespace HermesProxy.World.Server.Packets;

public class PetCastSpell : ClientPacket
{
	public WowGuid128 PetGUID;

	public SpellCastRequest Cast;

	public PetCastSpell(WorldPacket packet)
		: base(packet)
	{
		this.Cast = new SpellCastRequest();
	}

	public override void Read()
	{
		this.PetGUID = base._worldPacket.ReadPackedGuid128();
		this.Cast.Read(base._worldPacket);
	}
}
