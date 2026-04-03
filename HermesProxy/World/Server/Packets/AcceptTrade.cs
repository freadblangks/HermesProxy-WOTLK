namespace HermesProxy.World.Server.Packets;

public class AcceptTrade : ClientPacket
{
	public uint StateIndex;

	public AcceptTrade(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.StateIndex = base._worldPacket.ReadUInt32();
	}
}
