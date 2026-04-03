namespace HermesProxy.World.Server.Packets;

internal class ReadyCheckResponseClient : ClientPacket
{
	public byte PartyIndex;

	public bool IsReady;

	public ReadyCheckResponseClient(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadUInt8();
		this.IsReady = base._worldPacket.HasBit();
	}
}
