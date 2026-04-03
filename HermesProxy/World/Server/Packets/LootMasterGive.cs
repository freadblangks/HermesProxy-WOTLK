using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

internal class LootMasterGive : ClientPacket
{
	public WowGuid128 TargetGUID;

	public List<LootRequest> Loot = new List<LootRequest>();

	public LootMasterGive(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint Count = base._worldPacket.ReadUInt32();
		this.TargetGUID = base._worldPacket.ReadPackedGuid128();
		for (int i = 0; i < Count; i++)
		{
			LootRequest lootRequest = new LootRequest
			{
				LootObj = base._worldPacket.ReadPackedGuid128(),
				LootListID = base._worldPacket.ReadUInt8()
			};
			this.Loot.Add(lootRequest);
		}
	}
}
