namespace HermesProxy.World.Server.Packets;

internal class UnstablePet : ClientPacket
{
	public uint PetNumber;

	public WowGuid128 StableMaster;

	public UnstablePet(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PetNumber = base._worldPacket.ReadUInt32();
		this.StableMaster = base._worldPacket.ReadPackedGuid128();
	}
}
