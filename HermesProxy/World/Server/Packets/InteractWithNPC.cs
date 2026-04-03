namespace HermesProxy.World.Server.Packets;

public class InteractWithNPC : ClientPacket
{
	public WowGuid128 CreatureGUID;

	public InteractWithNPC(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.CreatureGUID = base._worldPacket.ReadPackedGuid128();
	}
}
