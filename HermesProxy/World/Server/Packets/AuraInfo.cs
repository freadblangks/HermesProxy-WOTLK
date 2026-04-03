namespace HermesProxy.World.Server.Packets;

public struct AuraInfo
{
	public byte Slot;

	public AuraDataInfo AuraData;

	public void Write(WorldPacket data)
	{
		data.WriteUInt8(this.Slot);
		data.WriteBit(this.AuraData != null);
		data.FlushBits();
		if (this.AuraData != null)
		{
			this.AuraData.Write(data);
		}
	}
}
