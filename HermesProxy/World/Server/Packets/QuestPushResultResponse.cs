using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class QuestPushResultResponse : ClientPacket
{
	public WowGuid128 SenderGUID;

	public uint QuestID;

	public QuestPushReason Result;

	public QuestPushResultResponse(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.SenderGUID = base._worldPacket.ReadPackedGuid128();
		this.QuestID = base._worldPacket.ReadUInt32();
		this.Result = (QuestPushReason)base._worldPacket.ReadUInt8();
	}
}
