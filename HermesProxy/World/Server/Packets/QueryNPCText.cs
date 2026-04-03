namespace HermesProxy.World.Server.Packets;

public class QueryNPCText : ClientPacket
{
	public WowGuid128 Guid;

	public uint TextID;

	public QueryNPCText(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.TextID = base._worldPacket.ReadUInt32();
		this.Guid = base._worldPacket.ReadPackedGuid128();
	}
}
