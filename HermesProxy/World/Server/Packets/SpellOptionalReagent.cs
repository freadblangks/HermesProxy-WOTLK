namespace HermesProxy.World.Server.Packets;

public struct SpellOptionalReagent
{
	public int ItemID;

	public int Slot;

	public int Count;

	public void Read(WorldPacket data)
	{
		this.ItemID = data.ReadInt32();
		this.Slot = data.ReadInt32();
		this.Count = data.ReadInt32();
	}
}
