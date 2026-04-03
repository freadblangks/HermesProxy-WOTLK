namespace HermesProxy.World.Server.Packets;

public class RepairItem : ClientPacket
{
	public WowGuid128 VendorGUID;

	public WowGuid128 ItemGUID;

	public bool UseGuildBank;

	public RepairItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.VendorGUID = base._worldPacket.ReadPackedGuid128();
		this.ItemGUID = base._worldPacket.ReadPackedGuid128();
		this.UseGuildBank = base._worldPacket.HasBit();
	}
}
