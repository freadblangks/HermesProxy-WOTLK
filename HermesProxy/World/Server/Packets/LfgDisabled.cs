using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class LfgDisabled : ServerPacket
{
	public LfgDisabled()
		: base(Opcode.SMSG_LFG_DISABLED)
	{
	}

	public override void Write()
	{
	}
}
