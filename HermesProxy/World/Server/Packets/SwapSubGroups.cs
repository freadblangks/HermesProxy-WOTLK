namespace HermesProxy.World.Server.Packets;

internal class SwapSubGroups : ClientPacket
{
	public WowGuid128 FirstTarget;

	public WowGuid128 SecondTarget;

	public sbyte PartyIndex;

	public SwapSubGroups(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadInt8();
		this.FirstTarget = base._worldPacket.ReadPackedGuid128();
		this.SecondTarget = base._worldPacket.ReadPackedGuid128();
	}
}
