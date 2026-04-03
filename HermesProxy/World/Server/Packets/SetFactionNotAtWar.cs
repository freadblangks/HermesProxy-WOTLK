namespace HermesProxy.World.Server.Packets;

internal class SetFactionNotAtWar : ClientPacket
{
	public byte FactionIndex;

	public SetFactionNotAtWar(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.FactionIndex = base._worldPacket.ReadUInt8();
	}
}
