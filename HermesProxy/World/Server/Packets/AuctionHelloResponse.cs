using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class AuctionHelloResponse : ServerPacket
{
	public WowGuid128 Guid;

	public uint AuctionHouseID;

	public bool OpenForBusiness = true;

	public AuctionHelloResponse()
		: base(Opcode.SMSG_AUCTION_HELLO_RESPONSE)
	{
	}

	public override void Write()
	{
		base._worldPacket.WritePackedGuid128(this.Guid);
		base._worldPacket.WriteUInt32(this.AuctionHouseID);
		base._worldPacket.WriteBit(this.OpenForBusiness);
		base._worldPacket.FlushBits();
	}
}
