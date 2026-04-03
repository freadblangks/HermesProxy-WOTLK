namespace HermesProxy.World.Server.Packets;

internal class PartyInviteResponse : ClientPacket
{
	public byte PartyIndex;

	public bool Accept;

	public uint? RolesDesired;

	public PartyInviteResponse(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PartyIndex = base._worldPacket.ReadUInt8();
		this.Accept = base._worldPacket.HasBit();
		if (base._worldPacket.HasBit())
		{
			this.RolesDesired = base._worldPacket.ReadUInt32();
		}
	}
}
