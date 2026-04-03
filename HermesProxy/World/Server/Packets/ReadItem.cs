namespace HermesProxy.World.Server.Packets;

internal class ReadItem : ClientPacket
{
	public byte PackSlot;

	public byte Slot;

	public ReadItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PackSlot = base._worldPacket.ReadUInt8();
		this.Slot = base._worldPacket.ReadUInt8();
	}
}
