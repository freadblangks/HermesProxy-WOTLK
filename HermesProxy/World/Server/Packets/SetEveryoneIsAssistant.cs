namespace HermesProxy.World.Server.Packets;

internal class SetEveryoneIsAssistant : ClientPacket
{
	public byte PartyIndex;

	public bool Apply;

	public SetEveryoneIsAssistant(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadUInt8();
		this.Apply = base._worldPacket.HasBit();
	}
}
