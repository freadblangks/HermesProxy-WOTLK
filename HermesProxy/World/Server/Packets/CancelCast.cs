namespace HermesProxy.World.Server.Packets;

public class CancelCast : ClientPacket
{
	public uint SpellID;

	public WowGuid128 CastID;

	public CancelCast(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.CastID = base._worldPacket.ReadPackedGuid128();
		this.SpellID = base._worldPacket.ReadUInt32();
	}
}
