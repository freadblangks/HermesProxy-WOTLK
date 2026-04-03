using System.Collections.Generic;
using Framework.Constants;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class SpecialMountAnim : ServerPacket
{
	public WowGuid128 UnitGUID;

	public List<int> SpellVisualKitIDs = new List<int>();

	public int SequenceVariation;

	public SpecialMountAnim()
		: base(Opcode.SMSG_SPECIAL_MOUNT_ANIM, ConnectionType.Instance)
	{
	}

	public override void Write()
	{
		base._worldPacket.WritePackedGuid128(this.UnitGUID);
		if (!ModernVersion.AddedInVersion(9, 0, 5, 1, 14, 0, 2, 5, 1))
		{
			return;
		}
		base._worldPacket.WriteInt32(this.SpellVisualKitIDs.Count);
		if (ModernVersion.AddedInVersion(9, 2, 0, 1, 14, 2, 2, 5, 3))
		{
			base._worldPacket.WriteInt32(this.SequenceVariation);
		}
		foreach (int id in this.SpellVisualKitIDs)
		{
			base._worldPacket.WriteInt32(id);
		}
	}
}
