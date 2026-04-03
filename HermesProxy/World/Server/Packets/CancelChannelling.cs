namespace HermesProxy.World.Server.Packets;

internal class CancelChannelling : ClientPacket
{
	public int SpellID;

	public int Reason;

	public CancelChannelling(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.SpellID = base._worldPacket.ReadInt32();
		this.Reason = base._worldPacket.ReadInt32();
	}
}
