namespace HermesProxy.World.Server.Packets;

public class ArenaTeamInspectData
{
	public WowGuid128 TeamGuid = WowGuid128.Empty;

	public int TeamRating;

	public int TeamGamesPlayed;

	public int TeamGamesWon;

	public int PersonalGamesPlayed;

	public int PersonalRating;

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.TeamGuid);
		data.WriteInt32(this.TeamRating);
		data.WriteInt32(this.TeamGamesPlayed);
		data.WriteInt32(this.TeamGamesWon);
		data.WriteInt32(this.PersonalGamesPlayed);
		data.WriteInt32(this.PersonalRating);
	}
}
