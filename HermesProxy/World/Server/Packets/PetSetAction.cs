namespace HermesProxy.World.Server.Packets;

internal class PetSetAction : ClientPacket
{
	public WowGuid128 PetGUID;

	public uint Index;

	public uint Action;

	public PetSetAction(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PetGUID = base._worldPacket.ReadPackedGuid128();
		this.Index = base._worldPacket.ReadUInt32();
		this.Action = base._worldPacket.ReadUInt32();
	}
}
