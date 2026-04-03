using Framework.GameMath;

namespace HermesProxy.World.Server.Packets;

public struct BattlegroundPlayerPosition
{
	public WowGuid128 Guid;

	public Vector2 Pos;

	public sbyte IconID;

	public sbyte ArenaSlot;

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.Guid);
		data.WriteVector2(this.Pos);
		data.WriteInt8(this.IconID);
		data.WriteInt8(this.ArenaSlot);
	}
}
