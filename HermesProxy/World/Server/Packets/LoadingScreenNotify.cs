namespace HermesProxy.World.Server.Packets;

public class LoadingScreenNotify : ClientPacket
{
	public uint MapID;

	public bool Showing;

	public LoadingScreenNotify(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.MapID = base._worldPacket.ReadUInt32();
		this.Showing = base._worldPacket.HasBit();
	}
}
