namespace HermesProxy.World.Server.Packets;

public class CharacterRenameRequest : ClientPacket
{
	public string NewName;

	public WowGuid128 Guid;

	public CharacterRenameRequest(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Guid = base._worldPacket.ReadPackedGuid128();
		this.NewName = base._worldPacket.ReadString(base._worldPacket.ReadBits<uint>(6));
	}
}
