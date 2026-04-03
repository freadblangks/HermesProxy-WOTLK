using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class QueryPlayerNames : ClientPacket
{
	public List<WowGuid128> Players = new List<WowGuid128>();

	public QueryPlayerNames(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint count = base._worldPacket.ReadUInt32();
		for (uint i = 0u; i < count; i++)
		{
			this.Players.Add(base._worldPacket.ReadPackedGuid128());
		}
	}
}
