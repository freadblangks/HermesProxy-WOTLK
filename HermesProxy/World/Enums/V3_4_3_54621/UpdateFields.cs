using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesProxy.World.Enums.V3_4_3_54621
{
    // ReSharper disable InconsistentNaming
    // WotLK Classic 3.4.3.54621
    // TODO: Field offsets below are copied from TBC Classic 2.5.3 as a starting point.
    // They must be verified/updated via packet sniffing against the 3.4.3 client.
    // WotLK Classic adds: vehicle fields, achievement fields, glyph slots, additional talent
    // fields, and additional aura slots compared to TBC Classic.

    public enum ObjectField
    {
        OBJECT_FIELD_GUID                                           = 0x000, // Size: 4, Flags: PUBLIC
        OBJECT_FIELD_ENTRY                                          = 0x004, // Size: 1, Flags: DYNAMIC
        OBJECT_DYNAMIC_FLAGS                                        = 0x005, // Size: 1, Flags: DYNAMIC, URGENT
        OBJECT_FIELD_SCALE_X                                        = 0x006, // Size: 1, Flags: PUBLIC
        OBJECT_END                                                  = 0x007,
    }

    public enum ObjectDynamicField
    {
        OBJECT_DYNAMIC_END                                          = 0x000,
    }

    public enum ItemField
    {
        ITEM_FIELD_OWNER                                            = ObjectField.OBJECT_END + 0x000, // Size: 4, Flags: PUBLIC
        ITEM_FIELD_CONTAINED                                        = ObjectField.OBJECT_END + 0x004, // Size: 4, Flags: PUBLIC
        ITEM_FIELD_CREATOR                                          = ObjectField.OBJECT_END + 0x008, // Size: 4, Flags: PUBLIC
        ITEM_FIELD_GIFTCREATOR                                      = ObjectField.OBJECT_END + 0x00C, // Size: 4, Flags: PUBLIC
        ITEM_FIELD_STACK_COUNT                                      = ObjectField.OBJECT_END + 0x010, // Size: 1, Flags: OWNER
        ITEM_FIELD_DURATION                                         = ObjectField.OBJECT_END + 0x011, // Size: 1, Flags: OWNER
        ITEM_FIELD_SPELL_CHARGES                                    = ObjectField.OBJECT_END + 0x012, // Size: 5, Flags: OWNER
        ITEM_FIELD_FLAGS                                            = ObjectField.OBJECT_END + 0x017, // Size: 1, Flags: PUBLIC
        ITEM_FIELD_ENCHANTMENT                                      = ObjectField.OBJECT_END + 0x018, // Size: 39, Flags: PUBLIC
        ITEM_FIELD_PROPERTY_SEED                                    = ObjectField.OBJECT_END + 0x03F, // Size: 1, Flags: PUBLIC
        ITEM_FIELD_RANDOM_PROPERTIES_ID                             = ObjectField.OBJECT_END + 0x040, // Size: 1, Flags: PUBLIC
        ITEM_FIELD_DURABILITY                                       = ObjectField.OBJECT_END + 0x041, // Size: 1, Flags: OWNER
        ITEM_FIELD_MAXDURABILITY                                    = ObjectField.OBJECT_END + 0x042, // Size: 1, Flags: OWNER
        ITEM_FIELD_CREATE_PLAYED_TIME                               = ObjectField.OBJECT_END + 0x043, // Size: 1, Flags: PUBLIC
        ITEM_END                                                    = ObjectField.OBJECT_END + 0x044,
    }

    public enum ItemDynamicField
    {
        ITEM_DYNAMIC_END                                            = 0x000,
    }

    public enum ContainerField
    {
        CONTAINER_FIELD_NUM_SLOTS                                   = ItemField.ITEM_END + 0x000, // Size: 1, Flags: PUBLIC
        CONTAINER_ALIGN_PAD                                         = ItemField.ITEM_END + 0x001, // Size: 1, Flags: PUBLIC
        CONTAINER_FIELD_SLOT_1                                      = ItemField.ITEM_END + 0x002, // Size: 72, Flags: PUBLIC
        CONTAINER_END                                               = ItemField.ITEM_END + 0x04A,
    }

    public enum ContainerDynamicField
    {
        CONTAINER_DYNAMIC_END                                       = 0x000,
    }

    public enum AzeriteEmpoweredItemField
    {
        AZERITE_EMPOWERED_ITEM_END                                  = ItemField.ITEM_END + 0x000,
    }

    public enum AzeriteEmpoweredItemDynamicField
    {
        AZERITE_EMPOWERED_ITEM_DYNAMIC_END                          = 0x000,
    }

    public enum AzeriteItemField
    {
        AZERITE_ITEM_END                                            = ItemField.ITEM_END + 0x000,
    }

    public enum AzeriteItemDynamicField
    {
        AZERITE_ITEM_DYNAMIC_END                                    = 0x000,
    }

    public enum UnitField
    {
        UNIT_FIELD_CHARM                                            = ObjectField.OBJECT_END + 0x000, // Size: 4, Flags: PUBLIC
        UNIT_FIELD_SUMMON                                           = ObjectField.OBJECT_END + 0x004, // Size: 4, Flags: PUBLIC
        UNIT_FIELD_CRITTER                                          = ObjectField.OBJECT_END + 0x008, // Size: 4, Flags: PRIVATE
        UNIT_FIELD_CHARMEDBY                                        = ObjectField.OBJECT_END + 0x00C, // Size: 4, Flags: PUBLIC
        UNIT_FIELD_SUMMONEDBY                                       = ObjectField.OBJECT_END + 0x010, // Size: 4, Flags: PUBLIC
        UNIT_FIELD_CREATEDBY                                        = ObjectField.OBJECT_END + 0x014, // Size: 4, Flags: PUBLIC
        UNIT_FIELD_TARGET                                           = ObjectField.OBJECT_END + 0x018, // Size: 4, Flags: PUBLIC
        UNIT_FIELD_CHANNEL_OBJECT                                   = ObjectField.OBJECT_END + 0x01C, // Size: 4, Flags: PUBLIC
        UNIT_CHANNEL_SPELL                                          = ObjectField.OBJECT_END + 0x020, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_BYTES_0                                          = ObjectField.OBJECT_END + 0x021, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_HEALTH                                           = ObjectField.OBJECT_END + 0x022, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_POWER1                                           = ObjectField.OBJECT_END + 0x023, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_POWER2                                           = ObjectField.OBJECT_END + 0x024, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_POWER3                                           = ObjectField.OBJECT_END + 0x025, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_POWER4                                           = ObjectField.OBJECT_END + 0x026, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_POWER5                                           = ObjectField.OBJECT_END + 0x027, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_POWER6                                           = ObjectField.OBJECT_END + 0x028, // Size: 1, Flags: PUBLIC (runic power)
        UNIT_FIELD_POWER7                                           = ObjectField.OBJECT_END + 0x029, // Size: 1, Flags: PUBLIC (runes)
        UNIT_FIELD_MAXHEALTH                                        = ObjectField.OBJECT_END + 0x02A, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_MAXPOWER1                                        = ObjectField.OBJECT_END + 0x02B, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_MAXPOWER2                                        = ObjectField.OBJECT_END + 0x02C, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_MAXPOWER3                                        = ObjectField.OBJECT_END + 0x02D, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_MAXPOWER4                                        = ObjectField.OBJECT_END + 0x02E, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_MAXPOWER5                                        = ObjectField.OBJECT_END + 0x02F, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_MAXPOWER6                                        = ObjectField.OBJECT_END + 0x030, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_MAXPOWER7                                        = ObjectField.OBJECT_END + 0x031, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER                        = ObjectField.OBJECT_END + 0x032, // Size: 7, Flags: PRIVATE
        UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER            = ObjectField.OBJECT_END + 0x039, // Size: 7, Flags: PRIVATE
        UNIT_FIELD_LEVEL                                            = ObjectField.OBJECT_END + 0x040, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_FACTIONTEMPLATE                                  = ObjectField.OBJECT_END + 0x041, // Size: 1, Flags: PUBLIC
        UNIT_VIRTUAL_ITEM_SLOT_ID                                   = ObjectField.OBJECT_END + 0x042, // Size: 3, Flags: PUBLIC
        UNIT_FIELD_FLAGS                                            = ObjectField.OBJECT_END + 0x045, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_FLAGS_2                                          = ObjectField.OBJECT_END + 0x046, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_AURASTATE                                        = ObjectField.OBJECT_END + 0x047, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_BASEATTACKTIME                                   = ObjectField.OBJECT_END + 0x048, // Size: 2, Flags: PUBLIC
        UNIT_FIELD_RANGEDATTACKTIME                                 = ObjectField.OBJECT_END + 0x04A, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_BOUNDINGRADIUS                                   = ObjectField.OBJECT_END + 0x04B, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_COMBATREACH                                      = ObjectField.OBJECT_END + 0x04C, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_DISPLAYID                                        = ObjectField.OBJECT_END + 0x04D, // Size: 1, Flags: DYNAMIC
        UNIT_FIELD_NATIVEDISPLAYID                                  = ObjectField.OBJECT_END + 0x04E, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_MOUNTDISPLAYID                                   = ObjectField.OBJECT_END + 0x04F, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_MINDAMAGE                                        = ObjectField.OBJECT_END + 0x050, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_MAXDAMAGE                                        = ObjectField.OBJECT_END + 0x051, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_MINOFFHANDDAMAGE                                 = ObjectField.OBJECT_END + 0x052, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_MAXOFFHANDDAMAGE                                 = ObjectField.OBJECT_END + 0x053, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_BYTES_1                                          = ObjectField.OBJECT_END + 0x054, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_PETNUMBER                                        = ObjectField.OBJECT_END + 0x055, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_PET_NAME_TIMESTAMP                               = ObjectField.OBJECT_END + 0x056, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_PETEXPERIENCE                                    = ObjectField.OBJECT_END + 0x057, // Size: 1, Flags: OWNER
        UNIT_FIELD_PETNEXTLEVELEXP                                  = ObjectField.OBJECT_END + 0x058, // Size: 1, Flags: OWNER
        UNIT_DYNAMIC_FLAGS                                          = ObjectField.OBJECT_END + 0x059, // Size: 1, Flags: DYNAMIC, URGENT
        UNIT_MOD_CAST_SPEED                                         = ObjectField.OBJECT_END + 0x05A, // Size: 1, Flags: PUBLIC
        UNIT_MOD_CAST_HASTE                                         = ObjectField.OBJECT_END + 0x05B, // Size: 1, Flags: PUBLIC
        UNIT_CREATED_BY_SPELL                                       = ObjectField.OBJECT_END + 0x05C, // Size: 1, Flags: PUBLIC
        UNIT_NPC_FLAGS                                              = ObjectField.OBJECT_END + 0x05D, // Size: 1, Flags: DYNAMIC, URGENT
        UNIT_NPC_EMOTESTATE                                         = ObjectField.OBJECT_END + 0x05E, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_STAT0                                            = ObjectField.OBJECT_END + 0x05F, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_STAT1                                            = ObjectField.OBJECT_END + 0x060, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_STAT2                                            = ObjectField.OBJECT_END + 0x061, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_STAT3                                            = ObjectField.OBJECT_END + 0x062, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_STAT4                                            = ObjectField.OBJECT_END + 0x063, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_POSSTAT0                                         = ObjectField.OBJECT_END + 0x064, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_POSSTAT1                                         = ObjectField.OBJECT_END + 0x065, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_POSSTAT2                                         = ObjectField.OBJECT_END + 0x066, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_POSSTAT3                                         = ObjectField.OBJECT_END + 0x067, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_POSSTAT4                                         = ObjectField.OBJECT_END + 0x068, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_NEGSTAT0                                         = ObjectField.OBJECT_END + 0x069, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_NEGSTAT1                                         = ObjectField.OBJECT_END + 0x06A, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_NEGSTAT2                                         = ObjectField.OBJECT_END + 0x06B, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_NEGSTAT3                                         = ObjectField.OBJECT_END + 0x06C, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_NEGSTAT4                                         = ObjectField.OBJECT_END + 0x06D, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_RESISTANCES                                      = ObjectField.OBJECT_END + 0x06E, // Size: 7, Flags: PRIVATE
        UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE                       = ObjectField.OBJECT_END + 0x075, // Size: 7, Flags: PRIVATE
        UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE                       = ObjectField.OBJECT_END + 0x07C, // Size: 7, Flags: PRIVATE
        UNIT_FIELD_BASE_MANA                                        = ObjectField.OBJECT_END + 0x083, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_BASE_HEALTH                                      = ObjectField.OBJECT_END + 0x084, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_BYTES_2                                          = ObjectField.OBJECT_END + 0x085, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_ATTACK_POWER                                     = ObjectField.OBJECT_END + 0x086, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_ATTACK_POWER_MOD_POS                             = ObjectField.OBJECT_END + 0x087, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_ATTACK_POWER_MOD_NEG                             = ObjectField.OBJECT_END + 0x088, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_ATTACK_POWER_MULTIPLIER                          = ObjectField.OBJECT_END + 0x089, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_RANGED_ATTACK_POWER                              = ObjectField.OBJECT_END + 0x08A, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_RANGED_ATTACK_POWER_MOD_POS                      = ObjectField.OBJECT_END + 0x08B, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_RANGED_ATTACK_POWER_MOD_NEG                      = ObjectField.OBJECT_END + 0x08C, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER                   = ObjectField.OBJECT_END + 0x08D, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_MINRANGEDDAMAGE                                  = ObjectField.OBJECT_END + 0x08E, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_MAXRANGEDDAMAGE                                  = ObjectField.OBJECT_END + 0x08F, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_POWER_COST_MODIFIER                              = ObjectField.OBJECT_END + 0x090, // Size: 7, Flags: PRIVATE
        UNIT_FIELD_POWER_COST_MULTIPLIER                            = ObjectField.OBJECT_END + 0x097, // Size: 7, Flags: PRIVATE
        UNIT_FIELD_MAXHEALTHMODIFIER                                = ObjectField.OBJECT_END + 0x09E, // Size: 1, Flags: PRIVATE
        UNIT_FIELD_HOVERHEIGHT                                      = ObjectField.OBJECT_END + 0x09F, // Size: 1, Flags: PUBLIC
        UNIT_FIELD_VEHICLE_ID                                       = ObjectField.OBJECT_END + 0x0A0, // Size: 1, Flags: PUBLIC (WotLK)
        UNIT_END                                                    = ObjectField.OBJECT_END + 0x0A1,
    }

    public enum UnitDynamicField
    {
        UNIT_DYNAMIC_END                                            = 0x000,
    }

    public enum PlayerField
    {
        PLAYER_DUEL_ARBITER                                         = UnitField.UNIT_END + 0x000, // Size: 4, Flags: PUBLIC
        PLAYER_FLAGS                                                 = UnitField.UNIT_END + 0x004, // Size: 1, Flags: PUBLIC
        PLAYER_GUILDID                                              = UnitField.UNIT_END + 0x005, // Size: 1, Flags: PUBLIC
        PLAYER_GUILDRANK                                            = UnitField.UNIT_END + 0x006, // Size: 1, Flags: PUBLIC
        PLAYER_BYTES                                                 = UnitField.UNIT_END + 0x007, // Size: 1, Flags: PUBLIC
        PLAYER_BYTES_2                                              = UnitField.UNIT_END + 0x008, // Size: 1, Flags: PUBLIC
        PLAYER_BYTES_3                                              = UnitField.UNIT_END + 0x009, // Size: 1, Flags: PUBLIC
        PLAYER_DUEL_TEAM                                            = UnitField.UNIT_END + 0x00A, // Size: 1, Flags: PUBLIC
        PLAYER_GUILD_TIMESTAMP                                      = UnitField.UNIT_END + 0x00B, // Size: 1, Flags: PUBLIC
        PLAYER_QUEST_LOG_1_1                                        = UnitField.UNIT_END + 0x00C, // Size: 1, Flags: PARTY
        PLAYER_QUEST_LOG_LAST_1                                     = UnitField.UNIT_END + 0x186, // TODO: adjust
        PLAYER_VISIBLE_ITEM_1_ENTRYID                               = UnitField.UNIT_END + 0x188, // TODO: verify
        PLAYER_VISIBLE_ITEM_LAST_ENCHANTMENT                        = UnitField.UNIT_END + 0x1A4, // TODO: verify
        PLAYER_FIELD_INV_SLOT_HEAD                                  = UnitField.UNIT_END + 0x1A6, // TODO: verify
        PLAYER_FIELD_PACK_SLOT_1                                    = UnitField.UNIT_END + 0x1DA, // TODO: verify
        PLAYER_FIELD_BANK_SLOT_1                                    = UnitField.UNIT_END + 0x1FA, // TODO: verify
        PLAYER_FIELD_BANKBAG_SLOT_1                                 = UnitField.UNIT_END + 0x23A, // TODO: verify
        PLAYER_FIELD_VENDORBUYBACK_SLOT_1                           = UnitField.UNIT_END + 0x24C, // TODO: verify
        PLAYER_FIELD_KEYRING_SLOT_1                                 = UnitField.UNIT_END + 0x26C, // TODO: verify
        PLAYER_FIELD_VANITYPET_SLOT_1                               = UnitField.UNIT_END + 0x28C, // TODO: verify
        PLAYER_FARSIGHT                                             = UnitField.UNIT_END + 0x2AC, // Size: 4, Flags: PRIVATE
        PLAYER_FIELD_KNOWN_TITLES                                   = UnitField.UNIT_END + 0x2B0, // Size: 6, Flags: PRIVATE (3 title blocks in WotLK)
        PLAYER_FIELD_KNOWN_CURRENCIES                               = UnitField.UNIT_END + 0x2B6, // Size: 2, Flags: PRIVATE
        PLAYER_XP                                                   = UnitField.UNIT_END + 0x2B8, // Size: 1, Flags: PRIVATE
        PLAYER_NEXT_LEVEL_XP                                        = UnitField.UNIT_END + 0x2B9, // Size: 1, Flags: PRIVATE
        PLAYER_SKILL_INFO_1_1                                       = UnitField.UNIT_END + 0x2BA, // Size: 384, Flags: PRIVATE
        PLAYER_CHARACTER_POINTS1                                    = UnitField.UNIT_END + 0x43A, // Size: 1, Flags: PRIVATE (talent points)
        PLAYER_CHARACTER_POINTS2                                    = UnitField.UNIT_END + 0x43B, // Size: 1, Flags: PRIVATE (free primary profs)
        PLAYER_TRACK_CREATURES                                      = UnitField.UNIT_END + 0x43C, // Size: 1, Flags: PRIVATE
        PLAYER_TRACK_RESOURCES                                      = UnitField.UNIT_END + 0x43D, // Size: 1, Flags: PRIVATE
        PLAYER_EXPERTISE                                            = UnitField.UNIT_END + 0x43E, // Size: 1, Flags: PRIVATE
        PLAYER_OFFHAND_EXPERTISE                                    = UnitField.UNIT_END + 0x43F, // Size: 1, Flags: PRIVATE
        PLAYER_BLOCK_PERCENTAGE                                     = UnitField.UNIT_END + 0x440, // Size: 1, Flags: PRIVATE
        PLAYER_DODGE_PERCENTAGE                                     = UnitField.UNIT_END + 0x441, // Size: 1, Flags: PRIVATE
        PLAYER_PARRY_PERCENTAGE                                     = UnitField.UNIT_END + 0x442, // Size: 1, Flags: PRIVATE
        PLAYER_CRIT_PERCENTAGE                                      = UnitField.UNIT_END + 0x443, // Size: 1, Flags: PRIVATE
        PLAYER_RANGED_CRIT_PERCENTAGE                               = UnitField.UNIT_END + 0x444, // Size: 1, Flags: PRIVATE
        PLAYER_OFFHAND_CRIT_PERCENTAGE                              = UnitField.UNIT_END + 0x445, // Size: 1, Flags: PRIVATE
        PLAYER_SPELL_CRIT_PERCENTAGE1                               = UnitField.UNIT_END + 0x446, // Size: 7, Flags: PRIVATE
        PLAYER_SHIELD_BLOCK                                         = UnitField.UNIT_END + 0x44D, // Size: 1, Flags: PRIVATE
        PLAYER_SHIELD_BLOCK_CRIT_PERCENTAGE                         = UnitField.UNIT_END + 0x44E, // Size: 1, Flags: PRIVATE
        PLAYER_EXPLORED_ZONES_1                                     = UnitField.UNIT_END + 0x44F, // Size: 128, Flags: PRIVATE
        PLAYER_REST_STATE_EXPERIENCE                                 = UnitField.UNIT_END + 0x4CF, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_COINAGE                                        = UnitField.UNIT_END + 0x4D0, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_MOD_DAMAGE_DONE_POS                            = UnitField.UNIT_END + 0x4D1, // Size: 7, Flags: PRIVATE
        PLAYER_FIELD_MOD_DAMAGE_DONE_NEG                            = UnitField.UNIT_END + 0x4D8, // Size: 7, Flags: PRIVATE
        PLAYER_FIELD_MOD_DAMAGE_DONE_PCT                            = UnitField.UNIT_END + 0x4DF, // Size: 7, Flags: PRIVATE
        PLAYER_FIELD_MOD_HEALING_DONE_POS                           = UnitField.UNIT_END + 0x4E6, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_MOD_HEALING_PCT                                = UnitField.UNIT_END + 0x4E7, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_MOD_HEALING_DONE_PCT                           = UnitField.UNIT_END + 0x4E8, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_MOD_TARGET_RESISTANCE                          = UnitField.UNIT_END + 0x4E9, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_MOD_TARGET_PHYSICAL_RESISTANCE                 = UnitField.UNIT_END + 0x4EA, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_BYTES                                          = UnitField.UNIT_END + 0x4EB, // Size: 1, Flags: PRIVATE
        PLAYER_AMMO_ID                                              = UnitField.UNIT_END + 0x4EC, // Size: 1, Flags: PRIVATE
        PLAYER_SELF_RES_SPELL                                       = UnitField.UNIT_END + 0x4ED, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_PVP_MEDALS                                     = UnitField.UNIT_END + 0x4EE, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_BUYBACK_PRICE_1                                = UnitField.UNIT_END + 0x4EF, // Size: 12, Flags: PRIVATE
        PLAYER_FIELD_BUYBACK_TIMESTAMP_1                            = UnitField.UNIT_END + 0x4FB, // Size: 12, Flags: PRIVATE
        PLAYER_FIELD_KILLS                                          = UnitField.UNIT_END + 0x507, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_TODAY_CONTRIBUTION                             = UnitField.UNIT_END + 0x508, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_YESTERDAY_CONTRIBUTION                         = UnitField.UNIT_END + 0x509, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_LIFETIME_HONORABLE_KILLS                       = UnitField.UNIT_END + 0x50A, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_BYTES2                                         = UnitField.UNIT_END + 0x50B, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_WATCHED_FACTION_INDEX                          = UnitField.UNIT_END + 0x50C, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_COMBAT_RATING_1                                = UnitField.UNIT_END + 0x50D, // Size: 25, Flags: PRIVATE
        PLAYER_FIELD_ARENA_TEAM_INFO_1_1                            = UnitField.UNIT_END + 0x526, // Size: 21, Flags: PRIVATE
        PLAYER_FIELD_HONOR_CURRENCY                                 = UnitField.UNIT_END + 0x53B, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_ARENA_CURRENCY                                 = UnitField.UNIT_END + 0x53C, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_MAX_LEVEL                                      = UnitField.UNIT_END + 0x53D, // Size: 1, Flags: PRIVATE
        PLAYER_FIELD_DAILY_QUESTS_1                                 = UnitField.UNIT_END + 0x53E, // Size: 25, Flags: PRIVATE
        PLAYER_RUNE_REGEN_1                                         = UnitField.UNIT_END + 0x557, // Size: 4, Flags: PRIVATE (DK rune regen)
        PLAYER_NO_REAGENT_COST_1                                    = UnitField.UNIT_END + 0x55B, // Size: 3, Flags: PRIVATE
        PLAYER_FIELD_GLYPH_SLOTS_1                                  = UnitField.UNIT_END + 0x55E, // Size: 6, Flags: PRIVATE (WotLK glyphs)
        PLAYER_FIELD_GLYPHS_1                                       = UnitField.UNIT_END + 0x564, // Size: 6, Flags: PRIVATE (WotLK glyphs)
        PLAYER_GLYPHS_ENABLED                                       = UnitField.UNIT_END + 0x56A, // Size: 1, Flags: PRIVATE
        PLAYER_END                                                  = UnitField.UNIT_END + 0x56B,
    }

    public enum PlayerDynamicField
    {
        PLAYER_DYNAMIC_END                                          = 0x000,
    }

    public enum ActivePlayerField
    {
        ACTIVE_PLAYER_END                                           = PlayerField.PLAYER_END + 0x000,
    }

    public enum ActivePlayerDynamicField
    {
        ACTIVE_PLAYER_DYNAMIC_END                                   = 0x000,
    }

    public enum GameObjectField
    {
        GAMEOBJECT_FIELD_CREATED_BY                                 = ObjectField.OBJECT_END + 0x000, // Size: 4, Flags: PUBLIC
        GAMEOBJECT_DISPLAYID                                        = ObjectField.OBJECT_END + 0x004, // Size: 1, Flags: PUBLIC
        GAMEOBJECT_FLAGS                                            = ObjectField.OBJECT_END + 0x005, // Size: 1, Flags: PUBLIC
        GAMEOBJECT_PARENTROTATION                                   = ObjectField.OBJECT_END + 0x006, // Size: 4, Flags: PUBLIC
        GAMEOBJECT_DYNAMIC                                          = ObjectField.OBJECT_END + 0x00A, // Size: 1, Flags: DYNAMIC, URGENT
        GAMEOBJECT_FACTION                                          = ObjectField.OBJECT_END + 0x00B, // Size: 1, Flags: PUBLIC
        GAMEOBJECT_LEVEL                                            = ObjectField.OBJECT_END + 0x00C, // Size: 1, Flags: PUBLIC
        GAMEOBJECT_BYTES_1                                          = ObjectField.OBJECT_END + 0x00D, // Size: 1, Flags: PUBLIC
        GAMEOBJECT_END                                              = ObjectField.OBJECT_END + 0x00E,
    }

    public enum GameObjectDynamicField
    {
        GAMEOBJECT_DYNAMIC_END                                      = 0x000,
    }

    public enum DynamicObjectField
    {
        DYNAMICOBJECT_CASTER                                        = ObjectField.OBJECT_END + 0x000, // Size: 4, Flags: PUBLIC
        DYNAMICOBJECT_BYTES                                         = ObjectField.OBJECT_END + 0x004, // Size: 1, Flags: PUBLIC
        DYNAMICOBJECT_SPELLID                                       = ObjectField.OBJECT_END + 0x005, // Size: 1, Flags: PUBLIC
        DYNAMICOBJECT_RADIUS                                        = ObjectField.OBJECT_END + 0x006, // Size: 1, Flags: PUBLIC
        DYNAMICOBJECT_CASTTIME                                      = ObjectField.OBJECT_END + 0x007, // Size: 1, Flags: PUBLIC
        DYNAMICOBJECT_END                                           = ObjectField.OBJECT_END + 0x008,
    }

    public enum DynamicObjectDynamicField
    {
        DYNAMICOBJECT_DYNAMIC_END                                   = 0x000,
    }

    public enum CorpseField
    {
        CORPSE_FIELD_OWNER                                          = ObjectField.OBJECT_END + 0x000, // Size: 4, Flags: PUBLIC
        CORPSE_FIELD_PARTY                                          = ObjectField.OBJECT_END + 0x004, // Size: 4, Flags: PUBLIC
        CORPSE_FIELD_DISPLAY_ID                                     = ObjectField.OBJECT_END + 0x008, // Size: 1, Flags: PUBLIC
        CORPSE_FIELD_ITEM                                           = ObjectField.OBJECT_END + 0x009, // Size: 19, Flags: PUBLIC
        CORPSE_FIELD_BYTES_1                                        = ObjectField.OBJECT_END + 0x01C, // Size: 1, Flags: PUBLIC
        CORPSE_FIELD_BYTES_2                                        = ObjectField.OBJECT_END + 0x01D, // Size: 1, Flags: PUBLIC
        CORPSE_FIELD_GUILD                                          = ObjectField.OBJECT_END + 0x01E, // Size: 1, Flags: PUBLIC
        CORPSE_FIELD_FLAGS                                          = ObjectField.OBJECT_END + 0x01F, // Size: 1, Flags: PUBLIC
        CORPSE_FIELD_DYNAMIC_FLAGS                                  = ObjectField.OBJECT_END + 0x020, // Size: 1, Flags: DYNAMIC, URGENT
        CORPSE_END                                                  = ObjectField.OBJECT_END + 0x021,
    }

    public enum CorpseDynamicField
    {
        CORPSE_DYNAMIC_END                                          = 0x000,
    }

    public enum AreaTriggerField
    {
        AREATRIGGER_END                                             = ObjectField.OBJECT_END + 0x000,
    }

    public enum AreaTriggerDynamicField
    {
        AREATRIGGER_DYNAMIC_END                                     = 0x000,
    }

    public enum SceneObjectField
    {
        SCENEOBJECT_END                                             = ObjectField.OBJECT_END + 0x000,
    }

    public enum SceneObjectDynamicField
    {
        SCENEOBJECT_DYNAMIC_END                                     = 0x000,
    }

    public enum ConversationField
    {
        CONVERSATION_END                                            = ObjectField.OBJECT_END + 0x000,
    }

    public enum ConversationDynamicField
    {
        CONVERSATION_DYNAMIC_END                                    = 0x000,
    }
}
