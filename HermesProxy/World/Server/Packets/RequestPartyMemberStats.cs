namespace HermesProxy.World.Server.Packets;

internal class RequestPartyMemberStats : ClientPacket
{
	public byte PartyIndex;

	public WowGuid128 TargetGUID;

	public RequestPartyMemberStats(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadUInt8();
		this.TargetGUID = base._worldPacket.ReadPackedGuid128();
	}
}
