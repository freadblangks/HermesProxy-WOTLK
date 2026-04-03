namespace HermesProxy.World.Server.Packets;

internal class AuctionRemoveItem : ClientPacket
{
	public WowGuid128 Auctioneer;

	public uint AuctionID;

	public AddOnInfo TaintedBy;

	public AuctionRemoveItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Auctioneer = base._worldPacket.ReadPackedGuid128();
		this.AuctionID = base._worldPacket.ReadUInt32();
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
