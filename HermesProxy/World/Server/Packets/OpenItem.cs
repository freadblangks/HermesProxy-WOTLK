namespace HermesProxy.World.Server.Packets;

public class OpenItem : ClientPacket
{
	public byte PackSlot;

	public byte Slot;

	public OpenItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PackSlot = base._worldPacket.ReadUInt8();
		this.Slot = base._worldPacket.ReadUInt8();
	}
}
