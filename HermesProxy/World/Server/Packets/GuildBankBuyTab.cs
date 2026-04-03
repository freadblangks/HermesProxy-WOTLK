namespace HermesProxy.World.Server.Packets;

public class GuildBankBuyTab : ClientPacket
{
	public WowGuid128 BankGuid;

	public byte BankTab;

	public GuildBankBuyTab(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.BankGuid = base._worldPacket.ReadPackedGuid128();
		this.BankTab = base._worldPacket.ReadUInt8();
	}
}
