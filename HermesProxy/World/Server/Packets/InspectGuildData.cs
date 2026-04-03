namespace HermesProxy.World.Server.Packets;

public class InspectGuildData
{
	public WowGuid128 GuildGUID = WowGuid128.Empty;

	public int NumGuildMembers;

	public int AchievementPoints;

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.GuildGUID);
		data.WriteInt32(this.NumGuildMembers);
		data.WriteInt32(this.AchievementPoints);
	}
}
