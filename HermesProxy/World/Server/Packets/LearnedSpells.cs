using System.Collections.Generic;
using Framework.Constants;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class LearnedSpells : ServerPacket
{
	public List<uint> Spells = new List<uint>();

	public List<int> FavoriteSpellID = new List<int>();

	public uint SpecializationID;

	public bool SuppressMessaging;

	public LearnedSpells()
		: base(Opcode.SMSG_LEARNED_SPELLS, ConnectionType.Instance)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteInt32(this.Spells.Count);
		base._worldPacket.WriteInt32(this.FavoriteSpellID.Count);
		base._worldPacket.WriteUInt32(this.SpecializationID);
		foreach (uint spell in this.Spells)
		{
			base._worldPacket.WriteUInt32(spell);
		}
		foreach (int spell2 in this.FavoriteSpellID)
		{
			base._worldPacket.WriteInt32(spell2);
		}
		base._worldPacket.WriteBit(this.SuppressMessaging);
		base._worldPacket.FlushBits();
	}
}
