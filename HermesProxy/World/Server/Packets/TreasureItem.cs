using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public struct TreasureItem
{
	public GossipOptionRewardType Type;

	public int ID;

	public int Quantity;

	public void Write(WorldPacket data)
	{
		data.WriteBits((byte)this.Type, 1);
		data.WriteInt32(this.ID);
		data.WriteInt32(this.Quantity);
	}
}
