namespace HermesProxy.World.Server.Packets;

public class CancelTempEnchantment : ClientPacket
{
	public uint EnchantmentSlot;

	public CancelTempEnchantment(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.EnchantmentSlot = base._worldPacket.ReadUInt32();
	}
}
