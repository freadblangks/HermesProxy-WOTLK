namespace HermesProxy.World.Server.Packets;

public class GuildBankAtivate : ClientPacket
{
	public WowGuid128 BankGuid;

	public bool FullUpdate;

	public GuildBankAtivate(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.BankGuid = base._worldPacket.ReadPackedGuid128();
		this.FullUpdate = base._worldPacket.HasBit();
	}
}
