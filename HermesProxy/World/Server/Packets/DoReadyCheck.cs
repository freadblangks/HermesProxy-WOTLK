namespace HermesProxy.World.Server.Packets;

internal class DoReadyCheck : ClientPacket
{
	public sbyte PartyIndex;

	public DoReadyCheck(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadInt8();
	}
}
