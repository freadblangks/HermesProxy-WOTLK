using HermesProxy.World.Objects;

namespace HermesProxy.World.Server.Packets;

public class SpellClick : ClientPacket
{
	public WowGuid128 SpellClickUnitGuid;
	public bool TryAutoDismount;

	public SpellClick(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.SpellClickUnitGuid = base._worldPacket.ReadPackedGuid128();
		this.TryAutoDismount = base._worldPacket.ReadBit();
	}
}
