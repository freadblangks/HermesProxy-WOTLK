namespace HermesProxy.World.Server.Packets;

internal class QuestConfirmAcceptResponse : ClientPacket
{
	public uint QuestID;

	public QuestConfirmAcceptResponse(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.QuestID = base._worldPacket.ReadUInt32();
	}
}
