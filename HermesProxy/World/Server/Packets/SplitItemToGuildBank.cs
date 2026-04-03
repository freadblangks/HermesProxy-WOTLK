namespace HermesProxy.World.Server.Packets;

internal class SplitItemToGuildBank : ClientPacket
{
	public WowGuid128 BankGuid;

	public byte BankTab;

	public byte BankSlot;

	public byte? ContainerSlot;

	public byte ContainerItemSlot;

	public uint StackCount;

	public SplitItemToGuildBank(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.BankGuid = base._worldPacket.ReadPackedGuid128();
		this.BankTab = base._worldPacket.ReadUInt8();
		this.BankSlot = base._worldPacket.ReadUInt8();
		this.ContainerItemSlot = base._worldPacket.ReadUInt8();
		this.StackCount = base._worldPacket.ReadUInt32();
		if (base._worldPacket.HasBit())
		{
			this.ContainerSlot = base._worldPacket.ReadUInt8();
		}
	}
}
