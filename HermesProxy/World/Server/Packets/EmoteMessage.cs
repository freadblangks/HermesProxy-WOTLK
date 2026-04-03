using System.Collections.Generic;
using Framework.Constants;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class EmoteMessage : ServerPacket
{
	public WowGuid128 Guid;

	public uint EmoteID;

	public int SequenceVariation;

	public List<uint> SpellVisualKitIDs = new List<uint>();

	public EmoteMessage()
		: base(Opcode.SMSG_EMOTE, ConnectionType.Instance)
	{
	}

	public override void Write()
	{
		base._worldPacket.WritePackedGuid128(this.Guid);
		base._worldPacket.WriteUInt32(this.EmoteID);
		if (!ModernVersion.AddedInVersion(9, 0, 5, 1, 14, 0, 2, 5, 1))
		{
			return;
		}
		base._worldPacket.WriteInt32(this.SpellVisualKitIDs.Count);
		if (ModernVersion.AddedInVersion(9, 2, 0, 1, 14, 2, 2, 5, 3))
		{
			base._worldPacket.WriteInt32(this.SequenceVariation);
		}
		foreach (uint id in this.SpellVisualKitIDs)
		{
			base._worldPacket.WriteUInt32(id);
		}
	}
}
