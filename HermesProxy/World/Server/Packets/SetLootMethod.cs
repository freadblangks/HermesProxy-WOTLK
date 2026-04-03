using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class SetLootMethod : ClientPacket
{
	public sbyte PartyIndex;

	public LootMethod LootMethod;

	public WowGuid128 LootMasterGUID;

	public uint LootThreshold;

	public SetLootMethod(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadInt8();
		this.LootMethod = (LootMethod)base._worldPacket.ReadUInt8();
		this.LootMasterGUID = base._worldPacket.ReadPackedGuid128();
		this.LootThreshold = base._worldPacket.ReadUInt32();
	}
}
