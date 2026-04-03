namespace HermesProxy.World.Server.Packets;

public class RandomRollClient : ClientPacket
{
	public int Min;

	public int Max;

	public byte PartyIndex;

	public RandomRollClient(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Min = base._worldPacket.ReadInt32();
		this.Max = base._worldPacket.ReadInt32();
		this.PartyIndex = base._worldPacket.ReadUInt8();
	}
}
