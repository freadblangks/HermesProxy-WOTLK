using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

internal class AuctionSellItem : ClientPacket
{
	public ulong BuyoutPrice;

	public WowGuid128 Auctioneer;

	public ulong MinBid;

	public uint ExpireTime;

	public AddOnInfo TaintedBy;

	public List<AuctionItemForSale> Items = new List<AuctionItemForSale>();

	public AuctionSellItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Auctioneer = base._worldPacket.ReadPackedGuid128();
		this.MinBid = base._worldPacket.ReadUInt64();
		this.BuyoutPrice = base._worldPacket.ReadUInt64();
		this.ExpireTime = base._worldPacket.ReadUInt32();
		if (base._worldPacket.HasBit())
		{
			this.TaintedBy = new AddOnInfo();
		}
		int itemCountBits = (ModernVersion.AddedInClassicVersion(1, 14, 3, 2, 5, 4) ? 6 : 5);
		uint itemCount = base._worldPacket.ReadBits<uint>(itemCountBits);
		if (this.TaintedBy != null)
		{
			this.TaintedBy.Read(base._worldPacket);
		}
		for (int i = 0; i < itemCount; i++)
		{
			this.Items.Add(new AuctionItemForSale(base._worldPacket));
		}
	}
}
