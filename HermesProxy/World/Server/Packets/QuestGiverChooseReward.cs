namespace HermesProxy.World.Server.Packets;

public class QuestGiverChooseReward : ClientPacket
{
	public WowGuid128 QuestGiverGUID;

	public uint QuestID;

	public QuestChoiceItem Choice = new QuestChoiceItem();

	public QuestGiverChooseReward(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.QuestGiverGUID = base._worldPacket.ReadPackedGuid128();
		this.QuestID = base._worldPacket.ReadUInt32();
		this.Choice.Read(base._worldPacket);
	}
}
