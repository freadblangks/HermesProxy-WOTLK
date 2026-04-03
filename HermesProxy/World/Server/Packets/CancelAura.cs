namespace HermesProxy.World.Server.Packets;

internal class CancelAura : ClientPacket
{
	public uint SpellID;

	public WowGuid128 CasterGUID;

	public CancelAura(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.SpellID = base._worldPacket.ReadUInt32();
		this.CasterGUID = base._worldPacket.ReadPackedGuid128();
	}
}
