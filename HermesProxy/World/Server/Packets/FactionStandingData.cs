namespace HermesProxy.World.Server.Packets;

internal struct FactionStandingData
{
	public int Index;

	public int Standing;

	public void Write(WorldPacket data)
	{
		data.WriteInt32(this.Index);
		data.WriteInt32(this.Standing);
	}
}
