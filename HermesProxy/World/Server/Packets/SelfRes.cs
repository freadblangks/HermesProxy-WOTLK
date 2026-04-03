namespace HermesProxy.World.Server.Packets;

internal class SelfRes : ClientPacket
{
	public uint SpellId;

	public SelfRes(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.SpellId = base._worldPacket.ReadUInt32();
	}
}
