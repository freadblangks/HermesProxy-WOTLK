namespace HermesProxy.World.Server.Packets;

internal class TotemDestroyed : ClientPacket
{
	public byte Slot;

	public WowGuid Guid;

	public TotemDestroyed(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Slot = base._worldPacket.ReadUInt8();
		this.Guid = base._worldPacket.ReadPackedGuid128();
	}
}
