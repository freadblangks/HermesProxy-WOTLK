namespace HermesProxy.World.Server.Packets;

public class GameObjReportUse : ClientPacket
{
	public WowGuid128 Guid;

	public GameObjReportUse(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Guid = base._worldPacket.ReadPackedGuid128();
	}
}
