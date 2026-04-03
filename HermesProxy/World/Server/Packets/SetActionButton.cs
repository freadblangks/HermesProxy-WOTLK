namespace HermesProxy.World.Server.Packets;

public class SetActionButton : ClientPacket
{
	public ushort Action;

	public ushort Type;

	public byte Index;

	public SetActionButton(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Action = base._worldPacket.ReadUInt16();
		this.Type = base._worldPacket.ReadUInt16();
		this.Index = base._worldPacket.ReadUInt8();
	}
}
