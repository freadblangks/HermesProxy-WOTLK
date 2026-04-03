namespace HermesProxy.World.Server.Packets;

internal class SetAdvancedCombatLogging : ClientPacket
{
	public bool Enable;

	public SetAdvancedCombatLogging(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Enable = base._worldPacket.HasBit();
	}
}
