using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class LootRoll : ClientPacket
{
	public WowGuid128 LootObj;

	public byte LootListID;

	public RollType RollType;

	public LootRoll(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.LootObj = base._worldPacket.ReadPackedGuid128();
		this.LootListID = base._worldPacket.ReadUInt8();
		this.RollType = (RollType)base._worldPacket.ReadUInt8();
	}
}
