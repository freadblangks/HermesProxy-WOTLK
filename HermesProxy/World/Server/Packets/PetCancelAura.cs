namespace HermesProxy.World.Server.Packets;

internal class PetCancelAura : ClientPacket
{
	public WowGuid128 PetGUID;

	public uint SpellID;

	public PetCancelAura(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PetGUID = base._worldPacket.ReadPackedGuid128();
		this.SpellID = base._worldPacket.ReadUInt32();
	}
}
