using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class PartyMemberAuraStates
{
	public uint SpellId;

	public ushort AuraFlags;

	public uint ActiveFlags;

	public List<float> Points = new List<float>();

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.SpellId);
		data.WriteUInt16(this.AuraFlags);
		data.WriteUInt32(this.ActiveFlags);
		data.WriteInt32(this.Points.Count);
		foreach (float point in this.Points)
		{
			data.WriteFloat(point);
		}
	}
}
