using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class PartyDifficultySettings
{
	public DifficultyModern DungeonDifficultyID;

	public DifficultyModern RaidDifficultyID;

	public DifficultyModern LegacyRaidDifficultyID;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32((uint)this.DungeonDifficultyID);
		data.WriteUInt32((uint)this.RaidDifficultyID);
		data.WriteUInt32((uint)this.LegacyRaidDifficultyID);
	}
}
