using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class PartyLootSettings
{
	public LootMethod Method;

	public WowGuid128 LootMaster;

	public byte Threshold;

	public void Write(WorldPacket data)
	{
		data.WriteUInt8((byte)this.Method);
		data.WritePackedGuid128(this.LootMaster);
		data.WriteUInt8(this.Threshold);
	}
}
