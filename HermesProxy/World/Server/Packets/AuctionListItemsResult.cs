using System.Collections.Generic;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class AuctionListItemsResult : ServerPacket
{
	public List<AuctionItem> Items = new List<AuctionItem>();

	public int TotalItemsCount;

	public uint DesiredDelay = 300u;

	public bool OnlyUsable;

	public AuctionListItemsResult()
		: base(Opcode.SMSG_AUCTION_LIST_ITEMS_RESULT)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteInt32(this.Items.Count);
		base._worldPacket.WriteInt32(this.TotalItemsCount);
		base._worldPacket.WriteUInt32(this.DesiredDelay);
		if (this.Items.Count > 0)
		{
			base._worldPacket.WriteBool(this.OnlyUsable);
		}
		foreach (AuctionItem item in this.Items)
		{
			item.Write(base._worldPacket);
		}
	}
}
