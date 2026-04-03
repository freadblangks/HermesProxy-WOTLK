using Framework.Constants;

namespace HermesProxy.World.Server.Packets;

internal class ConnectToFailed : ClientPacket
{
	public ConnectToSerial Serial;

	private byte Con;

	public ConnectToFailed(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Serial = (ConnectToSerial)base._worldPacket.ReadUInt32();
		this.Con = base._worldPacket.ReadUInt8();
	}
}
