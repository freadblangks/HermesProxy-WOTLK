namespace HermesProxy.World.Server.Packets;

public class SetContactNotes : ClientPacket
{
	public uint VirtualRealmAddress;

	public WowGuid128 Guid;

	public string Notes;

	public SetContactNotes(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.VirtualRealmAddress = base._worldPacket.ReadUInt32();
		this.Guid = base._worldPacket.ReadPackedGuid128();
		this.Notes = base._worldPacket.ReadString(base._worldPacket.ReadBits<uint>(10));
	}
}
