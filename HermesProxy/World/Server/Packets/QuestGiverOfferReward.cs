using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class QuestGiverOfferReward
{
	public WowGuid128 QuestGiverGUID;

	public uint QuestGiverCreatureID = 0u;

	public uint QuestID = 0u;

	public bool AutoLaunched = false;

	public uint SuggestedPartyMembers = 0u;

	public QuestRewards Rewards = new QuestRewards();

	public List<QuestDescEmote> Emotes = new List<QuestDescEmote>();

	public uint[] QuestFlags = new uint[3];

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.QuestGiverGUID);
		if (ModernVersion.ExpansionVersion >= 3)
		{
			data.WriteInt32((int)this.QuestGiverCreatureID);
		}
		data.WriteUInt32(this.QuestID);
		data.WriteUInt32(this.QuestFlags[0]);
		data.WriteUInt32(this.QuestFlags[1]);
		if (ModernVersion.ExpansionVersion >= 3)
		{
			data.WriteUInt32((this.QuestFlags.Length > 2) ? this.QuestFlags[2] : 0u);
		}
		data.WriteUInt32(this.SuggestedPartyMembers);
		data.WriteInt32(this.Emotes.Count);
		foreach (QuestDescEmote emote in this.Emotes)
		{
			data.WriteInt32((int)emote.Type);
			data.WriteUInt32(emote.Delay);
		}
		data.WriteBit(this.AutoLaunched);
		data.WriteBit(bit: false);
		data.FlushBits();
		this.Rewards.Write(data);
	}
}
