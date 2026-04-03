namespace HermesProxy.World.Server.Packets;

public class BuyBackItem : ClientPacket
{
	public WowGuid128 VendorGUID;

	public uint Slot;

	public BuyBackItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.VendorGUID = base._worldPacket.ReadPackedGuid128();
		this.Slot = base._worldPacket.ReadUInt32();
	}
}
