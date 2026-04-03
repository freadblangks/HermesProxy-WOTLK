namespace HermesProxy.World.Server.Packets;

public class QuestGiverAcceptQuest : ClientPacket
{
	public WowGuid128 QuestGiverGUID;

	public uint QuestID;

	public bool StartCheat;

	public QuestGiverAcceptQuest(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.QuestGiverGUID = base._worldPacket.ReadPackedGuid128();
		this.QuestID = base._worldPacket.ReadUInt32();
		this.StartCheat = base._worldPacket.HasBit();
	}
}
