using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class ConfirmRespecWipe : ClientPacket
{
	public WowGuid128 TrainerGUID;

	public SpecResetType RespecType;

	public ConfirmRespecWipe(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.TrainerGUID = base._worldPacket.ReadPackedGuid128();
		this.RespecType = (SpecResetType)base._worldPacket.ReadUInt8();
	}
}
