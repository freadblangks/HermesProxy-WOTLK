namespace HermesProxy.World.Server.Packets;

public class QueryPageText : ClientPacket
{
	public WowGuid128 ItemGUID;

	public uint PageTextID;

	public QueryPageText(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PageTextID = base._worldPacket.ReadUInt32();
		this.ItemGUID = base._worldPacket.ReadPackedGuid128();
	}
}
