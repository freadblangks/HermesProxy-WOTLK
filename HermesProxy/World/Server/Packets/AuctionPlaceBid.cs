namespace HermesProxy.World.Server.Packets;

internal class AuctionPlaceBid : ClientPacket
{
	public WowGuid128 Auctioneer;

	public ulong BidAmount;

	public uint AuctionID;

	public AddOnInfo TaintedBy;

	public AuctionPlaceBid(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Auctioneer = base._worldPacket.ReadPackedGuid128();
		this.AuctionID = base._worldPacket.ReadUInt32();
		this.BidAmount = base._worldPacket.ReadUInt64();
		if (base._worldPacket.HasBit())
		{
			this.TaintedBy = new AddOnInfo();
		}
		if (this.TaintedBy != null)
		{
			this.TaintedBy.Read(base._worldPacket);
		}
	}
}
