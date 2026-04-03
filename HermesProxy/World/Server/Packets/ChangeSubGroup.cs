namespace HermesProxy.World.Server.Packets;

internal class ChangeSubGroup : ClientPacket
{
	public WowGuid128 TargetGUID;

	public sbyte PartyIndex;

	public byte NewSubGroup;

	public ChangeSubGroup(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.TargetGUID = base._worldPacket.ReadPackedGuid128();
		this.PartyIndex = base._worldPacket.ReadInt8();
		this.NewSubGroup = base._worldPacket.ReadUInt8();
	}
}
