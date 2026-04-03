namespace HermesProxy.World.Server.Packets;

internal class SetFactionInactive : ClientPacket
{
	public uint FactionIndex;

	public bool State;

	public SetFactionInactive(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.FactionIndex = base._worldPacket.ReadUInt32();
		this.State = base._worldPacket.HasBit();
	}
}
