namespace HermesProxy.World.Server.Packets;

internal class SetPartyLeader : ClientPacket
{
	public sbyte PartyIndex;

	public WowGuid128 TargetGUID;

	public SetPartyLeader(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadInt8();
		this.TargetGUID = base._worldPacket.ReadPackedGuid128();
	}
}
