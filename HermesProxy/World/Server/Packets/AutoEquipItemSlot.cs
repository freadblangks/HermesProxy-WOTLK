namespace HermesProxy.World.Server.Packets;

internal class AutoEquipItemSlot : ClientPacket
{
	public WowGuid128 Item;

	public byte ItemDstSlot;

	public InvUpdate Inv;

	public AutoEquipItemSlot(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Inv = new InvUpdate(base._worldPacket);
		this.Item = base._worldPacket.ReadPackedGuid128();
		this.ItemDstSlot = base._worldPacket.ReadUInt8();
	}
}
