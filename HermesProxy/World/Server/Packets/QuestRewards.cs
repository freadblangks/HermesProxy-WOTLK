namespace HermesProxy.World.Server.Packets;

public class QuestRewards
{
	public uint ChoiceItemCount;

	public uint ItemCount;

	public uint Money;

	public uint XP;

	public uint ArtifactXP;

	public uint ArtifactCategoryID;

	public uint Honor;

	public uint Title;

	public uint FactionFlags;

	public int[] SpellCompletionDisplayID = new int[3];

	public uint SpellCompletionID;

	public uint SkillLineID;

	public uint NumSkillUps;

	public uint TreasurePickerID;

	public QuestChoiceItem[] ChoiceItems = new QuestChoiceItem[6];

	public uint[] ItemID = new uint[4];

	public uint[] ItemQty = new uint[4];

	public uint[] FactionID = new uint[5];

	public int[] FactionValue = new int[5];

	public int[] FactionOverride = new int[5];

	public int[] FactionCapIn = new int[5];

	public uint[] CurrencyID = new uint[4];

	public uint[] CurrencyQty = new uint[4];

	public bool IsBoostSpell;

	public QuestRewards()
	{
		for (int i = 0; i < 6; i++)
		{
			this.ChoiceItems[i] = new QuestChoiceItem();
		}
	}

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.ChoiceItemCount);
		data.WriteUInt32(this.ItemCount);
		for (int i = 0; i < 4; i++)
		{
			data.WriteUInt32(this.ItemID[i]);
			data.WriteUInt32(this.ItemQty[i]);
		}
		data.WriteUInt32(this.Money);
		data.WriteUInt32(this.XP);
		data.WriteUInt64(this.ArtifactXP);
		data.WriteUInt32(this.ArtifactCategoryID);
		data.WriteUInt32(this.Honor);
		data.WriteUInt32(this.Title);
		data.WriteUInt32(this.FactionFlags);
		for (int j = 0; j < 5; j++)
		{
			data.WriteUInt32(this.FactionID[j]);
			data.WriteInt32(this.FactionValue[j]);
			data.WriteInt32(this.FactionOverride[j]);
			data.WriteInt32(this.FactionCapIn[j]);
		}
		int[] spellCompletionDisplayID = this.SpellCompletionDisplayID;
		foreach (int id in spellCompletionDisplayID)
		{
			data.WriteInt32(id);
		}
		data.WriteUInt32(this.SpellCompletionID);
		for (int l = 0; l < 4; l++)
		{
			data.WriteUInt32(this.CurrencyID[l]);
			data.WriteUInt32(this.CurrencyQty[l]);
		}
		data.WriteUInt32(this.SkillLineID);
		data.WriteUInt32(this.NumSkillUps);
		data.WriteUInt32(this.TreasurePickerID);
		QuestChoiceItem[] choiceItems = this.ChoiceItems;
		foreach (QuestChoiceItem choice in choiceItems)
		{
			choice.Write(data);
		}
		data.WriteBit(this.IsBoostSpell);
		data.FlushBits();
	}
}
