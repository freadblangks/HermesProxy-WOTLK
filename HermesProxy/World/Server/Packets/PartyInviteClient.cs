namespace HermesProxy.World.Server.Packets;

internal class PartyInviteClient : ClientPacket
{
	public byte PartyIndex;

	public uint VirtualRealmAddress;

	public WowGuid128 TargetGUID;

	public string TargetName;

	public string TargetRealm;

	public PartyInviteClient(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadUInt8();
		uint targetNameLen = base._worldPacket.ReadBits<uint>(9);
		uint targetRealmLen = base._worldPacket.ReadBits<uint>(9);
		this.VirtualRealmAddress = base._worldPacket.ReadUInt32();
		this.TargetGUID = base._worldPacket.ReadPackedGuid128();
		this.TargetName = base._worldPacket.ReadString(targetNameLen);
		this.TargetRealm = base._worldPacket.ReadString(targetRealmLen);
	}
}
