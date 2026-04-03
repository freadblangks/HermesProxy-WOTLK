namespace HermesProxy.World.Server.Packets;

internal class BattlenetRequest : ClientPacket
{
	public MethodCall Method;

	public byte[] Data;

	public BattlenetRequest(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Method.Read(base._worldPacket);
		uint protoSize = base._worldPacket.ReadUInt32();
		this.Data = base._worldPacket.ReadBytes(protoSize);
	}
}
