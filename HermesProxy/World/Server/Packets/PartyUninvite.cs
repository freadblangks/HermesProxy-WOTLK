namespace HermesProxy.World.Server.Packets;

internal class PartyUninvite : ClientPacket
{
	public byte PartyIndex;

	public WowGuid128 TargetGUID;

	public string Reason;

	public PartyUninvite(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadUInt8();
		this.TargetGUID = base._worldPacket.ReadPackedGuid128();
		byte reasonLen = base._worldPacket.ReadBits<byte>(8);
		this.Reason = base._worldPacket.ReadString(reasonLen);
	}
}
