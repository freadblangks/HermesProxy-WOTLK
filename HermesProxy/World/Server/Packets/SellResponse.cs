using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class SellResponse : ServerPacket
{
	public WowGuid128 VendorGUID;

	public WowGuid128 ItemGUID;

	public byte Reason;

	public SellResponse()
		: base(Opcode.SMSG_SELL_RESPONSE)
	{
	}

	public override void Write()
	{
		base._worldPacket.WritePackedGuid128(this.VendorGUID);
		base._worldPacket.WritePackedGuid128(this.ItemGUID);
		base._worldPacket.WriteUInt8(this.Reason);
	}
}
