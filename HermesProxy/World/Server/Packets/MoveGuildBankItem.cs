namespace HermesProxy.World.Server.Packets;

internal class MoveGuildBankItem : ClientPacket
{
	public WowGuid128 BankGuid;

	public byte BankTab1;

	public byte BankSlot1;

	public byte BankTab2;

	public byte BankSlot2;

	public MoveGuildBankItem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.BankGuid = base._worldPacket.ReadPackedGuid128();
		this.BankTab1 = base._worldPacket.ReadUInt8();
		this.BankSlot1 = base._worldPacket.ReadUInt8();
		this.BankTab2 = base._worldPacket.ReadUInt8();
		this.BankSlot2 = base._worldPacket.ReadUInt8();
	}
}
