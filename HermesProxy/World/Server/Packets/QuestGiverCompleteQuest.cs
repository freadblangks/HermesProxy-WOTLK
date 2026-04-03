namespace HermesProxy.World.Server.Packets;

public class QuestGiverCompleteQuest : ClientPacket
{
	public WowGuid128 QuestGiverGUID;

	public uint QuestID;

	public bool FromScript;

	public QuestGiverCompleteQuest(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.QuestGiverGUID = base._worldPacket.ReadPackedGuid128();
		this.QuestID = base._worldPacket.ReadUInt32();
		this.FromScript = base._worldPacket.HasBit();
	}
}
