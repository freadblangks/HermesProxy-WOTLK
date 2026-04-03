using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class SpellModifierInfo
{
	public byte ModIndex;

	public List<SpellModifierData> ModifierData = new List<SpellModifierData>();

	public void Write(WorldPacket data)
	{
		data.WriteUInt8(this.ModIndex);
		data.WriteInt32(this.ModifierData.Count);
		foreach (SpellModifierData modifierDatum in this.ModifierData)
		{
			modifierDatum.Write(data);
		}
	}
}
