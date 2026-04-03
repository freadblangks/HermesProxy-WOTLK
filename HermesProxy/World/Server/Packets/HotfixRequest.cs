using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

internal class HotfixRequest : ClientPacket
{
	public uint ClientBuild;

	public uint DataBuild;

	public List<uint> Hotfixes = new List<uint>();

	public HotfixRequest(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.ClientBuild = base._worldPacket.ReadUInt32();
		this.DataBuild = base._worldPacket.ReadUInt32();
		uint hotfixCount = base._worldPacket.ReadUInt32();
		for (int i = 0; i < hotfixCount; i++)
		{
			this.Hotfixes.Add(base._worldPacket.ReadUInt32());
		}
	}
}
