namespace HermesProxy.World.Server.Packets;

public struct SpellExtraCurrencyCost
{
	public int CurrencyID;

	public int Slot;

	public int Count;

	public void Read(WorldPacket data)
	{
		this.CurrencyID = data.ReadInt32();
		this.Slot = data.ReadInt32();
		this.Count = data.ReadInt32();
	}
}
