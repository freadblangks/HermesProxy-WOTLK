using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class TutorialSetFlag : ClientPacket
{
	public TutorialAction Action;

	public uint TutorialBit;

	public TutorialSetFlag(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Action = (TutorialAction)base._worldPacket.ReadBits<byte>(2);
		if (this.Action == TutorialAction.Update)
		{
			this.TutorialBit = base._worldPacket.ReadUInt32();
		}
	}
}
