namespace HermesProxy.World.Server.Packets;

public class OfferPetition : ClientPacket
{
	public uint UnkInt;

	public WowGuid128 TargetPlayer;

	public WowGuid128 ItemGUID;

	public OfferPetition(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.UnkInt = base._worldPacket.ReadUInt32();
		this.ItemGUID = base._worldPacket.ReadPackedGuid128();
		this.TargetPlayer = base._worldPacket.ReadPackedGuid128();
	}
}
