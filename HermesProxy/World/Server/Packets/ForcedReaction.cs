namespace HermesProxy.World.Server.Packets;

internal struct ForcedReaction
{
	public int Faction;

	public int Reaction;

	public void Write(WorldPacket data)
	{
		data.WriteInt32(this.Faction);
		data.WriteInt32(this.Reaction);
	}
}
