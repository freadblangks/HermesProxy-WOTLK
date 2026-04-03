using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class RuneData
{
	public byte Start;

	public byte Count;

	public List<byte> Cooldowns = new List<byte>();

	public void Write(WorldPacket data)
	{
		data.WriteUInt8(this.Start);
		data.WriteUInt8(this.Count);
		data.WriteInt32(this.Cooldowns.Count);
		foreach (byte cd in this.Cooldowns)
		{
			data.WriteUInt8(cd);
		}
	}
}
