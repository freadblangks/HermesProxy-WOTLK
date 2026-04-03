namespace HermesProxy.World.Server.Packets;

internal class PlayerShowingHelmOrCloak : ClientPacket
{
	public bool Showing;

	public PlayerShowingHelmOrCloak(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		base._worldPacket.ResetBitPos();
		this.Showing = base._worldPacket.HasBit();
	}
}
