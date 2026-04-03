namespace HermesProxy.World.Server.Packets;

public class PetitionRenameGuild : ClientPacket
{
	public WowGuid128 PetitionGuid;

	public string NewGuildName;

	public PetitionRenameGuild(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.PetitionGuid = base._worldPacket.ReadPackedGuid128();
		base._worldPacket.ResetBitPos();
		uint nameLen = base._worldPacket.ReadBits<uint>(7);
		this.NewGuildName = base._worldPacket.ReadString(nameLen);
	}
}
