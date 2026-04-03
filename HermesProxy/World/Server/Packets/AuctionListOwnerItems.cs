namespace HermesProxy.World.Server.Packets;

internal class AuctionListOwnerItems : ClientPacket
{
	public WowGuid128 Auctioneer;

	public uint Offset;

	public AuctionListOwnerItems(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Auctioneer = base._worldPacket.ReadPackedGuid128();
		this.Offset = base._worldPacket.ReadUInt32();
	}
}
