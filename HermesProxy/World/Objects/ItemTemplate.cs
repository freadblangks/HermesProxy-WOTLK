using HermesProxy.Enums;

namespace HermesProxy.World.Objects;

public class ItemTemplate
{
	public uint Entry;

	public int Class;

	public uint SubClass;

	public int SoundOverrideSubclass;

	public string[] Name = new string[4];

	public uint DisplayID;

	public int Quality;

	public uint Flags;

	public uint FlagsExtra;

	public uint BuyCount;

	public uint BuyPrice;

	public uint SellPrice;

	public int InventoryType;

	public int AllowedClasses;

	public int AllowedRaces;

	public uint ItemLevel;

	public uint RequiredLevel;

	public uint RequiredSkillId;

	public uint RequiredSkillLevel;

	public uint RequiredSpell;

	public uint RequiredHonorRank;

	public uint RequiredCityRank;

	public uint RequiredRepFaction;

	public uint RequiredRepValue;

	public int MaxCount;

	public int MaxStackSize;

	public uint ContainerSlots;

	public uint StatsCount;

	public int[] StatTypes = new int[10];

	public int[] StatValues = new int[10];

	public int ScalingStatDistribution;

	public uint ScalingStatValue;

	public float[] DamageMins = new float[5];

	public float[] DamageMaxs = new float[5];

	public int[] DamageTypes = new int[5];

	public uint Armor;

	public uint HolyResistance;

	public uint FireResistance;

	public uint NatureResistance;

	public uint FrostResistance;

	public uint ShadowResistance;

	public uint ArcaneResistance;

	public uint Delay;

	public int AmmoType;

	public float RangedMod;

	public int[] TriggeredSpellIds = new int[5];

	public int[] TriggeredSpellTypes = new int[5];

	public int[] TriggeredSpellCharges = new int[5];

	public int[] TriggeredSpellCooldowns = new int[5];

	public uint[] TriggeredSpellCategories = new uint[5];

	public int[] TriggeredSpellCategoryCooldowns = new int[5];

	public int Bonding;

	public string Description;

	public uint PageText;

	public int Language;

	public int PageMaterial;

	public uint StartQuestId;

	public uint LockId;

	public int Material;

	public int SheathType;

	public int RandomProperty;

	public uint RandomSuffix;

	public uint Block;

	public uint ItemSet;

	public uint MaxDurability;

	public uint AreaID;

	public int MapID;

	public uint BagFamily;

	public int TotemCategory;

	public int[] ItemSocketColors = new int[3];

	public uint[] SocketContent = new uint[3];

	public int SocketBonus;

	public int GemProperties;

	public int RequiredDisenchantSkill;

	public float ArmorDamageModifier;

	public uint Duration;

	public int ItemLimitCategory;

	public int HolidayID;

