namespace HermesProxy.World.Server.Packets;

public class SwapInvItem : ClientPacket
{
	public InvUpdate Inv;

	public byte Slot1;

	public byte Slot2;

	public SwapInvItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Inv = new InvUpdate(base._worldPacket);
		this.Slot2 = base._worldPacket.ReadUInt8();
		this.Slot1 = base._worldPacket.ReadUInt8();
	}
}
