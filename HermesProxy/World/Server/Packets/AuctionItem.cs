using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class AuctionItem
{
	public ItemInstance Item;

	public int Count;

	public int Charges;

	public List<ItemEnchantData> Enchantments = new List<ItemEnchantData>();

	public uint Flags = 196608u;

	public uint AuctionID;

	public WowGuid128 Owner;

	public ulong? MinBid;

	public ulong? MinIncrement;

	public ulong? BuyoutPrice;

	public ulong? UnitPrice;

	public int DurationLeft;

	public byte DeleteReason;

	public bool CensorServerSideInfo;

	public bool CensorBidInfo;

	public WowGuid128 ItemGuid = WowGuid128.Empty;

	public WowGuid128 OwnerAccountID;

	public uint EndTime;

	public WowGuid128 Creator;

	public WowGuid128 Bidder;

	public ulong? BidAmount;

	public List<ItemGemData> Gems = new List<ItemGemData>();

	public AuctionBucketKey AuctionBucketKey;

	public void Write(WorldPacket data)
	{
		data.WriteBit(this.Item != null);
		data.WriteBits(this.Enchantments.Count, 4);
		data.WriteBits(this.Gems.Count, 2);
		data.WriteBit(this.MinBid.HasValue);
		data.WriteBit(this.MinIncrement.HasValue);
		data.WriteBit(this.BuyoutPrice.HasValue);
		data.WriteBit(this.UnitPrice.HasValue);
		data.WriteBit(this.CensorServerSideInfo);
		data.WriteBit(this.CensorBidInfo);
		data.WriteBit(this.AuctionBucketKey != null);
		data.WriteBit(this.Creator != null);
		if (!this.CensorBidInfo)
		{
			data.WriteBit(this.Bidder != null);
			data.WriteBit(this.BidAmount.HasValue);
		}
		data.FlushBits();
		if (this.Item != null)
		{
			this.Item.Write(data);
		}
		data.WriteInt32(this.Count);
		data.WriteInt32(this.Charges);
		data.WriteUInt32(this.Flags);
		data.WriteUInt32(this.AuctionID);
		data.WritePackedGuid128(this.Owner);
		data.WriteInt32(this.DurationLeft);
		data.WriteUInt8(this.DeleteReason);
		foreach (ItemEnchantData enchant in this.Enchantments)
		{
			enchant.Write(data);
		}
		if (this.MinBid.HasValue)
		{
			data.WriteUInt64(this.MinBid.Value);
		}
		if (this.MinIncrement.HasValue)
		{
			data.WriteUInt64(this.MinIncrement.Value);
		}
		if (this.BuyoutPrice.HasValue)
		{
			data.WriteUInt64(this.BuyoutPrice.Value);
		}
		if (this.UnitPrice.HasValue)
		{
			data.WriteUInt64(this.UnitPrice.Value);
		}
		if (!this.CensorServerSideInfo)
		{
			data.WritePackedGuid128(this.ItemGuid);
			data.WritePackedGuid128(this.OwnerAccountID);
			data.WriteUInt32(this.EndTime);
		}
		if (this.Creator != null)
		{
			data.WritePackedGuid128(this.Creator);
		}
		if (!this.CensorBidInfo)
		{
			if (this.Bidder != null)
			{
				data.WritePackedGuid128(this.Bidder);
			}
			if (this.BidAmount.HasValue)
			{
				data.WriteUInt64(this.BidAmount.Value);
			}
		}
		foreach (ItemGemData gem in this.Gems)
		{
			gem.Write(data);
		}
		if (this.AuctionBucketKey != null)
		{
			this.AuctionBucketKey.Write(data);
		}
	}
}
