namespace HermesProxy.World.Server.Packets;

public class SetSheathed : ClientPacket
{
	public int SheathState;

	public bool Animate = true;

	public SetSheathed(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.SheathState = base._worldPacket.ReadInt32();
		this.Animate = base._worldPacket.HasBit();
	}
}
