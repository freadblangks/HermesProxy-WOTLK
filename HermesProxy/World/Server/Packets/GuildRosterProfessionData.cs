namespace HermesProxy.World.Server.Packets;

public struct GuildRosterProfessionData
{
	public int DbID;

	public int Rank;

	public int Step;

	public void Write(WorldPacket data)
	{
		data.WriteInt32(this.DbID);
		data.WriteInt32(this.Rank);
		data.WriteInt32(this.Step);
	}
}
