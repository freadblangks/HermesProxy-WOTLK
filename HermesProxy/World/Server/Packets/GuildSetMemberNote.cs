namespace HermesProxy.World.Server.Packets;

public class GuildSetMemberNote : ClientPacket
{
	public WowGuid128 NoteeGUID;

	public bool IsPublic;

	public string Note;

	public GuildSetMemberNote(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.NoteeGUID = base._worldPacket.ReadPackedGuid128();
		uint noteLen = base._worldPacket.ReadBits<uint>(8);
		this.IsPublic = base._worldPacket.HasBit();
		this.Note = base._worldPacket.ReadString(noteLen);
	}
}
