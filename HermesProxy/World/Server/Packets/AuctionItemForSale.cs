namespace HermesProxy.World.Server.Packets;

public struct AuctionItemForSale
{
	public WowGuid128 Guid;

	public uint UseCount;

	public AuctionItemForSale(WorldPacket data)
	{
		this.Guid = data.ReadPackedGuid128();
		this.UseCount = data.ReadUInt32();
	}
}
