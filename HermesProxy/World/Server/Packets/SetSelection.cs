namespace HermesProxy.World.Server.Packets;

public class SetSelection : ClientPacket
{
	public WowGuid128 TargetGUID;

	public SetSelection(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.TargetGUID = base._worldPacket.ReadPackedGuid128();
	}
}
