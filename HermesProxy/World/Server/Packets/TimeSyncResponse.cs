namespace HermesProxy.World.Server.Packets;

public class TimeSyncResponse : ClientPacket
{
	public uint ClientTime;

	public uint SequenceIndex;

	public TimeSyncResponse(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.SequenceIndex = base._worldPacket.ReadUInt32();
		this.ClientTime = base._worldPacket.ReadUInt32();
	}
}
