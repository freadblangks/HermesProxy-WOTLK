namespace HermesProxy.World.Server.Packets;

public class QuestGiverQueryQuest : ClientPacket
{
	public WowGuid128 QuestGiverGUID;

	public uint QuestID;

	public bool RespondToGiver;

	public QuestGiverQueryQuest(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.QuestGiverGUID = base._worldPacket.ReadPackedGuid128();
		this.QuestID = base._worldPacket.ReadUInt32();
		this.RespondToGiver = base._worldPacket.HasBit();
	}
}
