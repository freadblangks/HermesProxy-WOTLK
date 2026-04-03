namespace HermesProxy.World.Server.Packets;

public struct PetitionEntry
{
	public uint Index;

	public uint CharterCost;

	public uint CharterEntry;

	public uint IsArena;

	public uint RequiredSignatures;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.Index);
		data.WriteUInt32(this.CharterCost);
		data.WriteUInt32(this.CharterEntry);
		data.WriteUInt32(this.IsArena);
		data.WriteUInt32(this.RequiredSignatures);
	}
}
