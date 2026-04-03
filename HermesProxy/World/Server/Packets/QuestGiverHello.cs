namespace HermesProxy.World.Server.Packets;

public class QuestGiverHello : ClientPacket
{
	public WowGuid128 QuestGiverGUID;

	public QuestGiverHello(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.QuestGiverGUID = base._worldPacket.ReadPackedGuid128();
	}
}
