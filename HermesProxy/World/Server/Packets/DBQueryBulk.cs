using System.Collections.Generic;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class DBQueryBulk : ClientPacket
{
	public DB2Hash TableHash;

	public List<uint> Queries = new List<uint>();

	public DBQueryBulk(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.TableHash = (DB2Hash)base._worldPacket.ReadUInt32();
		uint count = base._worldPacket.ReadBits<uint>(13);
		for (uint i = 0u; i < count; i++)
		{
			this.Queries.Add(base._worldPacket.ReadUInt32());
		}
	}
}
