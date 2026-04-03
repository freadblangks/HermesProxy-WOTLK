namespace HermesProxy.World.Server.Packets;

public class SetTradeItem : ClientPacket
{
	public byte TradeSlot;

	public byte PackSlot;

	public byte ItemSlotInPack;

	public SetTradeItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.TradeSlot = base._worldPacket.ReadUInt8();
		this.PackSlot = base._worldPacket.ReadUInt8();
		this.ItemSlotInPack = base._worldPacket.ReadUInt8();
	}
}
