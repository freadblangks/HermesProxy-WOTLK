namespace HermesProxy.World.Server.Packets;

public class GuildBankUpdateTab : ClientPacket
{
	public WowGuid128 BankGuid;

	public byte BankTab;

	public string Name;

	public string Icon;

	public GuildBankUpdateTab(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.BankGuid = base._worldPacket.ReadPackedGuid128();
		this.BankTab = base._worldPacket.ReadUInt8();
		base._worldPacket.ResetBitPos();
		uint nameLen = base._worldPacket.ReadBits<uint>(7);
		uint iconLen = base._worldPacket.ReadBits<uint>(9);
		this.Name = base._worldPacket.ReadString(nameLen);
		this.Icon = base._worldPacket.ReadString(iconLen);
	}
}
