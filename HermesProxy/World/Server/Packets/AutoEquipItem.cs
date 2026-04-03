namespace HermesProxy.World.Server.Packets;

public class AutoEquipItem : ClientPacket
{
	public byte Slot;

	public InvUpdate Inv;

	public byte PackSlot;

	public AutoEquipItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Inv = new InvUpdate(base._worldPacket);
		this.PackSlot = base._worldPacket.ReadUInt8();
		this.Slot = base._worldPacket.ReadUInt8();
	}
}
