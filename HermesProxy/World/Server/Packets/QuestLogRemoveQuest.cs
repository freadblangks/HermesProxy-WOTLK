namespace HermesProxy.World.Server.Packets;

public class QuestLogRemoveQuest : ClientPacket
{
	public byte Slot;

	public QuestLogRemoveQuest(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Slot = base._worldPacket.ReadUInt8();
	}
}
