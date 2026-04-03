namespace HermesProxy.World.Server.Packets;

public struct InspectEnchantData
{
	public uint Id;

	public byte Index;

	public InspectEnchantData(uint id, byte index)
	{
		this.Id = id;
		this.Index = index;
	}

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.Id);
		data.WriteUInt8(this.Index);
	}
}
