namespace HermesProxy.World.Server.Packets;

internal class UpdateRaidTarget : ClientPacket
{
	public sbyte PartyIndex;

	public WowGuid128 Target;

	public sbyte Symbol;

	public UpdateRaidTarget(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadInt8();
		this.Target = base._worldPacket.ReadPackedGuid128();
		this.Symbol = base._worldPacket.ReadInt8();
	}
}
