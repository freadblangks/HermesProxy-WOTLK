using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

internal class ChatRegisterAddonPrefixes : ClientPacket
{
	public List<string> Prefixes = new List<string>();

	public ChatRegisterAddonPrefixes(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		int count = base._worldPacket.ReadInt32();
		for (int i = 0; i < count && i < 64; i++)
		{
			this.Prefixes.Add(base._worldPacket.ReadString(base._worldPacket.ReadBits<uint>(5)));
		}
	}
}
