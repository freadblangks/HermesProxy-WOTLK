namespace HermesProxy.World.Server.Packets;

internal class AuctionBidderNotification
{
	public uint Command = 2u;

	public uint AuctionID;

	public WowGuid128 Bidder;

	public ItemInstance Item = new ItemInstance();

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.Command);
		data.WriteUInt32(this.AuctionID);
		data.WritePackedGuid128(this.Bidder);
		this.Item.Write(data);
	}
}
