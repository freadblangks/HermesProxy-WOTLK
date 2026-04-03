namespace HermesProxy.World.Server.Packets;

public class GuildBankQueryTab : ClientPacket
{
	public WowGuid128 BankGuid;

	public byte Tab;

	public bool FullUpdate;

	public GuildBankQueryTab(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.BankGuid = base._worldPacket.ReadPackedGuid128();
		this.Tab = base._worldPacket.ReadUInt8();
		this.FullUpdate = base._worldPacket.HasBit();
	}
}
