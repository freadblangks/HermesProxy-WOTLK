namespace HermesProxy.World.Server.Packets;

internal class PushQuestToParty : ClientPacket
{
	public uint QuestID;

	public PushQuestToParty(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.QuestID = base._worldPacket.ReadUInt32();
	}
}
