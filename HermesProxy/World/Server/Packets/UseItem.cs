namespace HermesProxy.World.Server.Packets;

public class UseItem : ClientPacket
{
	public byte PackSlot;

	public byte Slot;

	public WowGuid128 CastItem;

	public SpellCastRequest Cast;

	public UseItem(WorldPacket packet)
		: base(packet)
	{
		this.Cast = new SpellCastRequest();
	}

	public override void Read()
	{
		this.PackSlot = base._worldPacket.ReadUInt8();
		this.Slot = base._worldPacket.ReadUInt8();
		this.CastItem = base._worldPacket.ReadPackedGuid128();
		this.Cast.Read(base._worldPacket);
	}
}
