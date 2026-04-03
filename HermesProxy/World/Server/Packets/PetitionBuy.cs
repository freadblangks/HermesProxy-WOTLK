namespace HermesProxy.World.Server.Packets;

public class PetitionBuy : ClientPacket
{
	public WowGuid128 Unit;

	public uint Index;

	public string Title;

	public PetitionBuy(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint titleLen = base._worldPacket.ReadBits<uint>(7);
		this.Unit = base._worldPacket.ReadPackedGuid128();
		this.Index = base._worldPacket.ReadUInt32();
		this.Title = base._worldPacket.ReadString(titleLen);
	}
}
