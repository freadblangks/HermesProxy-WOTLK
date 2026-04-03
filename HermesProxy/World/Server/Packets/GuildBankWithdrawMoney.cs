namespace HermesProxy.World.Server.Packets;

public class GuildBankWithdrawMoney : ClientPacket
{
	public WowGuid128 BankGuid;

	public ulong Money;

	public GuildBankWithdrawMoney(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.BankGuid = base._worldPacket.ReadPackedGuid128();
		this.Money = base._worldPacket.ReadUInt64();
	}
}
