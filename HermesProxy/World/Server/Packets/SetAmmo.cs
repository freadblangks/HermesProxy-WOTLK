namespace HermesProxy.World.Server.Packets;

public class SetAmmo : ClientPacket
{
	public uint ItemId;

	public SetAmmo(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.ItemId = base._worldPacket.ReadUInt32();
	}
}
