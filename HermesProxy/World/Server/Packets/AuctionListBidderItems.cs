using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

internal class AuctionListBidderItems : ClientPacket
{
	public WowGuid128 Auctioneer;

	public uint Offset;

	public List<uint> AuctionItemIDs = new List<uint>();

	public AuctionListBidderItems(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Auctioneer = base._worldPacket.ReadPackedGuid128();
		this.Offset = base._worldPacket.ReadUInt32();
		uint auctionIDCount = base._worldPacket.ReadBits<uint>(7);
		base._worldPacket.ResetBitPos();
		for (int i = 0; i < auctionIDCount; i++)
		{
			this.AuctionItemIDs[i] = base._worldPacket.ReadUInt32();
		}
	}
}
