using System.Collections.Generic;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class AuctionListMyItemsResult : ServerPacket
{
	public List<AuctionItem> Items = new List<AuctionItem>();

	public int TotalItemsCount;

	public uint DesiredDelay = 300u;

	public AuctionListMyItemsResult(Opcode opcode)
		: base(opcode)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteInt32(this.Items.Count);
		base._worldPacket.WriteInt32(this.TotalItemsCount);
		base._worldPacket.WriteUInt32(this.DesiredDelay);
		foreach (AuctionItem item in this.Items)
		{
			item.Write(base._worldPacket);
		}
	}
}
