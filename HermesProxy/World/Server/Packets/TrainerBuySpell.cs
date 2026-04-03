namespace HermesProxy.World.Server.Packets;

internal class TrainerBuySpell : ClientPacket
{
	public WowGuid128 TrainerGUID;

	public uint TrainerID;

	public uint SpellID;

	public TrainerBuySpell(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.TrainerGUID = base._worldPacket.ReadPackedGuid128();
		this.TrainerID = base._worldPacket.ReadUInt32();
		this.SpellID = base._worldPacket.ReadUInt32();
	}
}