	public void ReadFromLegacyPacket(uint entry, WorldPacket packet)
	{
		this.Entry = entry;
		this.Class = packet.ReadInt32();
		this.SubClass = packet.ReadUInt32();
		if (LegacyVersion.AddedInVersion(ClientVersionBuild.V2_0_3_6299))
		{
			this.SoundOverrideSubclass = packet.ReadInt32();
		}
		for (int i = 0; i < 4; i++)
		{
			this.Name[i] = packet.ReadCString();
		}
		this.DisplayID = packet.ReadUInt32();
		this.Quality = packet.ReadInt32();
		this.Flags = packet.ReadUInt32();
		if (LegacyVersion.AddedInVersion(ClientVersionBuild.V3_2_0_10192))
		{
			this.FlagsExtra = packet.ReadUInt32();
		}
		this.BuyPrice = packet.ReadUInt32();
		this.SellPrice = packet.ReadUInt32();
		this.InventoryType = packet.ReadInt32();
		this.AllowedClasses = packet.ReadInt32();
		this.AllowedRaces = packet.ReadInt32();
		this.ItemLevel = packet.ReadUInt32();
		this.RequiredLevel = packet.ReadUInt32();
		this.RequiredSkillId = packet.ReadUInt32();
		this.RequiredSkillLevel = packet.ReadUInt32();
		this.RequiredSpell = packet.ReadUInt32();
		this.RequiredHonorRank = packet.ReadUInt32();
		this.RequiredCityRank = packet.ReadUInt32();
		this.RequiredRepFaction = packet.ReadUInt32();
		this.RequiredRepValue = packet.ReadUInt32();
		this.MaxCount = packet.ReadInt32();
		this.MaxStackSize = packet.ReadInt32();
		this.ContainerSlots = packet.ReadUInt32();
		this.StatsCount = (LegacyVersion.AddedInVersion(ClientVersionBuild.V3_0_2_9056) ? packet.ReadUInt32() : 10u);
		if (this.StatsCount > 10)
		{
			this.StatTypes = new int[this.StatsCount];
			this.StatValues = new int[this.StatsCount];
		}
		for (int j = 0; j < this.StatsCount; j++)
		{
			this.StatTypes[j] = packet.ReadInt32();
			this.StatValues[j] = packet.ReadInt32();
		}
		if (LegacyVersion.AddedInVersion(ClientVersionBuild.V3_0_2_9056))
		{
			this.ScalingStatDistribution = packet.ReadInt32();
			this.ScalingStatValue = packet.ReadUInt32();
		}
		int dmgCount = (LegacyVersion.AddedInVersion(ClientVersionBuild.V3_1_0_9767) ? 2 : 5);
		for (int k = 0; k < dmgCount; k++)
		{
			this.DamageMins[k] = packet.ReadFloat();
			this.DamageMaxs[k] = packet.ReadFloat();
			this.DamageTypes[k] = packet.ReadInt32();
		}
		this.Armor = packet.ReadUInt32();
		this.HolyResistance = packet.ReadUInt32();
		this.FireResistance = packet.ReadUInt32();
		this.NatureResistance = packet.ReadUInt32();
		this.FrostResistance = packet.ReadUInt32();
		this.ShadowResistance = packet.ReadUInt32();
		this.ArcaneResistance = packet.ReadUInt32();
		this.Delay = packet.ReadUInt32();
		this.AmmoType = packet.ReadInt32();
		this.RangedMod = packet.ReadFloat();
		for (byte i2 = 0; i2 < 5; i2++)
		{
			this.TriggeredSpellIds[i2] = packet.ReadInt32();
			this.TriggeredSpellTypes[i2] = packet.ReadInt32();
			this.TriggeredSpellCharges[i2] = packet.ReadInt32();
			this.TriggeredSpellCooldowns[i2] = packet.ReadInt32();
			this.TriggeredSpellCategories[i2] = packet.ReadUInt32();
			this.TriggeredSpellCategoryCooldowns[i2] = packet.ReadInt32();
			if (this.TriggeredSpellIds[i2] != 0)
			{
				GameData.SaveItemEffectSlot(this.Entry, (uint)this.TriggeredSpellIds[i2], i2);
			}
		}
		this.Bonding = packet.ReadInt32();
		this.Description = packet.ReadCString();
		this.PageText = packet.ReadUInt32();
		this.Language = packet.ReadInt32();
		this.PageMaterial = packet.ReadInt32();
		this.StartQuestId = packet.ReadUInt32();
		this.LockId = packet.ReadUInt32();
		this.Material = packet.ReadInt32();
		if (this.Material < 0)
		{
			this.Material = 0;
		}
		this.SheathType = packet.ReadInt32();
		this.RandomProperty = packet.ReadInt32();
		if (LegacyVersion.AddedInVersion(ClientVersionBuild.V2_0_1_6180))
		{
			this.RandomSuffix = packet.ReadUInt32();
		}
		this.Block = packet.ReadUInt32();
		this.ItemSet = packet.ReadUInt32();
		this.MaxDurability = packet.ReadUInt32();
		this.AreaID = packet.ReadUInt32();
		this.MapID = packet.ReadInt32();
		this.BagFamily = packet.ReadUInt32();
		if (LegacyVersion.AddedInVersion(ClientVersionBuild.V2_0_1_6180))
		{
			this.TotemCategory = packet.ReadInt32();
			for (int l = 0; l < 3; l++)
			{
				this.ItemSocketColors[l] = packet.ReadInt32();
				this.SocketContent[l] = packet.ReadUInt32();
			}
			this.SocketBonus = packet.ReadInt32();
			this.GemProperties = packet.ReadInt32();
			this.RequiredDisenchantSkill = packet.ReadInt32();
			this.ArmorDamageModifier = packet.ReadFloat();
		}
		if (LegacyVersion.AddedInVersion(ClientVersionBuild.V2_4_2_8209))
		{
			this.Duration = packet.ReadUInt32();
		}
		if (LegacyVersion.AddedInVersion(ClientVersionBuild.V3_0_2_9056))
		{
			this.ItemLimitCategory = packet.ReadInt32();
		}
		if (LegacyVersion.AddedInVersion(ClientVersionBuild.V3_1_0_9767))
		{
			this.HolidayID = packet.ReadInt32();
		}
	}
}
