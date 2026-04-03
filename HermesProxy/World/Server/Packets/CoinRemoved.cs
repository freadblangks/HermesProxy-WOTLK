using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class CoinRemoved : ServerPacket
{
	public WowGuid128 LootObj;

	public CoinRemoved()
		: base(Opcode.SMSG_COIN_REMOVED)
	{
	}

	public override void Write()
	{
		base._worldPacket.WritePackedGuid128(this.LootObj);
	}
}
