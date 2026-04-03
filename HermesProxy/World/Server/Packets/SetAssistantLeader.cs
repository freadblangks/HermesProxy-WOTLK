namespace HermesProxy.World.Server.Packets;

internal class SetAssistantLeader : ClientPacket
{
	public byte PartyIndex;

	public WowGuid128 TargetGUID;

	public bool Apply;

	public SetAssistantLeader(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadUInt8();
		this.TargetGUID = base._worldPacket.ReadPackedGuid128();
		this.Apply = base._worldPacket.HasBit();
	}
}
