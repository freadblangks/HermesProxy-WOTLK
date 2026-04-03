namespace HermesProxy.World.Server.Packets;

public class DelFriend : ClientPacket
{
	public uint VirtualRealmAddress;

	public WowGuid128 Guid;

	public DelFriend(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.VirtualRealmAddress = base._worldPacket.ReadUInt32();
		this.Guid = base._worldPacket.ReadPackedGuid128();
	}
}
