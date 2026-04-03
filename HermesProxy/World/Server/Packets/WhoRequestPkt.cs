using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class WhoRequestPkt : ClientPacket
{
	public WhoRequest Request = new WhoRequest();

	public uint RequestID;

	public List<int> Areas = new List<int>();

	public WhoRequestPkt(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint areasCount = base._worldPacket.ReadBits<uint>(4);
		this.Request.Read(base._worldPacket);
		this.RequestID = base._worldPacket.ReadUInt32();
		for (int i = 0; i < areasCount; i++)
		{
			this.Areas.Add(base._worldPacket.ReadInt32());
		}
	}
}
