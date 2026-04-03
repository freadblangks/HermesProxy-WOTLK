namespace HermesProxy.World.Server.Packets;

public class DuelResponse : ClientPacket
{
	public WowGuid128 ArbiterGUID;

	public bool Accepted;

	public bool Forfeited;

	public DuelResponse(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.ArbiterGUID = base._worldPacket.ReadPackedGuid128();
		this.Accepted = base._worldPacket.HasBit();
		this.Forfeited = base._worldPacket.HasBit();
	}
}
