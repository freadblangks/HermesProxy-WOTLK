namespace HermesProxy.World.Server.Packets;

internal class SetWatchedFaction : ClientPacket
{
	public uint FactionIndex;

	public SetWatchedFaction(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.FactionIndex = base._worldPacket.ReadUInt32();
	}
}
