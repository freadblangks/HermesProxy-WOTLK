namespace HermesProxy.World.Server.Packets;

public class QueryQuestInfo : ClientPacket
{
	public WowGuid128 QuestGiver;

	public uint QuestID;

	public QueryQuestInfo(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.QuestID = base._worldPacket.ReadUInt32();
		this.QuestGiver = base._worldPacket.ReadPackedGuid128();
	}
}
