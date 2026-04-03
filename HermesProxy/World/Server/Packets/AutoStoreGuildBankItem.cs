namespace HermesProxy.World.Server.Packets;

internal class AutoStoreGuildBankItem : ClientPacket
{
	public WowGuid128 BankGuid;

	public byte BankTab;

	public byte BankSlot;

	public AutoStoreGuildBankItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.BankGuid = base._worldPacket.ReadPackedGuid128();
		this.BankTab = base._worldPacket.ReadUInt8();
		this.BankSlot = base._worldPacket.ReadUInt8();
	}
}
