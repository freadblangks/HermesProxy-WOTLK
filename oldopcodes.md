# Legacy Opcodes (3.3.5a Build 12340)

Total: 1311 opcodes

## Legend
- **HANDLED**: Has a packet handler in HermesProxy
- **UNHANDLED**: No handler exists
- **MODERN MATCH**: Also exists in 3.4.3 modern client
- **LEGACY ONLY**: Does NOT exist in modern client

## CMSG (Client -> Server)

| Opcode | Value (Dec) | Value (Hex) | Handled | Modern Match | Handler Location |
|--------|-------------|-------------|---------|--------------|------------------|
| CMSG_ACCEPT_GUILD_INVITE | 132 | 0x0084 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1494 |
| CMSG_ACCEPT_LEVEL_GRANT | 1056 | 0x0420 | NO | NO |  |
| CMSG_ACCEPT_TRADE | 282 | 0x011A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4385 |
| CMSG_ACTIVATE_TAXI | 429 | 0x01AD | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4234 |
| CMSG_ACTIVATE_TAXI_EXPRESS | 786 | 0x0312 | NO | NO |  |
| CMSG_ACTIVE_PVP_CHEAT | 921 | 0x0399 | NO | NO |  |
| CMSG_ADD_FRIEND | 105 | 0x0069 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3697 |
| CMSG_ADD_IGNORE | 108 | 0x006C | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3709 |
| CMSG_ADD_PVP_MEDAL_CHEAT | 649 | 0x0289 | NO | NO |  |
| CMSG_ADVANCE_SPAWN_TIME | 49 | 0x0031 | NO | NO |  |
| CMSG_AFK_MONITOR_INFO_CLEAR | 1285 | 0x0505 | NO | NO |  |
| CMSG_AFK_MONITOR_INFO_REQUEST | 1283 | 0x0503 | NO | NO |  |
| CMSG_ALTER_APPEARANCE | 1062 | 0x0426 | NO | YES |  |
| CMSG_AREA_SPIRIT_HEALER_QUERY | 738 | 0x02E2 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3057 |
| CMSG_AREA_SPIRIT_HEALER_QUEUE | 739 | 0x02E3 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3058 |
| CMSG_AREA_TRIGGER | 180 | 0x00B4 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2406 |
| CMSG_ARENA_TEAM_ACCEPT | 849 | 0x0351 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:247 |
| CMSG_ARENA_TEAM_CREATE | 840 | 0x0348 | NO | NO |  |
| CMSG_ARENA_TEAM_DECLINE | 850 | 0x0352 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:248 |
| CMSG_ARENA_TEAM_DISBAND | 853 | 0x0355 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:238 |
| CMSG_ARENA_TEAM_INVITE | 847 | 0x034F | NO | YES |  |
| CMSG_ARENA_TEAM_LEADER | 854 | 0x0356 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:229 |
| CMSG_ARENA_TEAM_LEAVE | 851 | 0x0353 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:239 |
| CMSG_ARENA_TEAM_QUERY | 843 | 0x034B | YES | YES | HermesProxy/World/Server/WorldSocket.cs:186 |
| CMSG_ARENA_TEAM_REMOVE | 852 | 0x0354 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:228 |
| CMSG_ARENA_TEAM_ROSTER | 845 | 0x034D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:168 |
| CMSG_ATTACK_STOP | 322 | 0x0142 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1106 |
| CMSG_ATTACK_SWING | 321 | 0x0141 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1098 |
| CMSG_AUCTION_LIST_BIDDED_ITEMS | 612 | 0x0264 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:263 |
| CMSG_AUCTION_LIST_ITEMS | 600 | 0x0258 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:286 |
| CMSG_AUCTION_LIST_OWNED_ITEMS | 601 | 0x0259 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:277 |
| CMSG_AUCTION_LIST_PENDING_SALES | 1167 | 0x048F | NO | NO |  |
| CMSG_AUCTION_PLACE_BID | 602 | 0x025A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:433 |
| CMSG_AUCTION_REMOVE_ITEM | 599 | 0x0257 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:424 |
| CMSG_AUCTION_SELL_ITEM | 598 | 0x0256 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:362 |
| CMSG_AUTH_CONTINUED_SESSION | 1298 | 0x0512 | NO | YES |  |
| CMSG_AUTH_SESSION | 493 | 0x01ED | NO | YES |  |
| CMSG_AUTH_SRP6_BEGIN | 51 | 0x0033 | NO | NO |  |
| CMSG_AUTH_SRP6_PROOF | 52 | 0x0034 | NO | NO |  |
| CMSG_AUTH_SRP6_RECODE | 53 | 0x0035 | NO | NO |  |
| CMSG_AUTOBANK_ITEM | 643 | 0x0283 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2058 |
| CMSG_AUTOSTORE_BANK_ITEM | 642 | 0x0282 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2057 |
| CMSG_AUTOSTORE_GROUND_ITEM | 263 | 0x0107 | NO | NO |  |
| CMSG_AUTOSTORE_LOOT_ITEM | 264 | 0x0108 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2182 |
| CMSG_AUTO_EQUIP_GROUND_ITEM | 262 | 0x0106 | NO | NO |  |
| CMSG_AUTO_EQUIP_ITEM | 266 | 0x010A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2056 |
| CMSG_AUTO_EQUIP_ITEM_SLOT | 271 | 0x010F | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2069 |
| CMSG_AUTO_STORE_BAG_ITEM | 267 | 0x010B | NO | YES |  |
| CMSG_BANKER_ACTIVATE | 439 | 0x01B7 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3050 |
| CMSG_BATTLEFIELD_JOIN | 574 | 0x023E | NO | NO |  |
| CMSG_BATTLEFIELD_LEAVE | 737 | 0x02E1 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:505 |
| CMSG_BATTLEFIELD_LIST | 572 | 0x023C | YES | YES | HermesProxy/World/Server/WorldSocket.cs:495 |
| CMSG_BATTLEFIELD_MANAGER_ADVANCE_STATE | 1257 | 0x04E9 | NO | NO |  |
| CMSG_BATTLEFIELD_MANAGER_SET_NEXT_TRANSITION_TIME | 1258 | 0x04EA | NO | NO |  |
| CMSG_BATTLEFIELD_STATUS | 723 | 0x02D3 | NO | NO |  |
| CMSG_BATTLEGROUND_PORT_AND_LEAVE | 725 | 0x02D5 | NO | NO |  |
| CMSG_BATTLEMASTER_HELLO | 727 | 0x02D7 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3056 |
| CMSG_BATTLEMASTER_JOIN | 750 | 0x02EE | YES | YES | HermesProxy/World/Server/WorldSocket.cs:443 |
| CMSG_BATTLEMASTER_JOIN_ARENA | 856 | 0x0358 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:206 |
| CMSG_BEASTMASTER | 33 | 0x0021 | NO | NO |  |
| CMSG_BEGIN_TRADE | 279 | 0x0117 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4393 |
| CMSG_BF_MGR_ENTRY_INVITE_RESPONSE | 1247 | 0x04DF | NO | NO |  |
| CMSG_BF_MGR_QUEUE_EXIT_REQUEST | 1255 | 0x04E7 | NO | NO |  |
| CMSG_BF_MGR_QUEUE_INVITE_RESPONSE | 1250 | 0x04E2 | NO | NO |  |
| CMSG_BF_MGR_QUEUE_REQUEST | 1251 | 0x04E3 | NO | NO |  |
| CMSG_BINDER_ACTIVATE | 437 | 0x01B5 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3051 |
| CMSG_BOOTME | 1 | 0x0001 | NO | NO |  |
| CMSG_BOT_DETECTED | 960 | 0x03C0 | NO | NO |  |
| CMSG_BOT_DETECTED2 | 23 | 0x0017 | NO | NO |  |
| CMSG_BUG | 458 | 0x01CA | NO | YES |  |
| CMSG_BUSY_TRADE | 280 | 0x0118 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4394 |
| CMSG_BUY_BACK_ITEM | 656 | 0x0290 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2090 |
| CMSG_BUY_BANK_SLOT | 441 | 0x01B9 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3083 |
| CMSG_BUY_ITEM | 418 | 0x01A2 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1953 |
| CMSG_BUY_ITEM_IN_SLOT | 419 | 0x01A3 | NO | NO |  |
| CMSG_BUY_LOTTERY_TICKET_OBSOLETE | 822 | 0x0336 | NO | NO |  |
| CMSG_BUY_STABLE_SLOT | 626 | 0x0272 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3185 |
| CMSG_CALENDAR_ADD_EVENT | 1069 | 0x042D | NO | NO |  |
| CMSG_CALENDAR_ARENA_TEAM | 1068 | 0x042C | NO | NO |  |
| CMSG_CALENDAR_COMPLAIN | 1094 | 0x0446 | NO | NO |  |
| CMSG_CALENDAR_COPY_EVENT | 1072 | 0x0430 | NO | NO |  |
| CMSG_CALENDAR_EVENT_INVITE | 1073 | 0x0431 | NO | NO |  |
| CMSG_CALENDAR_EVENT_INVITE_NOTES | 1119 | 0x045F | NO | NO |  |
| CMSG_CALENDAR_EVENT_MODERATOR_STATUS | 1077 | 0x0435 | NO | NO |  |
| CMSG_CALENDAR_EVENT_REMOVE_INVITE | 1075 | 0x0433 | NO | NO |  |
| CMSG_CALENDAR_EVENT_RSVP | 1074 | 0x0432 | NO | NO |  |
| CMSG_CALENDAR_EVENT_SIGN_UP | 1210 | 0x04BA | NO | NO |  |
| CMSG_CALENDAR_EVENT_STATUS | 1076 | 0x0434 | NO | NO |  |
| CMSG_CALENDAR_GET_CALENDAR | 1065 | 0x0429 | NO | NO |  |
| CMSG_CALENDAR_GET_EVENT | 1066 | 0x042A | NO | NO |  |
| CMSG_CALENDAR_GET_NUM_PENDING | 1095 | 0x0447 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2761 |
| CMSG_CALENDAR_GUILD_FILTER | 1067 | 0x042B | NO | NO |  |
| CMSG_CALENDAR_REMOVE_EVENT | 1071 | 0x042F | NO | NO |  |
| CMSG_CALENDAR_UPDATE_EVENT | 1070 | 0x042E | NO | NO |  |
| CMSG_CANCEL_AURA | 310 | 0x0136 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4097 |
| CMSG_CANCEL_AUTO_REPEAT_SPELL | 621 | 0x026D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4086 |
| CMSG_CANCEL_CAST | 303 | 0x012F | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4058 |
| CMSG_CANCEL_CHANNELLING | 315 | 0x013B | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4074 |
| CMSG_CANCEL_GROWTH_AURA | 667 | 0x029B | NO | YES |  |
| CMSG_CANCEL_MOUNT_AURA | 885 | 0x0375 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4105 |
| CMSG_CANCEL_TEMP_ENCHANTMENT | 889 | 0x0379 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2147 |
| CMSG_CANCEL_TRADE | 284 | 0x011C | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4395 |
| CMSG_CAST_SPELL | 302 | 0x012E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3862 |
| CMSG_CHANGEPLAYER_DIFFICULTY | 509 | 0x01FD | NO | NO |  |
| CMSG_CHANGE_GDF_ARENA_RATING | 1196 | 0x04AC | NO | NO |  |
| CMSG_CHANGE_PERSONAL_ARENA_RATING | 1061 | 0x0425 | NO | NO |  |
| CMSG_CHANGE_SEATS_ON_CONTROLLED_VEHICLE | 1179 | 0x049B | NO | NO |  |
| CMSG_CHARACTER_POINT_CHEAT | 547 | 0x0223 | NO | NO |  |
| CMSG_CHARACTER_RENAME_REQUEST | 711 | 0x02C7 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:764 |
| CMSG_CHAR_CUSTOMIZE | 1139 | 0x0473 | NO | NO |  |
| CMSG_CHAR_DELETE | 56 | 0x0038 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:580 |
| CMSG_CHAR_FACTION_CHANGE | 1241 | 0x04D9 | NO | NO |  |
| CMSG_CHAR_RACE_CHANGE | 1272 | 0x04F8 | NO | NO |  |
| CMSG_CHAT_CHANNEL_ANNOUNCEMENTS | 167 | 0x00A7 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:793 |
| CMSG_CHAT_CHANNEL_BAN | 165 | 0x00A5 | NO | YES |  |
| CMSG_CHAT_CHANNEL_DECLINE_INVITE | 1040 | 0x0410 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:828 |
| CMSG_CHAT_CHANNEL_DISPLAY_LIST | 978 | 0x03D2 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:810 |
| CMSG_CHAT_CHANNEL_INVITE | 163 | 0x00A3 | NO | YES |  |
| CMSG_CHAT_CHANNEL_KICK | 164 | 0x00A4 | NO | YES |  |
| CMSG_CHAT_CHANNEL_LIST | 154 | 0x009A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:801 |
| CMSG_CHAT_CHANNEL_MODERATE | 168 | 0x00A8 | NO | NO |  |
| CMSG_CHAT_CHANNEL_MODERATOR | 159 | 0x009F | NO | YES |  |
| CMSG_CHAT_CHANNEL_MUTE | 161 | 0x00A1 | NO | NO |  |
| CMSG_CHAT_CHANNEL_OWNER | 158 | 0x009E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:792 |
| CMSG_CHAT_CHANNEL_PASSWORD | 156 | 0x009C | NO | YES |  |
| CMSG_CHAT_CHANNEL_SET_OWNER | 157 | 0x009D | NO | YES |  |
| CMSG_CHAT_CHANNEL_SILENCE_ALL | 973 | 0x03CD | NO | YES |  |
| CMSG_CHAT_CHANNEL_SILENCE_VOICE | 972 | 0x03CC | NO | NO |  |
| CMSG_CHAT_CHANNEL_UNBAN | 166 | 0x00A6 | NO | YES |  |
| CMSG_CHAT_CHANNEL_UNMODERATOR | 160 | 0x00A0 | NO | YES |  |
| CMSG_CHAT_CHANNEL_UNMUTE | 162 | 0x00A2 | NO | NO |  |
| CMSG_CHAT_CHANNEL_UNSILENCE_ALL | 975 | 0x03CF | NO | YES |  |
| CMSG_CHAT_CHANNEL_UNSILENCE_VOICE | 974 | 0x03CE | NO | NO |  |
| CMSG_CHAT_CHANNEL_VOICE_OFF | 983 | 0x03D7 | NO | NO |  |
| CMSG_CHAT_CHANNEL_VOICE_ON | 982 | 0x03D6 | NO | NO |  |
| CMSG_CHAT_JOIN_CHANNEL | 151 | 0x0097 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:773 |
| CMSG_CHAT_LEAVE_CHANNEL | 152 | 0x0098 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:782 |
| CMSG_CHAT_REPORT_FILTERED | 817 | 0x0331 | NO | NO |  |
| CMSG_CHAT_REPORT_IGNORED | 549 | 0x0225 | NO | NO |  |
| CMSG_CHEAT_DUMP_ITEMS_DEBUG_ONLY | 922 | 0x039A | NO | NO |  |
| CMSG_CHEAT_PLAYER_LOGIN | 962 | 0x03C2 | NO | NO |  |
| CMSG_CHEAT_PLAYER_LOOKUP | 963 | 0x03C3 | NO | NO |  |
| CMSG_CHEAT_SETMONEY | 36 | 0x0024 | NO | NO |  |
| CMSG_CHEAT_SET_ARENA_CURRENCY | 892 | 0x037C | NO | NO |  |
| CMSG_CHEAT_SET_HONOR_CURRENCY | 891 | 0x037B | NO | NO |  |
| CMSG_CHECK_LOGIN_CRITERIA | 1186 | 0x04A2 | NO | NO |  |
| CMSG_CLEAR_CHANNEL_WATCH | 1011 | 0x03F3 | NO | NO |  |
| CMSG_CLEAR_EXPLORATION | 567 | 0x0237 | NO | NO |  |
| CMSG_CLEAR_HOLIDAY_BG_WIN_TIME | 1306 | 0x051A | NO | NO |  |
| CMSG_CLEAR_QUEST | 44 | 0x002C | NO | NO |  |
| CMSG_CLEAR_RANDOM_BG_WIN_TIME | 1305 | 0x0519 | NO | NO |  |
| CMSG_CLEAR_SERVER_BUCK_DATA | 1052 | 0x041C | NO | NO |  |
| CMSG_CLEAR_TRADE_ITEM | 286 | 0x011E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4404 |
| CMSG_COMMENTATOR_ENABLE | 949 | 0x03B5 | NO | NO |  |
| CMSG_COMMENTATOR_ENTER_INSTANCE | 956 | 0x03BC | NO | NO |  |
| CMSG_COMMENTATOR_EXIT_INSTANCE | 957 | 0x03BD | NO | NO |  |
| CMSG_COMMENTATOR_GET_MAP_INFO | 951 | 0x03B7 | NO | NO |  |
| CMSG_COMMENTATOR_GET_PLAYER_INFO | 953 | 0x03B9 | NO | NO |  |
| CMSG_COMMENTATOR_INSTANCE_COMMAND | 958 | 0x03BE | NO | NO |  |
| CMSG_COMMENTATOR_SKIRMISH_QUEUE_COMMAND | 1307 | 0x051B | NO | NO |  |
| CMSG_COMPLAINT | 967 | 0x03C7 | NO | NO |  |
| CMSG_COMPLETE_ACHIEVEMENT_CHEAT | 1134 | 0x046E | NO | NO |  |
| CMSG_COMPLETE_CINEMATIC | 252 | 0x00FC | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2462 |
| CMSG_COMPLETE_MOVIE | 1125 | 0x0465 | NO | NO |  |
| CMSG_CONNECT_TO_FAILED | 1294 | 0x050E | NO | NO |  |
| CMSG_CONTACT_LIST | 102 | 0x0066 | YES | NO | HermesProxy/World/Server/WorldSocket.cs:3681 |
| CMSG_CONVERT_RAID | 654 | 0x028E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1250 |
| CMSG_COOLDOWN_CHEAT | 40 | 0x0028 | NO | NO |  |
| CMSG_CORPSE_MAP_POSITION_QUERY | 1206 | 0x04B6 | NO | NO |  |
| CMSG_CREATEGAMEOBJECT | 20 | 0x0014 | NO | NO |  |
| CMSG_CREATEITEM | 19 | 0x0013 | NO | NO |  |
| CMSG_CREATEMONSTER | 17 | 0x0011 | NO | NO |  |
| CMSG_CREATE_CHARACTER | 54 | 0x0036 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:562 |
| CMSG_DANCE_QUERY | 1105 | 0x0451 | NO | NO |  |
| CMSG_DBLOOKUP | 2 | 0x0002 | NO | NO |  |
| CMSG_DEBUG_ACTIONS_START | 789 | 0x0315 | NO | NO |  |
| CMSG_DEBUG_ACTIONS_STOP | 790 | 0x0316 | NO | NO |  |
| CMSG_DEBUG_AISTATE | 46 | 0x002E | NO | NO |  |
| CMSG_DEBUG_CHANGECELLZONE | 12 | 0x000C | NO | NO |  |
| CMSG_DEBUG_LIST_TARGETS | 984 | 0x03D8 | NO | NO |  |
| CMSG_DEBUG_PASSIVE_AURA | 320 | 0x0140 | NO | NO |  |
| CMSG_DEBUG_SERVER_GEO | 1275 | 0x04FB | NO | NO |  |
| CMSG_DECHARGE | 516 | 0x0204 | NO | NO |  |
| CMSG_DELETE_DANCE | 1108 | 0x0454 | NO | NO |  |
| CMSG_DEL_FRIEND | 106 | 0x006A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3717 |
| CMSG_DEL_IGNORE | 109 | 0x006D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3718 |
| CMSG_DEL_PVP_MEDAL_CHEAT | 650 | 0x028A | NO | NO |  |
| CMSG_DESTROYMONSTER | 18 | 0x0012 | NO | NO |  |
| CMSG_DESTROY_ITEM | 273 | 0x0111 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2044 |
| CMSG_DESTROY_ITEMS | 178 | 0x00B2 | NO | NO |  |
| CMSG_DF_GET_JOIN_STATUS | 662 | 0x0296 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2756 |
| CMSG_DISABLE_PVP_CHEAT | 48 | 0x0030 | NO | NO |  |
| CMSG_DISMISS_CONTROLLED_VEHICLE | 1133 | 0x046D | NO | NO |  |
| CMSG_DISMISS_CRITTER | 1165 | 0x048D | NO | NO |  |
| CMSG_DROP_NEW_CONNECTION | 1299 | 0x0513 | NO | NO |  |
| CMSG_DUEL_ACCEPTED | 364 | 0x016C | NO | NO |  |
| CMSG_DUEL_CANCELLED | 365 | 0x016D | NO | NO |  |
| CMSG_DUMP_OBJECTS | 1163 | 0x048B | NO | NO |  |
| CMSG_EJECT_PASSENGER | 1193 | 0x04A9 | NO | NO |  |
| CMSG_EMOTE | 258 | 0x0102 | NO | NO |  |
| CMSG_ENABLE_DAMAGE_LOG | 637 | 0x027D | NO | NO |  |
| CMSG_ENABLE_TAXI_NODE | 1171 | 0x0493 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4226 |
| CMSG_END_BATTLEFIELD_CHEAT | 1228 | 0x04CC | NO | NO |  |
| CMSG_ENUM_CHARACTERS | 55 | 0x0037 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:523 |
| CMSG_EQUIPMENT_SET_DELETE | 318 | 0x013E | NO | NO |  |
| CMSG_EQUIPMENT_SET_USE | 1237 | 0x04D5 | NO | NO |  |
| CMSG_EXPIRE_RAID_INSTANCE | 1045 | 0x0415 | NO | NO |  |
| CMSG_FAR_SIGHT | 634 | 0x027A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2469 |
| CMSG_FLAG_QUEST | 42 | 0x002A | NO | NO |  |
| CMSG_FLAG_QUEST_FINISH | 43 | 0x002B | NO | NO |  |
| CMSG_FLOOD_GRACE_CHEAT | 1175 | 0x0497 | NO | NO |  |
| CMSG_FORCEACTION | 24 | 0x0018 | NO | NO |  |
| CMSG_FORCEACTIONONOTHER | 25 | 0x0019 | NO | NO |  |
| CMSG_FORCEACTIONSHOW | 26 | 0x001A | NO | NO |  |
| CMSG_FORCE_ANIM | 1239 | 0x04D7 | NO | NO |  |
| CMSG_FORCE_SAY_CHEAT | 1150 | 0x047E | NO | NO |  |
| CMSG_GAMESPEED_SET | 70 | 0x0046 | NO | NO |  |
| CMSG_GAMETIME_SET | 68 | 0x0044 | NO | NO |  |
| CMSG_GAME_OBJ_REPORT_USE | 1153 | 0x0481 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1157 |
| CMSG_GAME_OBJ_USE | 177 | 0x00B1 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1147 |
| CMSG_GETDEATHBINDZONE | 342 | 0x0156 | NO | NO |  |
| CMSG_GET_CHANNEL_MEMBER_COUNT | 980 | 0x03D4 | NO | NO |  |
| CMSG_GET_ITEM_PURCHASE_DATA | 1203 | 0x04B3 | NO | NO |  |
| CMSG_GET_MIRROR_IMAGE_DATA | 1025 | 0x0401 | NO | NO |  |
| CMSG_GHOST | 485 | 0x01E5 | NO | NO |  |
| CMSG_GMRESPONSE_CREATE_TICKET | 1267 | 0x04F3 | NO | NO |  |
| CMSG_GMTICKETSYSTEM_TOGGLE | 666 | 0x029A | NO | NO |  |
| CMSG_GM_CHARACTER_RESTORE | 1018 | 0x03FA | NO | NO |  |
| CMSG_GM_CHARACTER_SAVE | 1019 | 0x03FB | NO | NO |  |
| CMSG_GM_CREATE_ITEM_TARGET | 528 | 0x0210 | NO | NO |  |
| CMSG_GM_DESTROY_ONLINE_CORPSE | 785 | 0x0311 | NO | NO |  |
| CMSG_GM_FREEZE | 557 | 0x022D | NO | NO |  |
| CMSG_GM_GRANT_ACHIEVEMENT | 1220 | 0x04C4 | NO | NO |  |
| CMSG_GM_INVIS | 486 | 0x01E6 | NO | NO |  |
| CMSG_GM_LAG_REPORT | 1282 | 0x0502 | NO | NO |  |
| CMSG_GM_MOVECORPSE | 556 | 0x022C | NO | NO |  |
| CMSG_GM_NUKE | 506 | 0x01FA | NO | NO |  |
| CMSG_GM_NUKE_ACCOUNT | 783 | 0x030F | NO | NO |  |
| CMSG_GM_NUKE_CHARACTER | 1287 | 0x0507 | NO | NO |  |
| CMSG_GM_REMOVE_ACHIEVEMENT | 1221 | 0x04C5 | NO | NO |  |
| CMSG_GM_REQUEST_PLAYER_INFO | 559 | 0x022F | NO | NO |  |
| CMSG_GM_RESURRECT | 554 | 0x022A | NO | NO |  |
| CMSG_GM_REVEALTO | 553 | 0x0229 | NO | NO |  |
| CMSG_GM_SET_CRITERIA_FOR_PLAYER | 1222 | 0x04C6 | NO | NO |  |
| CMSG_GM_SET_SECURITY_GROUP | 505 | 0x01F9 | NO | NO |  |
| CMSG_GM_SHOW_COMPLAINTS | 970 | 0x03CA | NO | NO |  |
| CMSG_GM_SILENCE | 552 | 0x0228 | NO | NO |  |
| CMSG_GM_SUMMONMOB | 555 | 0x022B | NO | NO |  |
| CMSG_GM_SURVEY_SUBMIT | 810 | 0x032A | NO | NO |  |
| CMSG_GM_TEACH | 527 | 0x020F | NO | NO |  |
| CMSG_GM_TICKET_CREATE | 517 | 0x0205 | NO | YES |  |
| CMSG_GM_TICKET_DELETE_TICKET | 535 | 0x0217 | NO | YES |  |
| CMSG_GM_TICKET_GET_SYSTEM_STATUS | 538 | 0x021A | NO | NO |  |
| CMSG_GM_TICKET_GET_TICKET | 529 | 0x0211 | NO | YES |  |
| CMSG_GM_TICKET_RESPONSE_RESOLVE | 1264 | 0x04F0 | NO | NO |  |
| CMSG_GM_TICKET_UPDATE_TEXT | 519 | 0x0207 | NO | YES |  |
| CMSG_GM_UBERINVIS | 558 | 0x022E | NO | NO |  |
| CMSG_GM_UNSQUELCH | 971 | 0x03CB | NO | NO |  |
| CMSG_GM_UNTEACH | 741 | 0x02E5 | NO | NO |  |
| CMSG_GM_UPDATE_TICKET_STATUS | 807 | 0x0327 | NO | NO |  |
| CMSG_GM_VISION | 550 | 0x0226 | NO | NO |  |
| CMSG_GM_WHISPER | 946 | 0x03B2 | NO | NO |  |
| CMSG_GODMODE | 34 | 0x0022 | NO | NO |  |
| CMSG_GOSSIP_SELECT_OPTION | 380 | 0x017C | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3066 |
| CMSG_GRANT_LEVEL | 1037 | 0x040D | NO | NO |  |
| CMSG_GROUP_ACCEPT | 114 | 0x0072 | NO | NO |  |
| CMSG_GROUP_CANCEL | 112 | 0x0070 | NO | NO |  |
| CMSG_GROUP_CHANGE_SUB_GROUP | 638 | 0x027E | YES | NO | HermesProxy/World/Server/WorldSocket.cs:1323 |
| CMSG_GROUP_DECLINE | 115 | 0x0073 | NO | YES |  |
| CMSG_GROUP_DISBAND | 123 | 0x007B | NO | NO |  |
| CMSG_GROUP_SWAP_SUB_GROUP | 640 | 0x0280 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1332 |
| CMSG_GROUP_UNINVITE | 117 | 0x0075 | NO | NO |  |
| CMSG_GROUP_UNINVITE_GUID | 118 | 0x0076 | NO | NO |  |
| CMSG_GUILD_ADD_RANK | 562 | 0x0232 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1464 |
| CMSG_GUILD_BANK_ACTIVATE | 998 | 0x03E6 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1547 |
| CMSG_GUILD_BANK_BUY_TAB | 1002 | 0x03EA | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1611 |
| CMSG_GUILD_BANK_DEPOSIT_MONEY | 1004 | 0x03EC | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1566 |
| CMSG_GUILD_BANK_QUERY_TAB | 999 | 0x03E7 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1556 |
| CMSG_GUILD_BANK_SET_TAB_TEXT | 1035 | 0x040B | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1602 |
| CMSG_GUILD_BANK_SWAP_ITEMS | 1001 | 0x03E9 | NO | YES |  |
| CMSG_GUILD_BANK_UPDATE_TAB | 1003 | 0x03EB | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1583 |
| CMSG_GUILD_BANK_WITHDRAW_MONEY | 1005 | 0x03ED | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1620 |
| CMSG_GUILD_CREATE | 129 | 0x0081 | NO | NO |  |
| CMSG_GUILD_DECLINE_INVITATION | 133 | 0x0085 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1501 |
| CMSG_GUILD_DELETE | 143 | 0x008F | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1508 |
| CMSG_GUILD_DELETE_RANK | 563 | 0x0233 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1472 |
| CMSG_GUILD_DEMOTE_MEMBER | 140 | 0x008C | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1411 |
| CMSG_GUILD_GET_ROSTER | 137 | 0x0089 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1369 |
| CMSG_GUILD_INFO | 135 | 0x0087 | NO | NO |  |
| CMSG_GUILD_INVITE_BY_NAME | 130 | 0x0082 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1427 |
| CMSG_GUILD_LEAVE | 141 | 0x008D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1487 |
| CMSG_GUILD_OFFICER_REMOVE_MEMBER | 142 | 0x008E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1419 |
| CMSG_GUILD_PROMOTE_MEMBER | 139 | 0x008B | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1403 |
| CMSG_GUILD_SET_GUILD_MASTER | 144 | 0x0090 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1479 |
| CMSG_GUILD_SET_OFFICER_NOTE | 565 | 0x0235 | NO | NO |  |
| CMSG_GUILD_SET_PUBLIC_NOTE | 564 | 0x0234 | NO | NO |  |
| CMSG_GUILD_SET_RANK_PERMISSIONS | 561 | 0x0231 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1445 |
| CMSG_GUILD_UPDATE_INFO_TEXT | 764 | 0x02FC | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1386 |
| CMSG_GUILD_UPDATE_MOTD_TEXT | 145 | 0x0091 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1378 |
| CMSG_HEARTH_AND_RESURRECT | 1180 | 0x049C | NO | YES |  |
| CMSG_IGNORE_DIMINISHING_RETURNS_CHEAT | 1029 | 0x0405 | NO | NO |  |
| CMSG_IGNORE_KNOCKBACK_CHEAT | 812 | 0x032C | NO | NO |  |
| CMSG_IGNORE_REQUIREMENTS_CHEAT | 936 | 0x03A8 | NO | NO |  |
| CMSG_IGNORE_TRADE | 281 | 0x0119 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4397 |
| CMSG_INITIATE_TRADE | 278 | 0x0116 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4360 |
| CMSG_INSPECT | 276 | 0x0114 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:730 |
| CMSG_INSTANCE_LOCK_RESPONSE | 319 | 0x013F | NO | YES |  |
| CMSG_ITEM_NAME_QUERY | 708 | 0x02C4 | NO | NO |  |
| CMSG_ITEM_PURCHASE_REFUND | 1204 | 0x04B4 | NO | NO |  |
| CMSG_ITEM_QUERY_MULTIPLE | 87 | 0x0057 | NO | NO |  |
| CMSG_ITEM_QUERY_SINGLE | 86 | 0x0056 | NO | YES |  |
| CMSG_ITEM_TEXT_QUERY | 579 | 0x0243 | NO | YES |  |
| CMSG_KEEP_ALIVE | 1031 | 0x0407 | NO | YES |  |
| CMSG_LEARN_DANCE_MOVE | 1110 | 0x0456 | NO | NO |  |
| CMSG_LEARN_PREVIEW_TALENTS | 1217 | 0x04C1 | NO | NO |  |
| CMSG_LEARN_PREVIEW_TALENTS_PET | 1218 | 0x04C2 | NO | NO |  |
| CMSG_LEARN_SPELL | 16 | 0x0010 | NO | NO |  |
| CMSG_LEARN_TALENT | 593 | 0x0251 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4132 |
| CMSG_LEVEL_CHEAT | 37 | 0x0025 | NO | NO |  |
| CMSG_LFG_JOIN | 860 | 0x035C | NO | NO |  |
| CMSG_LFG_LEAVE | 861 | 0x035D | NO | NO |  |
| CMSG_LFG_LFR_JOIN | 862 | 0x035E | NO | NO |  |
| CMSG_LFG_LFR_LEAVE | 863 | 0x035F | NO | NO |  |
| CMSG_LFG_PARTY_LOCK_INFO_REQUEST | 881 | 0x0371 | NO | NO |  |
| CMSG_LFG_PLAYER_LOCK_INFO_REQUEST | 878 | 0x036E | NO | NO |  |
| CMSG_LFG_PROPOSAL_RESULT | 866 | 0x0362 | NO | NO |  |
| CMSG_LFG_SET_BOOT_VOTE | 876 | 0x036C | NO | NO |  |
| CMSG_LFG_SET_COMMENT | 870 | 0x0366 | NO | NO |  |
| CMSG_LFG_SET_NEEDS | 875 | 0x036B | NO | NO |  |
| CMSG_LFG_SET_ROLES | 874 | 0x036A | NO | NO |  |
| CMSG_LFG_TELEPORT | 880 | 0x0370 | NO | NO |  |
| CMSG_LIST_INVENTORY | 414 | 0x019E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3052 |
| CMSG_LOAD_DANCES | 1101 | 0x044D | NO | NO |  |
| CMSG_LOGOUT_CANCEL | 78 | 0x004E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:653 |
| CMSG_LOGOUT_REQUEST | 75 | 0x004B | YES | YES | HermesProxy/World/Server/WorldSocket.cs:646 |
| CMSG_LOOT_MASTER_GIVE | 675 | 0x02A3 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2244 |
| CMSG_LOOT_MONEY | 350 | 0x015E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2202 |
| CMSG_LOOT_RELEASE | 351 | 0x015F | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2173 |
| CMSG_LOOT_ROLL | 672 | 0x02A0 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2234 |
| CMSG_LOOT_UNIT | 349 | 0x015D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2193 |
| CMSG_LOTTERY_QUERY_OBSOLETE | 820 | 0x0334 | NO | NO |  |
| CMSG_LOW_LEVEL_RAID1 | 1288 | 0x0508 | NO | NO |  |
| CMSG_LOW_LEVEL_RAID2 | 1289 | 0x0509 | NO | NO |  |
| CMSG_LUA_USAGE | 803 | 0x0323 | NO | NO |  |
| CMSG_MAELSTROM_GM_SENT_MAIL | 917 | 0x0395 | NO | NO |  |
| CMSG_MAELSTROM_INVALIDATE_CACHE | 903 | 0x0387 | NO | NO |  |
| CMSG_MAELSTROM_RENAME_GUILD | 1024 | 0x0400 | NO | NO |  |
| CMSG_MAIL_CREATE_TEXT_ITEM | 586 | 0x024A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2272 |
| CMSG_MAIL_DELETE | 585 | 0x0249 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2285 |
| CMSG_MAIL_GET_LIST | 570 | 0x023A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2264 |
| CMSG_MAIL_MARK_AS_READ | 583 | 0x0247 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2298 |
| CMSG_MAIL_RETURN_TO_SENDER | 584 | 0x0248 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2307 |
| CMSG_MAIL_TAKE_ITEM | 582 | 0x0246 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2320 |
| CMSG_MAIL_TAKE_MONEY | 581 | 0x0245 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2333 |
| CMSG_MAKEMONSTERATTACKGUID | 22 | 0x0016 | NO | NO |  |
| CMSG_MESSAGECHAT | 149 | 0x0095 | NO | YES |  |
| CMSG_MINIGAME_MOVE | 760 | 0x02F8 | NO | NO |  |
| CMSG_MOUNT_SPECIAL_ANIM | 369 | 0x0171 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2478 |
| CMSG_MOVE_CHANGE_TRANSPORT | 909 | 0x038D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2836 |
| CMSG_MOVE_CHARACTER_CHEAT | 13 | 0x000D | NO | NO |  |
| CMSG_MOVE_CHARM_PORT_CHEAT | 224 | 0x00E0 | NO | NO |  |
| CMSG_MOVE_ENABLE_SWIM_TO_FLY_TRANS_ACK | 832 | 0x0340 | NO | NO |  |
| CMSG_MOVE_FALL_RESET | 714 | 0x02CA | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2839 |
| CMSG_MOVE_FEATHER_FALL_ACK | 719 | 0x02CF | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2959 |
| CMSG_MOVE_FORCE_FLIGHT_BACK_SPEED_CHANGE_ACK | 900 | 0x0384 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2910 |
| CMSG_MOVE_FORCE_FLIGHT_SPEED_CHANGE_ACK | 898 | 0x0382 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2911 |
| CMSG_MOVE_FORCE_PITCH_RATE_CHANGE_ACK | 1117 | 0x045D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2912 |
| CMSG_MOVE_FORCE_ROOT_ACK | 233 | 0x00E9 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2980 |
| CMSG_MOVE_FORCE_RUN_BACK_SPEED_CHANGE_ACK | 229 | 0x00E5 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2913 |
| CMSG_MOVE_FORCE_RUN_SPEED_CHANGE_ACK | 227 | 0x00E3 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2914 |
| CMSG_MOVE_FORCE_SWIM_BACK_SPEED_CHANGE_ACK | 733 | 0x02DD | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2915 |
| CMSG_MOVE_FORCE_SWIM_SPEED_CHANGE_ACK | 231 | 0x00E7 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2916 |
| CMSG_MOVE_FORCE_TURN_RATE_CHANGE_ACK | 735 | 0x02DF | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2917 |
| CMSG_MOVE_FORCE_UNROOT_ACK | 235 | 0x00EB | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2981 |
| CMSG_MOVE_FORCE_WALK_SPEED_CHANGE_ACK | 731 | 0x02DB | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2918 |
| CMSG_MOVE_GRAVITY_DISABLE_ACK | 1231 | 0x04CF | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2983 |
| CMSG_MOVE_GRAVITY_ENABLE_ACK | 1233 | 0x04D1 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2984 |
| CMSG_MOVE_HOVER_ACK | 246 | 0x00F6 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2960 |
| CMSG_MOVE_KNOCK_BACK_ACK | 240 | 0x00F0 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2982 |
| CMSG_MOVE_NOT_ACTIVE_MOVER | 721 | 0x02D1 | NO | NO |  |
| CMSG_MOVE_SET_CAN_FLY_ACK | 837 | 0x0345 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2961 |
| CMSG_MOVE_SET_COLLISION_HGT_ACK | 1303 | 0x0517 | NO | NO |  |
| CMSG_MOVE_SET_FLY | 838 | 0x0346 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2845 |
| CMSG_MOVE_SET_RAW_POSITION | 225 | 0x00E1 | NO | NO |  |
| CMSG_MOVE_SET_RUN_SPEED | 939 | 0x03AB | NO | NO |  |
| CMSG_MOVE_SPLINE_DONE | 713 | 0x02C9 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3017 |
| CMSG_MOVE_START_SWIM_CHEAT | 728 | 0x02D8 | NO | NO |  |
| CMSG_MOVE_STOP_SWIM_CHEAT | 729 | 0x02D9 | NO | NO |  |
| CMSG_MOVE_TIME_SKIPPED | 718 | 0x02CE | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3034 |
| CMSG_MOVE_WATER_WALK_ACK | 720 | 0x02D0 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2962 |
| CMSG_NAME_QUERY | 80 | 0x0050 | NO | NO |  |
| CMSG_NEW_SPELL_SLOT | 301 | 0x012D | NO | NO |  |
| CMSG_NEXT_CINEMATIC_CAMERA | 251 | 0x00FB | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2461 |
| CMSG_NO_SPELL_VARIANCE | 1046 | 0x0416 | NO | NO |  |
| CMSG_OFFER_PETITION | 451 | 0x01C3 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3312 |
| CMSG_OPENING_CINEMATIC | 249 | 0x00F9 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2460 |
| CMSG_OPEN_ITEM | 172 | 0x00AC | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2128 |
| CMSG_OPT_OUT_OF_LOOT | 1033 | 0x0409 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2219 |
| CMSG_PARTY_INVITE | 110 | 0x006E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1166 |
| CMSG_PARTY_SILENCE | 989 | 0x03DD | NO | NO |  |
| CMSG_PARTY_UNSILENCE | 990 | 0x03DE | NO | NO |  |
| CMSG_PERFORM_ACTION_SET | 332 | 0x014C | NO | NO |  |
| CMSG_PETGODMODE | 28 | 0x001C | NO | NO |  |
| CMSG_PETITION_BUY | 445 | 0x01BD | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3243 |
| CMSG_PETITION_SHOW_LIST | 443 | 0x01BB | NO | NO |  |
| CMSG_PETITION_SHOW_SIGNATURES | 446 | 0x01BE | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3286 |
| CMSG_PET_ABANDON | 374 | 0x0176 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3193 |
| CMSG_PET_ACTION | 373 | 0x0175 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3129 |
| CMSG_PET_CANCEL_AURA | 619 | 0x026B | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3227 |
| CMSG_PET_CAST_SPELL | 496 | 0x01F0 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3945 |
| CMSG_PET_LEARN_TALENT | 1146 | 0x047A | NO | NO |  |
| CMSG_PET_LEVEL_CHEAT | 38 | 0x0026 | NO | NO |  |
| CMSG_PET_RENAME | 375 | 0x0177 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3157 |
| CMSG_PET_SET_ACTION | 372 | 0x0174 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3147 |
| CMSG_PET_SPELL_AUTOCAST | 755 | 0x02F3 | NO | NO |  |
| CMSG_PET_STOP_ATTACK | 746 | 0x02EA | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3139 |
| CMSG_PET_UNLEARN | 752 | 0x02F0 | NO | NO |  |
| CMSG_PET_UNLEARN_TALENTS | 1147 | 0x047B | NO | NO |  |
| CMSG_PING | 476 | 0x01DC | NO | YES |  |
| CMSG_PLAYER_AI_CHEAT | 620 | 0x026C | NO | YES |  |
| CMSG_PLAYER_LOGIN | 61 | 0x003D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:616 |
| CMSG_PLAYER_LOGOUT | 74 | 0x004A | NO | NO |  |
| CMSG_PLAYER_SHOWING_CLOAK | 698 | 0x02BA | YES | NO | HermesProxy/World/Server/WorldSocket.cs:721 |
| CMSG_PLAYER_SHOWING_HELM | 697 | 0x02B9 | YES | NO | HermesProxy/World/Server/WorldSocket.cs:722 |
| CMSG_PLAYER_VEHICLE_ENTER | 1192 | 0x04A8 | NO | NO |  |
| CMSG_PLAY_DANCE | 1099 | 0x044B | NO | NO |  |
| CMSG_PROFILEDATA_REQUEST | 1225 | 0x04C9 | NO | NO |  |
| CMSG_PUSH_QUEST_TO_PARTY | 413 | 0x019D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3596 |
| CMSG_PVP_QUEUE_STATS_REQUEST | 1243 | 0x04DB | NO | NO |  |
| CMSG_QUERY_CREATURE | 96 | 0x0060 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3373 |
| CMSG_QUERY_GAME_OBJECT | 94 | 0x005E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3382 |
| CMSG_QUERY_GUILD_INFO | 84 | 0x0054 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1341 |
| CMSG_QUERY_INSPECT_ACHIEVEMENTS | 1131 | 0x046B | NO | NO |  |
| CMSG_QUERY_NPC_TEXT | 383 | 0x017F | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3411 |
| CMSG_QUERY_OBJECT_POSITION | 4 | 0x0004 | NO | NO |  |
| CMSG_QUERY_OBJECT_ROTATION | 6 | 0x0006 | NO | NO |  |
| CMSG_QUERY_PAGE_TEXT | 90 | 0x005A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3402 |
| CMSG_QUERY_PETITION | 454 | 0x01C6 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3294 |
| CMSG_QUERY_PET_NAME | 82 | 0x0052 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3420 |
| CMSG_QUERY_QUESTS_COMPLETED | 1280 | 0x0500 | NO | YES |  |
| CMSG_QUERY_QUEST_COMPLETION_NPCS | 1161 | 0x0489 | NO | NO |  |
| CMSG_QUERY_QUEST_INFO | 92 | 0x005C | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3365 |
| CMSG_QUERY_SERVER_BUCK_DATA | 1051 | 0x041B | NO | NO |  |
| CMSG_QUERY_TIME | 462 | 0x01CE | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3358 |
| CMSG_QUERY_VEHICLE_STATUS | 1189 | 0x04A5 | NO | NO |  |
| CMSG_QUEST_CONFIRM_ACCEPT | 411 | 0x019B | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3588 |
| CMSG_QUEST_GIVER_ACCEPT_QUEST | 393 | 0x0189 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3466 |
| CMSG_QUEST_GIVER_CANCEL | 400 | 0x0190 | NO | NO |  |
| CMSG_QUEST_GIVER_CHOOSE_REWARD | 398 | 0x018E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3544 |
| CMSG_QUEST_GIVER_COMPLETE_QUEST | 394 | 0x018A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3579 |
| CMSG_QUEST_GIVER_HELLO | 388 | 0x0184 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3527 |
| CMSG_QUEST_GIVER_QUERY_QUEST | 390 | 0x0186 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3453 |
| CMSG_QUEST_GIVER_QUEST_AUTOLAUNCH | 391 | 0x0187 | NO | NO |  |
| CMSG_QUEST_GIVER_REQUEST_REWARD | 396 | 0x018C | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3535 |
| CMSG_QUEST_GIVER_STATUS_MULTIPLE_QUERY | 1047 | 0x0417 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3495 |
| CMSG_QUEST_GIVER_STATUS_QUERY | 386 | 0x0182 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3487 |
| CMSG_QUEST_LOG_REMOVE_QUEST | 404 | 0x0194 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3479 |
| CMSG_QUEST_LOG_SWAP_QUEST | 403 | 0x0193 | NO | NO |  |
| CMSG_QUEST_POI_QUERY | 483 | 0x01E3 | NO | YES |  |
| CMSG_READY_FOR_ACCOUNT_DATA_TIMES | 1279 | 0x04FF | NO | NO |  |
| CMSG_READ_ITEM | 173 | 0x00AD | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2079 |
| CMSG_REALM_SPLIT | 908 | 0x038C | NO | NO |  |
| CMSG_RECHARGE | 15 | 0x000F | NO | NO |  |
| CMSG_RECLAIM_CORPSE | 466 | 0x01D2 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2444 |
| CMSG_REFER_A_FRIEND | 1038 | 0x040E | NO | NO |  |
| CMSG_REMOVE_GLYPH | 1162 | 0x048A | NO | YES |  |
| CMSG_REPAIR_ITEM | 680 | 0x02A8 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2100 |
| CMSG_REPOP_REQUEST | 346 | 0x015A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2426 |
| CMSG_REPORT_PVP_PLAYER_AFK | 996 | 0x03E4 | NO | NO |  |
| CMSG_REQUEST_ACCOUNT_DATA | 522 | 0x020A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1075 |
| CMSG_REQUEST_PARTY_MEMBER_STATS | 639 | 0x027F | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1315 |
| CMSG_REQUEST_PET_INFO | 633 | 0x0279 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3236 |
| CMSG_REQUEST_PLAYED_TIME | 460 | 0x01CC | YES | YES | HermesProxy/World/Server/WorldSocket.cs:660 |
| CMSG_REQUEST_RAID_INFO | 717 | 0x02CD | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1946 |
| CMSG_REQUEST_VEHICLE_EXIT | 1142 | 0x0476 | NO | YES |  |
| CMSG_REQUEST_VEHICLE_NEXT_SEAT | 1144 | 0x0478 | NO | YES |  |
| CMSG_REQUEST_VEHICLE_PREV_SEAT | 1143 | 0x0477 | NO | YES |  |
| CMSG_REQUEST_VEHICLE_SWITCH_SEAT | 1145 | 0x0479 | NO | YES |  |
| CMSG_RESET_FACTION_CHEAT | 641 | 0x0281 | NO | YES |  |
| CMSG_RESET_INSTANCES | 797 | 0x031D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1939 |
| CMSG_RESURRECT_RESPONSE | 348 | 0x015C | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4141 |
| CMSG_RUN_SCRIPT | 693 | 0x02B5 | NO | NO |  |
| CMSG_SAVE_DANCE | 1097 | 0x0449 | NO | NO |  |
| CMSG_SAVE_EQUIPMENT_SET | 1213 | 0x04BD | NO | NO |  |
| CMSG_SAVE_PLAYER | 339 | 0x0153 | NO | NO |  |
| CMSG_SELF_RES | 691 | 0x02B3 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4150 |
| CMSG_SELL_ITEM | 416 | 0x01A0 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1973 |
| CMSG_SEND_COMBAT_TRIGGER | 916 | 0x0394 | NO | NO |  |
| CMSG_SEND_EVENT | 45 | 0x002D | NO | NO |  |
| CMSG_SEND_GENERAL_TRIGGER | 915 | 0x0393 | NO | NO |  |
| CMSG_SEND_LOCAL_EVENT | 914 | 0x0392 | NO | NO |  |
| CMSG_SEND_MAIL | 568 | 0x0238 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2375 |
| CMSG_SEND_TEXT_EMOTE | 260 | 0x0104 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1016 |
| CMSG_SERVERINFO | 1268 | 0x04F4 | NO | NO |  |
| CMSG_SERVERTIME | 72 | 0x0048 | NO | NO |  |
| CMSG_SERVER_BROADCAST | 690 | 0x02B2 | NO | NO |  |
| CMSG_SERVER_COMMAND | 551 | 0x0227 | NO | NO |  |
| CMSG_SERVER_INFO_QUERY | 1184 | 0x04A0 | NO | NO |  |
| CMSG_SETDEATHBINDPOINT | 340 | 0x0154 | NO | NO |  |
| CMSG_SET_ACTION_BAR_TOGGLES | 703 | 0x02BF | YES | YES | HermesProxy/World/Server/WorldSocket.cs:705 |
| CMSG_SET_ACTION_BUTTON | 296 | 0x0128 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:695 |
| CMSG_SET_ACTIVE_MOVER | 618 | 0x026A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3001 |
| CMSG_SET_ACTIVE_TALENT_GROUP_OBSOLETE | 1219 | 0x04C3 | NO | NO |  |
| CMSG_SET_ACTIVE_VOICE_CHANNEL | 979 | 0x03D3 | NO | NO |  |
| CMSG_SET_AMMO | 616 | 0x0268 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2139 |
| CMSG_SET_ARENA_MEMBER_SEASON_GAMES | 1201 | 0x04B1 | NO | NO |  |
| CMSG_SET_ARENA_MEMBER_WEEKLY_GAMES | 1200 | 0x04B0 | NO | NO |  |
| CMSG_SET_ARENA_TEAM_RATING_BY_INDEX | 1197 | 0x04AD | NO | NO |  |
| CMSG_SET_ARENA_TEAM_SEASON_GAMES | 1199 | 0x04AF | NO | NO |  |
| CMSG_SET_ARENA_TEAM_WEEKLY_GAMES | 1198 | 0x04AE | NO | NO |  |
| CMSG_SET_ASSISTANT_LEADER | 655 | 0x028F | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1217 |
| CMSG_SET_BREATH | 1188 | 0x04A4 | NO | NO |  |
| CMSG_SET_CHANNEL_WATCH | 1007 | 0x03EF | NO | NO |  |
| CMSG_SET_CHARACTER_MODEL | 1292 | 0x050C | NO | NO |  |
| CMSG_SET_CONTACT_NOTES | 107 | 0x006B | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3726 |
| CMSG_SET_CRITERIA_CHEAT | 1136 | 0x0470 | NO | NO |  |
| CMSG_SET_DURABILITY_CHEAT | 647 | 0x0287 | NO | NO |  |
| CMSG_SET_EXPLORATION | 702 | 0x02BE | NO | NO |  |
| CMSG_SET_EXPLORATION_ALL | 795 | 0x031B | NO | NO |  |
| CMSG_SET_FACTION_AT_WAR | 293 | 0x0125 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3613 |
| CMSG_SET_FACTION_CHEAT | 294 | 0x0126 | NO | NO |  |
| CMSG_SET_FACTION_INACTIVE | 791 | 0x0317 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3631 |
| CMSG_SET_GLYPH | 1127 | 0x0467 | NO | NO |  |
| CMSG_SET_GLYPH_SLOT | 1126 | 0x0466 | NO | NO |  |
| CMSG_SET_GRANTABLE_LEVELS | 1036 | 0x040C | NO | NO |  |
| CMSG_SET_LOOT_METHOD | 122 | 0x007A | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2209 |
| CMSG_SET_PAID_SERVICE_CHEAT | 1245 | 0x04DD | NO | NO |  |
| CMSG_SET_PARTY_LEADER | 120 | 0x0078 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1242 |
| CMSG_SET_PLAYER_DECLINED_NAMES | 1049 | 0x0419 | NO | NO |  |
| CMSG_SET_PVP_RANK_CHEAT | 648 | 0x0288 | NO | NO |  |
| CMSG_SET_PVP_TITLE | 651 | 0x028B | NO | NO |  |
| CMSG_SET_RUNE_COOLDOWN | 1113 | 0x0459 | NO | NO |  |
| CMSG_SET_RUNE_COUNT | 1112 | 0x0458 | NO | NO |  |
| CMSG_SET_SAVED_INSTANCE_EXTEND | 658 | 0x0292 | NO | NO |  |
| CMSG_SET_SELECTION | 317 | 0x013D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2418 |
| CMSG_SET_SHEATHED | 480 | 0x01E0 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1113 |
| CMSG_SET_SKILL_CHEAT | 472 | 0x01D8 | NO | NO |  |
| CMSG_SET_STAT_CHEAT | 541 | 0x021D | NO | NO |  |
| CMSG_SET_TAXI_BENCHMARK_MODE | 905 | 0x0389 | NO | NO |  |
| CMSG_SET_TITLE | 884 | 0x0374 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:672 |
| CMSG_SET_TITLE_SUFFIX | 1015 | 0x03F7 | NO | NO |  |
| CMSG_SET_TRADE_GOLD | 287 | 0x011F | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4368 |
| CMSG_SET_TRADE_ITEM | 285 | 0x011D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4421 |
| CMSG_SET_VEHICLE_REC_ID_ACK | 576 | 0x0240 | NO | NO |  |
| CMSG_SET_WATCHED_FACTION | 792 | 0x0318 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3640 |
| CMSG_SET_WORLDSTATE | 39 | 0x0027 | NO | NO |  |
| CMSG_SIGN_PETITION | 448 | 0x01C0 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3333 |
| CMSG_SKILL_BUY_RANK | 544 | 0x0220 | NO | NO |  |
| CMSG_SKILL_BUY_STEP | 543 | 0x021F | NO | NO |  |
| CMSG_SOCKET_GEMS | 839 | 0x0347 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2113 |
| CMSG_SPELL_CLICK | 1016 | 0x03F8 | NO | YES |  |
| CMSG_SPIRIT_HEALER_ACTIVATE | 540 | 0x021C | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3053 |
| CMSG_SPLIT_ITEM | 270 | 0x010E | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1993 |
| CMSG_STABLE_PET | 624 | 0x0270 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3201 |
| CMSG_STABLE_REVIVE_PET | 628 | 0x0274 | NO | YES |  |
| CMSG_STABLE_SWAP_PET | 629 | 0x0275 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3218 |
| CMSG_STAND_STATE_CHANGE | 257 | 0x0101 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2452 |
| CMSG_START_BATTLEFIELD_CHEAT | 1227 | 0x04CB | NO | NO |  |
| CMSG_STOP_DANCE | 1102 | 0x044E | NO | NO |  |
| CMSG_STORE_LOOT_IN_SLOT | 265 | 0x0109 | NO | NO |  |
| CMSG_SUMMON_RESPONSE | 684 | 0x02AC | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1286 |
| CMSG_SUSPEND_COMMS_ACK | 1296 | 0x0510 | NO | NO |  |
| CMSG_SWAP_INV_ITEM | 269 | 0x010D | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2016 |
| CMSG_SWAP_ITEM | 268 | 0x010C | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2029 |
| CMSG_SYNC_DANCE | 1104 | 0x0450 | NO | NO |  |
| CMSG_TALK_TO_GOSSIP | 379 | 0x017B | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3054 |
| CMSG_TARGET_CAST | 976 | 0x03D0 | NO | NO |  |
| CMSG_TARGET_SCRIPT_CAST | 977 | 0x03D1 | NO | NO |  |
| CMSG_TAXICLEARALLNODES | 422 | 0x01A6 | NO | NO |  |
| CMSG_TAXICLEARNODE | 577 | 0x0241 | NO | NO |  |
| CMSG_TAXIENABLEALLNODES | 423 | 0x01A7 | NO | NO |  |
| CMSG_TAXIENABLENODE | 578 | 0x0242 | NO | NO |  |
| CMSG_TAXISHOWNODES | 424 | 0x01A8 | NO | NO |  |
| CMSG_TAXI_NODE_STATUS_QUERY | 426 | 0x01AA | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4217 |
| CMSG_TAXI_QUERY_AVAILABLE_NODES | 428 | 0x01AC | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4218 |
| CMSG_TELEPORT_TO_UNIT | 9 | 0x0009 | NO | NO |  |
| CMSG_TEST_DROP_RATE | 660 | 0x0294 | NO | NO |  |
| CMSG_TIME_SYNC_RESPONSE | 913 | 0x0391 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2394 |
| CMSG_TOGGLE_PVP | 595 | 0x0253 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:680 |
| CMSG_TOGGLE_XP_GAIN | 1260 | 0x04EC | NO | NO |  |
| CMSG_TOTEM_DESTROYED | 1044 | 0x0414 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4157 |
| CMSG_TRAINER_BUY_SPELL | 434 | 0x01B2 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3091 |
| CMSG_TRAINER_LIST | 432 | 0x01B0 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3055 |
| CMSG_TRIGGER_CINEMATIC_CHEAT | 248 | 0x00F8 | NO | NO |  |
| CMSG_TURN_IN_PETITION | 452 | 0x01C4 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3342 |
| CMSG_TUTORIAL_CLEAR | 255 | 0x00FF | NO | NO |  |
| CMSG_TUTORIAL_FLAG | 254 | 0x00FE | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2485; HermesProxy/World/Server/WorldSocket.cs:2796 |
| CMSG_TUTORIAL_RESET | 256 | 0x0100 | NO | NO |  |
| CMSG_UI_TIME_REQUEST | 1270 | 0x04F6 | NO | NO |  |
| CMSG_UNACCEPT_TRADE | 283 | 0x011B | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4396 |
| CMSG_UNCLAIM_LICENSE | 272 | 0x0110 | NO | NO |  |
| CMSG_UNDRESSPLAYER | 32 | 0x0020 | NO | NO |  |
| CMSG_UNITANIMTIER_CHEAT | 1138 | 0x0472 | NO | NO |  |
| CMSG_UNLEARN_DANCE_MOVE | 1111 | 0x0457 | NO | NO |  |
| CMSG_UNLEARN_SKILL | 514 | 0x0202 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:713 |
| CMSG_UNLEARN_SPELL | 513 | 0x0201 | NO | NO |  |
| CMSG_UNLEARN_TALENTS | 531 | 0x0213 | NO | NO |  |
| CMSG_UNSTABLE_PET | 625 | 0x0271 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3209 |
| CMSG_UNUSED5 | 1208 | 0x04B8 | NO | NO |  |
| CMSG_UNUSED6 | 1209 | 0x04B9 | NO | NO |  |
| CMSG_UPDATE_ACCOUNT_DATA | 523 | 0x020B | YES | YES | HermesProxy/World/Server/WorldSocket.cs:1069 |
| CMSG_UPDATE_MISSILE_TRAJECTORY | 1122 | 0x0462 | NO | YES |  |
| CMSG_UPDATE_PROJECTILE_POSITION | 1214 | 0x04BE | NO | NO |  |
| CMSG_USE_ITEM | 171 | 0x00AB | YES | YES | HermesProxy/World/Server/WorldSocket.cs:4001 |
| CMSG_USE_SKILL_CHEAT | 41 | 0x0029 | NO | NO |  |
| CMSG_VOICE_ADD_IGNORE | 987 | 0x03DB | NO | NO |  |
| CMSG_VOICE_DEL_IGNORE | 988 | 0x03DC | NO | NO |  |
| CMSG_VOICE_SESSION_ENABLE | 943 | 0x03AF | NO | NO |  |
| CMSG_VOICE_SET_TALKER_MUTED_REQUEST | 929 | 0x03A1 | NO | NO |  |
| CMSG_WARDEN_DATA | 743 | 0x02E7 | NO | YES |  |
| CMSG_WEATHER_SPEED_CHEAT | 31 | 0x001F | NO | NO |  |
| CMSG_WHO | 98 | 0x0062 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:3429 |
| CMSG_WHO_IS | 100 | 0x0064 | NO | NO |  |
| CMSG_WORLD_TELEPORT | 8 | 0x0008 | NO | NO |  |
| CMSG_WRAP_ITEM | 467 | 0x01D3 | YES | YES | HermesProxy/World/Server/WorldSocket.cs:2158 |
| CMSG_XP_CHEAT | 545 | 0x0221 | NO | NO |  |
| CMSG_ZONEUPDATE | 500 | 0x01F4 | NO | YES |  |
| CMSG_ZONE_MAP | 10 | 0x000A | NO | NO |  |

## SMSG (Server -> Client)

| Opcode | Value (Dec) | Value (Hex) | Handled | Modern Match | Handler Location |
|--------|-------------|-------------|---------|--------------|------------------|
| SMSG_ACCOUNT_DATA_TIMES | 521 | 0x0209 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4815 |
| SMSG_ACHIEVEMENT_DELETED | 1183 | 0x049F | NO | YES |  |
| SMSG_ACHIEVEMENT_EARNED | 1128 | 0x0468 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5178 |
| SMSG_ACTIVATE_TAXI_REPLY | 430 | 0x01AE | YES | YES | HermesProxy/World/Client/WorldClient.cs:8926 |
| SMSG_ADDON_INFO | 751 | 0x02EF | NO | YES |  |
| SMSG_ADD_RUNE_POWER | 1160 | 0x0488 | NO | NO |  |
| SMSG_AFK_MONITOR_INFO_RESPONSE | 1284 | 0x0504 | NO | NO |  |
| SMSG_AI_REACTION | 316 | 0x013C | YES | YES | HermesProxy/World/Client/WorldClient.cs:2185 |
| SMSG_ALL_ACHIEVEMENT_DATA | 1149 | 0x047D | YES | YES | HermesProxy/World/Client/WorldClient.cs:5102 |
| SMSG_AREA_SPIRIT_HEALER_TIME | 740 | 0x02E4 | YES | YES | HermesProxy/World/Client/WorldClient.cs:815 |
| SMSG_AREA_TRIGGER_MESSAGE | 696 | 0x02B8 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4915 |
| SMSG_AREA_TRIGGER_NO_CORPSE | 1286 | 0x0506 | NO | NO |  |
| SMSG_ARENA_ERROR | 886 | 0x0376 | NO | NO |  |
| SMSG_ARENA_OPPONENT_UPDATE | 1223 | 0x04C7 | NO | NO |  |
| SMSG_ARENA_TEAM_CHANGE_FAILED_QUEUED | 1224 | 0x04C8 | NO | NO |  |
| SMSG_ARENA_TEAM_COMMAND_RESULT | 841 | 0x0349 | YES | YES | HermesProxy/World/Client/WorldClient.cs:173 |
| SMSG_ARENA_TEAM_EVENT | 855 | 0x0357 | YES | YES | HermesProxy/World/Client/WorldClient.cs:143 |
| SMSG_ARENA_TEAM_INVITE | 848 | 0x0350 | YES | YES | HermesProxy/World/Client/WorldClient.cs:185 |
| SMSG_ARENA_TEAM_QUERY_RESPONSE | 844 | 0x034C | YES | NO | HermesProxy/World/Client/WorldClient.cs:61 |
| SMSG_ARENA_TEAM_ROSTER | 846 | 0x034E | YES | YES | HermesProxy/World/Client/WorldClient.cs:96 |
| SMSG_ARENA_TEAM_STATS | 859 | 0x035B | YES | YES | HermesProxy/World/Client/WorldClient.cs:79 |
| SMSG_ATTACKER_STATE_UPDATE | 330 | 0x014A | YES | YES | HermesProxy/World/Client/WorldClient.cs:2067 |
| SMSG_ATTACKSWING_BADFACING | 326 | 0x0146 | YES | NO | HermesProxy/World/Client/WorldClient.cs:2154 |
| SMSG_ATTACKSWING_CANT_ATTACK | 329 | 0x0149 | YES | NO | HermesProxy/World/Client/WorldClient.cs:2170 |
| SMSG_ATTACKSWING_DEADTARGET | 328 | 0x0148 | YES | NO | HermesProxy/World/Client/WorldClient.cs:2162 |
| SMSG_ATTACKSWING_NOTINRANGE | 325 | 0x0145 | YES | NO | HermesProxy/World/Client/WorldClient.cs:2146 |
| SMSG_ATTACK_START | 323 | 0x0143 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2015 |
| SMSG_ATTACK_STOP | 324 | 0x0144 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2024 |
| SMSG_AUCTION_BIDDER_NOTIFICATION | 606 | 0x025E | YES | NO | HermesProxy/World/Client/WorldClient.cs:358 |
| SMSG_AUCTION_COMMAND_RESULT | 603 | 0x025B | YES | YES | HermesProxy/World/Client/WorldClient.cs:302 |
| SMSG_AUCTION_LIST_BIDDED_ITEMS_RESULT | 613 | 0x0265 | YES | NO | HermesProxy/World/Client/WorldClient.cs:264 |
| SMSG_AUCTION_LIST_ITEMS_RESULT | 604 | 0x025C | YES | YES | HermesProxy/World/Client/WorldClient.cs:283 |
| SMSG_AUCTION_LIST_OWNED_ITEMS_RESULT | 605 | 0x025D | YES | NO | HermesProxy/World/Client/WorldClient.cs:265 |
| SMSG_AUCTION_LIST_PENDING_SALES | 1168 | 0x0490 | NO | NO |  |
| SMSG_AUCTION_OWNER_NOTIFICATION | 607 | 0x025F | YES | NO | HermesProxy/World/Client/WorldClient.cs:329 |
| SMSG_AUCTION_REMOVED_NOTIFICATION | 653 | 0x028D | NO | YES |  |
| SMSG_AURACASTLOG | 465 | 0x01D1 | NO | NO |  |
| SMSG_AURA_UPDATE | 1174 | 0x0496 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8687 |
| SMSG_AURA_UPDATE_ALL | 1173 | 0x0495 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8702 |
| SMSG_AUTH_CHALLENGE | 492 | 0x01EC | NO | YES |  |
| SMSG_AUTH_RESPONSE | 494 | 0x01EE | NO | YES |  |
| SMSG_AUTH_SRP6_RESPONSE | 57 | 0x0039 | NO | NO |  |
| SMSG_AVAILABLE_VOICE_CHANNEL | 986 | 0x03DA | NO | NO |  |
| SMSG_BARBER_SHOP_RESULT | 1064 | 0x0428 | NO | NO |  |
| SMSG_BATTLEFIELD_LIST | 573 | 0x023D | YES | YES | HermesProxy/World/Client/WorldClient.cs:385; HermesProxy/World/Client/WorldClient.cs:402 |
| SMSG_BATTLEFIELD_MGR_EJECTED | 1254 | 0x04E6 | NO | NO |  |
| SMSG_BATTLEFIELD_MGR_EJECT_PENDING | 1253 | 0x04E5 | NO | NO |  |
| SMSG_BATTLEFIELD_MGR_ENTERING | 1248 | 0x04E0 | NO | NO |  |
| SMSG_BATTLEFIELD_MGR_ENTRY_INVITE | 1246 | 0x04DE | NO | NO |  |
| SMSG_BATTLEFIELD_MGR_QUEUE_INVITE | 1249 | 0x04E1 | NO | NO |  |
| SMSG_BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE | 1252 | 0x04E4 | NO | NO |  |
| SMSG_BATTLEFIELD_MGR_STATE_CHANGE | 1256 | 0x04E8 | NO | NO |  |
| SMSG_BATTLEFIELD_PORT_DENIED | 331 | 0x014B | NO | NO |  |
| SMSG_BATTLEFIELD_STATUS | 724 | 0x02D4 | YES | YES | HermesProxy/World/Client/WorldClient.cs:452; HermesProxy/World/Client/WorldClient.cs:538 |
| SMSG_BATTLEFIELD_STATUS_QUEUED | 744 | 0x02E8 | NO | YES |  |
| SMSG_BATTLEGROUND_INFO_THROTTLED | 1190 | 0x04A6 | NO | NO |  |
| SMSG_BATTLEGROUND_PLAYER_JOINED | 748 | 0x02EC | YES | YES | HermesProxy/World/Client/WorldClient.cs:806 |
| SMSG_BATTLEGROUND_PLAYER_LEFT | 749 | 0x02ED | YES | YES | HermesProxy/World/Client/WorldClient.cs:807 |
| SMSG_BINDER_CONFIRM | 747 | 0x02EB | YES | YES | HermesProxy/World/Client/WorldClient.cs:5980 |
| SMSG_BINDZONEREPLY | 343 | 0x0157 | NO | NO |  |
| SMSG_BIND_POINT_UPDATE | 341 | 0x0155 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4828 |
| SMSG_BREAK_TARGET | 338 | 0x0152 | NO | NO |  |
| SMSG_BUY_BANK_SLOT_RESULT | 442 | 0x01BA | NO | NO |  |
| SMSG_BUY_FAILED | 421 | 0x01A5 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4161 |
| SMSG_BUY_SUCCEEDED | 420 | 0x01A4 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4071 |
| SMSG_CACHE_VERSION | 1195 | 0x04AB | YES | YES | HermesProxy/World/Client/WorldClient.cs:5385 |
| SMSG_CALENDAR_ARENA_TEAM | 1081 | 0x0439 | NO | NO |  |
| SMSG_CALENDAR_CLEAR_PENDING_ACTION | 1211 | 0x04BB | NO | NO |  |
| SMSG_CALENDAR_COMMAND_RESULT | 1085 | 0x043D | NO | NO |  |
| SMSG_CALENDAR_EVENT_INVITE | 1082 | 0x043A | NO | NO |  |
| SMSG_CALENDAR_EVENT_INVITE_ALERT | 1088 | 0x0440 | NO | NO |  |
| SMSG_CALENDAR_EVENT_INVITE_NOTES | 1120 | 0x0460 | NO | NO |  |
| SMSG_CALENDAR_EVENT_INVITE_NOTES_ALERT | 1121 | 0x0461 | NO | NO |  |
| SMSG_CALENDAR_EVENT_INVITE_REMOVED | 1083 | 0x043B | NO | NO |  |
| SMSG_CALENDAR_EVENT_INVITE_REMOVED_ALERT | 1089 | 0x0441 | NO | NO |  |
| SMSG_CALENDAR_EVENT_INVITE_STATUS_ALERT | 1090 | 0x0442 | NO | NO |  |
| SMSG_CALENDAR_EVENT_MODERATOR_STATUS_ALERT | 1093 | 0x0445 | NO | NO |  |
| SMSG_CALENDAR_EVENT_REMOVED_ALERT | 1091 | 0x0443 | NO | NO |  |
| SMSG_CALENDAR_EVENT_STATUS | 1084 | 0x043C | NO | NO |  |
| SMSG_CALENDAR_EVENT_UPDATED_ALERT | 1092 | 0x0444 | NO | NO |  |
| SMSG_CALENDAR_FILTER_GUILD | 1080 | 0x0438 | NO | NO |  |
| SMSG_CALENDAR_RAID_LOCKOUT_ADDED | 1086 | 0x043E | NO | NO |  |
| SMSG_CALENDAR_RAID_LOCKOUT_REMOVED | 1087 | 0x043F | NO | NO |  |
| SMSG_CALENDAR_RAID_LOCKOUT_UPDATED | 1137 | 0x0471 | NO | NO |  |
| SMSG_CALENDAR_SEND_CALENDAR | 1078 | 0x0436 | NO | NO |  |
| SMSG_CALENDAR_SEND_EVENT | 1079 | 0x0437 | NO | NO |  |
| SMSG_CALENDAR_SEND_NUM_PENDING | 1096 | 0x0448 | NO | NO |  |
| SMSG_CAMERA_SHAKE | 1290 | 0x050A | NO | NO |  |
| SMSG_CANCEL_AUTO_REPEAT | 668 | 0x029C | YES | YES | HermesProxy/World/Client/WorldClient.cs:8193 |
| SMSG_CANCEL_COMBAT | 334 | 0x014E | YES | YES | HermesProxy/World/Client/WorldClient.cs:2178 |
| SMSG_CAST_FAILED | 304 | 0x0130 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7724 |
| SMSG_CHANGE_PLAYER_DIFFICULTY_RESULT | 526 | 0x020E | NO | NO |  |
| SMSG_CHANNEL_LIST | 155 | 0x009B | YES | YES | HermesProxy/World/Client/WorldClient.cs:1598 |
| SMSG_CHANNEL_MEMBER_COUNT | 981 | 0x03D5 | NO | YES |  |
| SMSG_CHANNEL_NOTIFY | 153 | 0x0099 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1494 |
| SMSG_CHARACTER_LOGIN_FAILED | 65 | 0x0041 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1142 |
| SMSG_CHARACTER_PROFILE | 824 | 0x0338 | NO | NO |  |
| SMSG_CHARACTER_PROFILE_REALM_CONNECTED | 825 | 0x0339 | NO | NO |  |
| SMSG_CHARACTER_RENAME_RESULT | 712 | 0x02C8 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1480 |
| SMSG_CHAR_CUSTOMIZE | 1140 | 0x0474 | NO | NO |  |
| SMSG_CHAR_FACTION_CHANGE_RESULT | 1242 | 0x04DA | NO | NO |  |
| SMSG_CHAT | 150 | 0x0096 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1626; HermesProxy/World/Client/WorldClient.cs:1695 |
| SMSG_CHAT_NOT_IN_PARTY | 665 | 0x0299 | NO | NO |  |
| SMSG_CHAT_PLAYER_AMBIGUOUS | 813 | 0x032D | NO | NO |  |
| SMSG_CHAT_PLAYER_NOTFOUND | 681 | 0x02A9 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1951 |
| SMSG_CHAT_RESTRICTED | 765 | 0x02FD | NO | NO |  |
| SMSG_CHAT_SERVER_MESSAGE | 657 | 0x0291 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1969 |
| SMSG_CHAT_WRONG_FACTION | 537 | 0x0219 | NO | NO |  |
| SMSG_CHEAT_DUMP_ITEMS_DEBUG_ONLY_RESPONSE | 923 | 0x039B | NO | NO |  |
| SMSG_CHEAT_DUMP_ITEMS_DEBUG_ONLY_RESPONSE_WRITE_FILE | 924 | 0x039C | NO | NO |  |
| SMSG_CHEAT_PLAYER_LOOKUP | 964 | 0x03C4 | NO | NO |  |
| SMSG_CHECK_FOR_BOTS | 21 | 0x0015 | NO | NO |  |
| SMSG_CLEAR_COOLDOWN | 478 | 0x01DE | YES | YES | HermesProxy/World/Client/WorldClient.cs:8257 |
| SMSG_CLEAR_EXTRA_AURA_INFO_OBSOLETE | 934 | 0x03A6 | NO | NO |  |
| SMSG_CLEAR_FAR_SIGHT_IMMEDIATE | 525 | 0x020D | NO | NO |  |
| SMSG_CLEAR_TARGET | 959 | 0x03BF | NO | NO |  |
| SMSG_COMBAT_EVENT_FAILED | 609 | 0x0261 | NO | NO |  |
| SMSG_COMBAT_LOG_MULTIPLE | 1300 | 0x0514 | NO | NO |  |
| SMSG_COMMENTATOR_GET_PLAYER_INFO | 954 | 0x03BA | NO | NO |  |
| SMSG_COMMENTATOR_MAP_INFO | 952 | 0x03B8 | NO | NO |  |
| SMSG_COMMENTATOR_PLAYER_INFO | 955 | 0x03BB | NO | NO |  |
| SMSG_COMMENTATOR_SKIRMISH_QUEUE_RESULT1 | 1308 | 0x051C | NO | NO |  |
| SMSG_COMMENTATOR_SKIRMISH_QUEUE_RESULT2 | 1309 | 0x051D | NO | NO |  |
| SMSG_COMMENTATOR_STATE_CHANGED | 950 | 0x03B6 | NO | NO |  |
| SMSG_COMPLAINT_RESULT | 968 | 0x03C8 | NO | NO |  |
| SMSG_COMPRESSED_MOVES | 763 | 0x02FB | YES | NO | HermesProxy/World/Client/WorldClient.cs:5724 |
| SMSG_COMPRESSED_UPDATE_OBJECT | 502 | 0x01F6 | YES | YES | HermesProxy/World/Client/WorldClient.cs:9083 |
| SMSG_COMSAT_CONNECT_FAIL | 994 | 0x03E2 | NO | NO |  |
| SMSG_COMSAT_DISCONNECT | 993 | 0x03E1 | NO | NO |  |
| SMSG_COMSAT_RECONNECT_TRY | 992 | 0x03E0 | NO | NO |  |
| SMSG_CONNECT_TO | 1293 | 0x050D | NO | YES |  |
| SMSG_CONTACT_LIST | 103 | 0x0067 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7556 |
| SMSG_CONTROL_UPDATE | 345 | 0x0159 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5465 |
| SMSG_CONVERT_RUNE | 1158 | 0x0486 | NO | NO |  |
| SMSG_COOLDOWN_CHEAT | 481 | 0x01E1 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8267 |
| SMSG_COOLDOWN_EVENT | 309 | 0x0135 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8247 |
| SMSG_CORPSE_MAP_POSITION_QUERY_RESPONSE | 1207 | 0x04B7 | NO | NO |  |
| SMSG_CORPSE_RECLAIM_DELAY | 617 | 0x0269 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4856 |
| SMSG_CREATE_CHAR | 58 | 0x003A | YES | YES | HermesProxy/World/Client/WorldClient.cs:957 |
| SMSG_CRITERIA_DELETED | 1182 | 0x049E | NO | YES |  |
| SMSG_CRITERIA_UPDATE | 1130 | 0x046A | YES | YES | HermesProxy/World/Client/WorldClient.cs:5159 |
| SMSG_CROSSED_INEBRIATION_THRESHOLD | 961 | 0x03C1 | NO | NO |  |
| SMSG_DAMAGE_CALC_LOG | 636 | 0x027C | NO | NO |  |
| SMSG_DANCE_QUERY_RESPONSE | 1106 | 0x0452 | NO | NO |  |
| SMSG_DBLOOKUP | 3 | 0x0003 | NO | NO |  |
| SMSG_DEATH_RELEASE_LOC | 888 | 0x0378 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4847 |
| SMSG_DEBUGAURAPROC | 589 | 0x024D | NO | NO |  |
| SMSG_DEBUG_AISTATE | 47 | 0x002F | NO | NO |  |
| SMSG_DEBUG_LIST_TARGETS | 985 | 0x03D9 | NO | NO |  |
| SMSG_DEBUG_SERVER_GEO | 1276 | 0x04FC | NO | NO |  |
| SMSG_DEFENSE_MESSAGE | 826 | 0x033A | YES | YES | HermesProxy/World/Client/WorldClient.cs:1959 |
| SMSG_DELETE_CHAR | 60 | 0x003C | YES | YES | HermesProxy/World/Client/WorldClient.cs:967 |
| SMSG_DESTROY_OBJECT | 170 | 0x00AA | YES | YES | HermesProxy/World/Client/WorldClient.cs:9068 |
| SMSG_DESTRUCTIBLE_BUILDING_DAMAGE | 50 | 0x0032 | NO | NO |  |
| SMSG_DISMOUNT | 940 | 0x03AC | NO | NO |  |
| SMSG_DISMOUNT_RESULT | 367 | 0x016F | NO | NO |  |
| SMSG_DISPEL_FAILED | 610 | 0x0262 | NO | NO |  |
| SMSG_DUEL_COMPLETE | 362 | 0x016A | YES | YES | HermesProxy/World/Client/WorldClient.cs:2221 |
| SMSG_DUEL_COUNTDOWN | 695 | 0x02B7 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2213 |
| SMSG_DUEL_IN_BOUNDS | 361 | 0x0169 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2241 |
| SMSG_DUEL_OUT_OF_BOUNDS | 360 | 0x0168 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2248 |
| SMSG_DUEL_REQUESTED | 359 | 0x0167 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2203 |
| SMSG_DUEL_WINNER | 363 | 0x016B | YES | YES | HermesProxy/World/Client/WorldClient.cs:2229 |
| SMSG_DUMP_OBJECTS_DATA | 1164 | 0x048C | NO | NO |  |
| SMSG_DURABILITY_DAMAGE_DEATH | 701 | 0x02BD | YES | YES | HermesProxy/World/Client/WorldClient.cs:4232 |
| SMSG_DYNAMIC_DROP_ROLL_RESULT | 1129 | 0x0469 | NO | NO |  |
| SMSG_ECHO_PARTY_SQUELCH | 1014 | 0x03F6 | NO | NO |  |
| SMSG_EMOTE | 259 | 0x0103 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1919 |
| SMSG_ENABLE_BARBER_SHOP | 1063 | 0x0427 | NO | NO |  |
| SMSG_ENCHANTMENT_LOG | 471 | 0x01D7 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4272 |
| SMSG_ENUM_CHARACTERS_RESULT | 59 | 0x003B | YES | YES | HermesProxy/World/Client/WorldClient.cs:845 |
| SMSG_ENVIRONMENTAL_DAMAGE_LOG | 508 | 0x01FC | YES | YES | HermesProxy/World/Client/WorldClient.cs:8534 |
| SMSG_EQUIPMENT_SET_ID | 311 | 0x0137 | NO | NO |  |
| SMSG_EXPECTED_SPAM_RECORDS | 818 | 0x0332 | NO | YES |  |
| SMSG_EXPLORATION_EXPERIENCE | 504 | 0x01F8 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4967 |
| SMSG_FEATURE_SYSTEM_STATUS | 969 | 0x03C9 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8859 |
| SMSG_FEIGN_DEATH_RESISTED | 692 | 0x02B4 | NO | NO |  |
| SMSG_FISH_ESCAPED | 457 | 0x01C9 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2289 |
| SMSG_FISH_NOT_HOOKED | 456 | 0x01C8 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2282 |
| SMSG_FLIGHT_SPLINE_SYNC | 904 | 0x0388 | NO | NO |  |
| SMSG_FORCEACTIONSHOW | 27 | 0x001B | NO | NO |  |
| SMSG_FORCED_DEATH_UPDATE | 890 | 0x037A | NO | NO |  |
| SMSG_FORCE_ANIM | 1240 | 0x04D8 | NO | NO |  |
| SMSG_FORCE_DISPLAY_UPDATE | 1027 | 0x0403 | NO | NO |  |
| SMSG_FORCE_FLIGHT_BACK_SPEED_CHANGE | 899 | 0x0383 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5617 |
| SMSG_FORCE_FLIGHT_SPEED_CHANGE | 897 | 0x0381 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5616 |
| SMSG_FORCE_PITCH_RATE_CHANGE | 1116 | 0x045C | YES | NO | HermesProxy/World/Client/WorldClient.cs:5618 |
| SMSG_FORCE_RUN_BACK_SPEED_CHANGE | 228 | 0x00E4 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5612 |
| SMSG_FORCE_RUN_SPEED_CHANGE | 226 | 0x00E2 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5611 |
| SMSG_FORCE_SET_VEHICLE_REC_ID | 575 | 0x023F | NO | NO |  |
| SMSG_FORCE_SWIM_BACK_SPEED_CHANGE | 732 | 0x02DC | YES | NO | HermesProxy/World/Client/WorldClient.cs:5614 |
| SMSG_FORCE_SWIM_SPEED_CHANGE | 230 | 0x00E6 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5613 |
| SMSG_FORCE_TURN_RATE_CHANGE | 734 | 0x02DE | YES | YES | HermesProxy/World/Client/WorldClient.cs:5615 |
| SMSG_FORCE_WALK_SPEED_CHANGE | 730 | 0x02DA | YES | YES | HermesProxy/World/Client/WorldClient.cs:5610 |
| SMSG_FRIEND_STATUS | 104 | 0x0068 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7586 |
| SMSG_GAMETIMEBIAS_SET | 788 | 0x0314 | NO | NO |  |
| SMSG_GAME_OBJECT_CUSTOM_ANIM | 179 | 0x00B3 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2273 |
| SMSG_GAME_OBJECT_DESPAWN | 533 | 0x0215 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2255 |
| SMSG_GAME_OBJECT_RESET_STATE | 679 | 0x02A7 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2265 |
| SMSG_GAME_SPEED_SET | 71 | 0x0047 | NO | NO |  |
| SMSG_GAME_TIME_SET | 69 | 0x0045 | NO | NO |  |
| SMSG_GAME_TIME_UPDATE | 67 | 0x0043 | NO | NO |  |
| SMSG_GHOSTEE_GONE | 806 | 0x0326 | NO | NO |  |
| SMSG_GMRESPONSE_CREATE_TICKET | 1266 | 0x04F2 | NO | NO |  |
| SMSG_GMRESPONSE_DB_ERROR | 1262 | 0x04EE | NO | NO |  |
| SMSG_GMRESPONSE_RECEIVED | 1263 | 0x04EF | NO | NO |  |
| SMSG_GMRESPONSE_STATUS_UPDATE | 1265 | 0x04F1 | NO | NO |  |
| SMSG_GM_MESSAGECHAT | 947 | 0x03B3 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1696 |
| SMSG_GM_PLAYER_INFO | 560 | 0x0230 | NO | NO |  |
| SMSG_GM_TICKET_CREATE | 518 | 0x0206 | YES | NO | HermesProxy/World/Client/WorldClient.cs:8850 |
| SMSG_GM_TICKET_DELETE_TICKET | 536 | 0x0218 | NO | NO |  |
| SMSG_GM_TICKET_GET_SYSTEM_STATUS | 539 | 0x021B | NO | NO |  |
| SMSG_GM_TICKET_GET_TICKET | 530 | 0x0212 | NO | NO |  |
| SMSG_GM_TICKET_STATUS_UPDATE | 808 | 0x0328 | NO | YES |  |
| SMSG_GM_TICKET_UPDATE_TEXT | 520 | 0x0208 | NO | NO |  |
| SMSG_GOD_MODE | 35 | 0x0023 | NO | NO |  |
| SMSG_GOGOGO_OBSOLETE | 1013 | 0x03F5 | NO | NO |  |
| SMSG_GOSSIP_COMPLETE | 382 | 0x017E | YES | YES | HermesProxy/World/Client/WorldClient.cs:5961 |
| SMSG_GOSSIP_MESSAGE | 381 | 0x017D | YES | YES | HermesProxy/World/Client/WorldClient.cs:5919 |
| SMSG_GOSSIP_POI | 548 | 0x0224 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5968 |
| SMSG_GROUP_ACTION_THROTTLED | 1041 | 0x0411 | NO | NO |  |
| SMSG_GROUP_CANCEL | 113 | 0x0071 | NO | NO |  |
| SMSG_GROUP_DECLINE | 116 | 0x0074 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2320 |
| SMSG_GROUP_DESTROYED | 124 | 0x007C | NO | YES |  |
| SMSG_GROUP_LIST | 125 | 0x007D | YES | NO | HermesProxy/World/Client/WorldClient.cs:2362; HermesProxy/World/Client/WorldClient.cs:2471 |
| SMSG_GROUP_NEW_LEADER | 121 | 0x0079 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2601 |
| SMSG_GROUP_UNINVITE | 119 | 0x0077 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2594 |
| SMSG_GUILD_BANK_QUERY_RESULTS | 1000 | 0x03E8 | YES | YES | HermesProxy/World/Client/WorldClient.cs:3821 |
| SMSG_GUILD_COMMAND_RESULT | 147 | 0x0093 | YES | YES | HermesProxy/World/Client/WorldClient.cs:3477 |
| SMSG_GUILD_EVENT | 146 | 0x0092 | YES | NO | HermesProxy/World/Client/WorldClient.cs:3487 |
| SMSG_GUILD_INFO | 136 | 0x0088 | YES | NO | HermesProxy/World/Client/WorldClient.cs:3678 |
| SMSG_GUILD_INVITE | 131 | 0x0083 | YES | YES | HermesProxy/World/Client/WorldClient.cs:3784 |
| SMSG_GUILD_INVITE_DECLINED | 134 | 0x0086 | YES | YES | HermesProxy/World/Client/WorldClient.cs:3812 |
| SMSG_GUILD_ROSTER | 138 | 0x008A | YES | YES | HermesProxy/World/Client/WorldClient.cs:3705 |
| SMSG_HEALTH_UPDATE | 1151 | 0x047F | NO | YES |  |
| SMSG_HIGHEST_THREAT_UPDATE | 1154 | 0x0482 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2043 |
| SMSG_IGNORE_DIMINISHING_RETURNS_CHEAT | 1030 | 0x0406 | NO | NO |  |
| SMSG_IGNORE_REQUIREMENTS_CHEAT | 937 | 0x03A9 | NO | NO |  |
| SMSG_INITIALIZE_FACTIONS | 290 | 0x0122 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7436 |
| SMSG_INIT_EXTRA_AURA_INFO_OBSOLETE | 931 | 0x03A3 | NO | NO |  |
| SMSG_INIT_WORLD_STATES | 706 | 0x02C2 | YES | YES | HermesProxy/World/Client/WorldClient.cs:12186 |
| SMSG_INSPECT_RESULT | 277 | 0x0115 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1283 |
| SMSG_INSPECT_TALENT | 1012 | 0x03F4 | YES | NO | HermesProxy/World/Client/WorldClient.cs:1284 |
| SMSG_INSTANCE_DIFFICULTY | 827 | 0x033B | YES | NO | HermesProxy/World/Client/WorldClient.cs:5205 |
| SMSG_INSTANCE_LOCK_WARNING_QUERY | 327 | 0x0147 | NO | YES |  |
| SMSG_INSTANCE_RESET | 798 | 0x031E | YES | YES | HermesProxy/World/Client/WorldClient.cs:3951 |
| SMSG_INSTANCE_RESET_FAILED | 799 | 0x031F | YES | YES | HermesProxy/World/Client/WorldClient.cs:3959 |
| SMSG_INSTANCE_SAVE_CREATED | 715 | 0x02CB | YES | YES | HermesProxy/World/Client/WorldClient.cs:4018 |
| SMSG_INVALIDATE_DANCE | 1107 | 0x0453 | NO | NO |  |
| SMSG_INVALIDATE_PLAYER | 796 | 0x031C | YES | YES | HermesProxy/World/Client/WorldClient.cs:5049 |
| SMSG_INVALID_PROMOTION_CODE | 487 | 0x01E7 | NO | NO |  |
| SMSG_INVENTORY_CHANGE_FAILURE | 274 | 0x0112 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4171; HermesProxy/World/Client/WorldClient.cs:4196 |
| SMSG_ITEM_COOLDOWN | 176 | 0x00B0 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4240 |
| SMSG_ITEM_ENCHANT_TIME_UPDATE | 491 | 0x01EB | YES | YES | HermesProxy/World/Client/WorldClient.cs:4261 |
| SMSG_ITEM_NAME_QUERY_RESPONSE | 709 | 0x02C5 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6934 |
| SMSG_ITEM_PURCHASE_REFUND_RESULT | 1205 | 0x04B5 | NO | NO |  |
| SMSG_ITEM_PUSH_RESULT | 358 | 0x0166 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4082 |
| SMSG_ITEM_QUERY_MULTIPLE_RESPONSE | 89 | 0x0059 | NO | NO |  |
| SMSG_ITEM_QUERY_SINGLE_RESPONSE | 88 | 0x0058 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6827 |
| SMSG_ITEM_REFUND_INFO_RESPONSE | 1202 | 0x04B2 | NO | NO |  |
| SMSG_ITEM_TIME_UPDATE | 490 | 0x01EA | NO | NO |  |
| SMSG_JOINED_BATTLEGROUND_QUEUE | 906 | 0x038A | NO | NO |  |
| SMSG_KICK_REASON | 965 | 0x03C5 | NO | NO |  |
| SMSG_LEARNED_DANCE_MOVES | 1109 | 0x0455 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5380 |
| SMSG_LEARNED_SPELL | 299 | 0x012B | YES | NO | HermesProxy/World/Client/WorldClient.cs:7693 |
| SMSG_LEVEL_UP_INFO | 468 | 0x01D4 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1250 |
| SMSG_LFG_BOOT_PROPOSAL_UPDATE | 877 | 0x036D | NO | NO |  |
| SMSG_LFG_DISABLED | 920 | 0x0398 | NO | YES |  |
| SMSG_LFG_JOIN_RESULT | 868 | 0x0364 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5267 |
| SMSG_LFG_LFR_LIST | 864 | 0x0360 | NO | NO |  |
| SMSG_LFG_OFFER_CONTINUE | 659 | 0x0293 | NO | YES |  |
| SMSG_LFG_PARTY_INFO | 882 | 0x0372 | NO | YES |  |
| SMSG_LFG_PLAYER_INFO | 879 | 0x036F | YES | YES | HermesProxy/World/Client/WorldClient.cs:5210 |
| SMSG_LFG_PLAYER_REWARD | 511 | 0x01FF | NO | YES |  |
| SMSG_LFG_PROPOSAL_UPDATE | 865 | 0x0361 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5348 |
| SMSG_LFG_QUEUE_STATUS | 869 | 0x0365 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5327 |
| SMSG_LFG_ROLE_CHECK_UPDATE | 867 | 0x0363 | NO | YES |  |
| SMSG_LFG_ROLE_CHOSEN | 699 | 0x02BB | NO | NO |  |
| SMSG_LFG_TELEPORT_DENIED | 512 | 0x0200 | NO | NO |  |
| SMSG_LFG_UPDATE_PARTY | 872 | 0x0368 | NO | NO |  |
| SMSG_LFG_UPDATE_PLAYER | 871 | 0x0367 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5298 |
| SMSG_LFG_UPDATE_SEARCH | 873 | 0x0369 | NO | YES |  |
| SMSG_LOAD_EQUIPMENT_SET | 1212 | 0x04BC | YES | YES | HermesProxy/World/Client/WorldClient.cs:5200 |
| SMSG_LOGIN_SET_TIME_SPEED | 66 | 0x0042 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4897 |
| SMSG_LOGIN_VERIFY_WORLD | 566 | 0x0236 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1077 |
| SMSG_LOGOUT_CANCEL_ACK | 79 | 0x004F | YES | YES | HermesProxy/World/Client/WorldClient.cs:1207 |
| SMSG_LOGOUT_COMPLETE | 77 | 0x004D | YES | YES | HermesProxy/World/Client/WorldClient.cs:1197 |
| SMSG_LOGOUT_RESPONSE | 76 | 0x004C | YES | YES | HermesProxy/World/Client/WorldClient.cs:1188 |
| SMSG_LOG_XP_GAIN | 464 | 0x01D0 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1214 |
| SMSG_LOOT_ALL_PASSED | 670 | 0x029E | YES | YES | HermesProxy/World/Client/WorldClient.cs:4502 |
| SMSG_LOOT_CLEAR_MONEY | 357 | 0x0165 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4387 |
| SMSG_LOOT_ITEM_NOTIFY | 356 | 0x0164 | NO | NO |  |
| SMSG_LOOT_LIST | 1017 | 0x03F9 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4303 |
| SMSG_LOOT_MASTER_LIST | 676 | 0x02A4 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4519 |
| SMSG_LOOT_MONEY_NOTIFY | 355 | 0x0163 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4375 |
| SMSG_LOOT_RELEASE | 353 | 0x0161 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4354 |
| SMSG_LOOT_REMOVED | 354 | 0x0162 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4365 |
| SMSG_LOOT_RESPONSE | 352 | 0x0160 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4322 |
| SMSG_LOOT_ROLL | 674 | 0x02A2 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4441 |
| SMSG_LOOT_ROLL_WON | 671 | 0x029F | YES | YES | HermesProxy/World/Client/WorldClient.cs:4478 |
| SMSG_LOOT_SLOT_CHANGED | 1277 | 0x04FD | NO | NO |  |
| SMSG_LOOT_START_ROLL | 673 | 0x02A1 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4395 |
| SMSG_LOTTERY_QUERY_RESULT_OBSOLETE | 821 | 0x0335 | NO | NO |  |
| SMSG_LOTTERY_RESULT_OBSOLETE | 823 | 0x0337 | NO | NO |  |
| SMSG_MAIL_COMMAND_RESULT | 569 | 0x0239 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4774 |
| SMSG_MAIL_LIST_RESULT | 571 | 0x023B | YES | YES | HermesProxy/World/Client/WorldClient.cs:4584 |
| SMSG_MINIGAME_MOVE_FAILED | 761 | 0x02F9 | NO | NO |  |
| SMSG_MINIGAME_SETUP | 758 | 0x02F6 | NO | NO |  |
| SMSG_MINIGAME_STATE | 759 | 0x02F7 | NO | NO |  |
| SMSG_MIRROR_IMAGE_COMPONENTED_DATA | 1026 | 0x0402 | NO | NO |  |
| SMSG_MODIFY_COOLDOWN | 1169 | 0x0491 | NO | NO |  |
| SMSG_MONSTER_MOVE_TRANSPORT | 686 | 0x02AE | YES | YES | HermesProxy/World/Client/WorldClient.cs:5741 |
| SMSG_MOTD | 829 | 0x033D | YES | YES | HermesProxy/World/Client/WorldClient.cs:8865 |
| SMSG_MOUNT_RESULT | 366 | 0x016E | NO | YES |  |
| SMSG_MOVE_CHARACTER_CHEAT | 14 | 0x000E | NO | NO |  |
| SMSG_MOVE_DISABLE_GRAVITY | 1230 | 0x04CE | YES | YES | HermesProxy/World/Client/WorldClient.cs:5712 |
| SMSG_MOVE_DISABLE_TRANSITION_BETWEEN_SWIM_AND_FLY | 831 | 0x033F | YES | YES | HermesProxy/World/Client/WorldClient.cs:5711 |
| SMSG_MOVE_ENABLE_GRAVITY | 1232 | 0x04D0 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5713 |
| SMSG_MOVE_ENABLE_TRANSITION_BETWEEN_SWIM_AND_FLY | 830 | 0x033E | YES | YES | HermesProxy/World/Client/WorldClient.cs:5710 |
| SMSG_MOVE_KNOCK_BACK | 239 | 0x00EF | YES | YES | HermesProxy/World/Client/WorldClient.cs:5453 |
| SMSG_MOVE_ROOT | 232 | 0x00E8 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5702 |
| SMSG_MOVE_SET_CAN_FLY | 835 | 0x0343 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5708 |
| SMSG_MOVE_SET_COLLISION_HGT | 1302 | 0x0516 | NO | NO |  |
| SMSG_MOVE_SET_FEATHER_FALL | 242 | 0x00F2 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5714 |
| SMSG_MOVE_SET_HOVERING | 244 | 0x00F4 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5706 |
| SMSG_MOVE_SET_LAND_WALK | 223 | 0x00DF | YES | YES | HermesProxy/World/Client/WorldClient.cs:5705 |
| SMSG_MOVE_SET_NORMAL_FALL | 243 | 0x00F3 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5715 |
| SMSG_MOVE_SET_WATER_WALK | 222 | 0x00DE | YES | YES | HermesProxy/World/Client/WorldClient.cs:5704 |
| SMSG_MOVE_SPLINE_DISABLE_GRAVITY | 1235 | 0x04D3 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5682 |
| SMSG_MOVE_SPLINE_ENABLE_GRAVITY | 1236 | 0x04D4 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5681 |
| SMSG_MOVE_SPLINE_ROOT | 794 | 0x031A | YES | YES | HermesProxy/World/Client/WorldClient.cs:5679 |
| SMSG_MOVE_SPLINE_SET_FEATHER_FALL | 773 | 0x0305 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5683 |
| SMSG_MOVE_SPLINE_SET_FLIGHT_BACK_SPEED | 902 | 0x0386 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5592 |
| SMSG_MOVE_SPLINE_SET_FLIGHT_SPEED | 901 | 0x0385 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5593 |
| SMSG_MOVE_SPLINE_SET_FLYING | 1058 | 0x0422 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5693 |
| SMSG_MOVE_SPLINE_SET_HOVER | 775 | 0x0307 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5685 |
| SMSG_MOVE_SPLINE_SET_LAND_WALK | 778 | 0x030A | YES | YES | HermesProxy/World/Client/WorldClient.cs:5688 |
| SMSG_MOVE_SPLINE_SET_NORMAL_FALL | 774 | 0x0306 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5684 |
| SMSG_MOVE_SPLINE_SET_PITCH_RATE | 1118 | 0x045E | YES | YES | HermesProxy/World/Client/WorldClient.cs:5594 |
| SMSG_MOVE_SPLINE_SET_RUN_BACK_SPEED | 767 | 0x02FF | YES | YES | HermesProxy/World/Client/WorldClient.cs:5595 |
| SMSG_MOVE_SPLINE_SET_RUN_MODE | 781 | 0x030D | YES | YES | HermesProxy/World/Client/WorldClient.cs:5691 |
| SMSG_MOVE_SPLINE_SET_RUN_SPEED | 766 | 0x02FE | YES | YES | HermesProxy/World/Client/WorldClient.cs:5596 |
| SMSG_MOVE_SPLINE_SET_SWIM_BACK_SPEED | 770 | 0x0302 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5597 |
| SMSG_MOVE_SPLINE_SET_SWIM_SPEED | 768 | 0x0300 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5598 |
| SMSG_MOVE_SPLINE_SET_TURN_RATE | 771 | 0x0303 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5599 |
| SMSG_MOVE_SPLINE_SET_WALK_BACK_SPEED | 769 | 0x0301 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5600 |
| SMSG_MOVE_SPLINE_SET_WALK_MODE | 782 | 0x030E | YES | YES | HermesProxy/World/Client/WorldClient.cs:5692 |
| SMSG_MOVE_SPLINE_SET_WATER_WALK | 777 | 0x0309 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5687 |
| SMSG_MOVE_SPLINE_START_SWIM | 779 | 0x030B | YES | YES | HermesProxy/World/Client/WorldClient.cs:5689 |
| SMSG_MOVE_SPLINE_STOP_SWIM | 780 | 0x030C | YES | YES | HermesProxy/World/Client/WorldClient.cs:5690 |
| SMSG_MOVE_SPLINE_UNROOT | 772 | 0x0304 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5680 |
| SMSG_MOVE_SPLINE_UNSET_FLYING | 1059 | 0x0423 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5694 |
| SMSG_MOVE_SPLINE_UNSET_HOVER | 776 | 0x0308 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5686 |
| SMSG_MOVE_UNROOT | 234 | 0x00EA | YES | YES | HermesProxy/World/Client/WorldClient.cs:5703 |
| SMSG_MOVE_UNSET_CAN_FLY | 836 | 0x0344 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5709 |
| SMSG_MOVE_UNSET_HOVERING | 245 | 0x00F5 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5707 |
| SMSG_MULTIPLE_MOVES | 1310 | 0x051E | NO | NO |  |
| SMSG_MULTIPLE_PACKETS_2 | 1229 | 0x04CD | NO | NO |  |
| SMSG_NEW_TAXI_PATH | 431 | 0x01AF | YES | YES | HermesProxy/World/Client/WorldClient.cs:8919 |
| SMSG_NEW_WORLD | 62 | 0x003E | YES | YES | HermesProxy/World/Client/WorldClient.cs:5553 |
| SMSG_NOTIFY_DANCE | 1098 | 0x044A | NO | NO |  |
| SMSG_NOTIFY_DEST_LOC_SPELL_CAST | 1166 | 0x048E | NO | NO |  |
| SMSG_NOTIFY_RECEIVED_MAIL | 645 | 0x0285 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4541 |
| SMSG_NPC_WONT_TALK | 385 | 0x0181 | NO | NO |  |
| SMSG_OFFER_PETITION_ERROR | 911 | 0x038F | NO | NO |  |
| SMSG_ON_CANCEL_EXPECTED_RIDE_VEHICLE_AURA | 1181 | 0x049D | NO | YES |  |
| SMSG_ON_MONSTER_MOVE | 221 | 0x00DD | YES | YES | HermesProxy/World/Client/WorldClient.cs:5740 |
| SMSG_OPEN_CONTAINER | 275 | 0x0113 | NO | NO |  |
| SMSG_OPEN_LFG_DUNGEON_FINDER | 1301 | 0x0515 | NO | NO |  |
| SMSG_OVERRIDE_LIGHT | 1042 | 0x0412 | NO | YES |  |
| SMSG_PAGE_TEXT | 479 | 0x01DF | NO | NO |  |
| SMSG_PARTY_COMMAND_RESULT | 127 | 0x007F | YES | YES | HermesProxy/World/Client/WorldClient.cs:2296 |
| SMSG_PARTY_INVITE | 111 | 0x006F | YES | YES | HermesProxy/World/Client/WorldClient.cs:2328 |
| SMSG_PARTY_KILL_LOG | 501 | 0x01F5 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2194 |
| SMSG_PARTY_MEMBER_FULL_STATE | 754 | 0x02F2 | YES | YES | HermesProxy/World/Client/WorldClient.cs:3078; HermesProxy/World/Client/WorldClient.cs:3292 |
| SMSG_PARTY_MEMBER_PARTIAL_STATE | 126 | 0x007E | YES | YES | HermesProxy/World/Client/WorldClient.cs:2718; HermesProxy/World/Client/WorldClient.cs:2923 |
| SMSG_PAUSE_MIRROR_TIMER | 474 | 0x01DA | YES | YES | HermesProxy/World/Client/WorldClient.cs:5032 |
| SMSG_PETGODMODE | 29 | 0x001D | NO | NO |  |
| SMSG_PETITION_SHOW_LIST | 444 | 0x01BC | YES | YES | HermesProxy/World/Client/WorldClient.cs:6244 |
| SMSG_PETITION_SHOW_SIGNATURES | 447 | 0x01BF | YES | YES | HermesProxy/World/Client/WorldClient.cs:6273 |
| SMSG_PETITION_SIGN_RESULTS | 449 | 0x01C1 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6356 |
| SMSG_PET_ACTION_FEEDBACK | 710 | 0x02C6 | NO | YES |  |
| SMSG_PET_ACTION_SOUND | 804 | 0x0324 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6157 |
| SMSG_PET_BROKEN | 687 | 0x02AF | YES | YES | HermesProxy/World/Client/WorldClient.cs:6166 |
| SMSG_PET_CAST_FAILED | 312 | 0x0138 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7801; HermesProxy/World/Client/WorldClient.cs:7834 |
| SMSG_PET_DISMISS_SOUND | 805 | 0x0325 | NO | NO |  |
| SMSG_PET_GUIDS | 1194 | 0x04AA | NO | YES |  |
| SMSG_PET_LEARNED_SPELLS | 1177 | 0x0499 | NO | NO |  |
| SMSG_PET_MODE | 378 | 0x017A | NO | YES |  |
| SMSG_PET_NAME_INVALID | 376 | 0x0178 | NO | NO |  |
| SMSG_PET_RENAMEABLE | 1141 | 0x0475 | NO | NO |  |
| SMSG_PET_SPELLS_MESSAGE | 377 | 0x0179 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6105 |
| SMSG_PET_STABLE_RESULT | 627 | 0x0273 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6236 |
| SMSG_PET_TAME_FAILURE | 371 | 0x0173 | NO | YES |  |
| SMSG_PET_UNLEARNED_SPELLS | 1178 | 0x049A | NO | NO |  |
| SMSG_PET_UNLEARN_CONFIRM | 753 | 0x02F1 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6174 |
| SMSG_PET_UPDATE_COMBO_POINTS | 1170 | 0x0492 | NO | NO |  |
| SMSG_PHASE_SHIFT_CHANGE | 1148 | 0x047C | NO | YES |  |
| SMSG_PLAYED_TIME | 461 | 0x01CD | YES | YES | HermesProxy/World/Client/WorldClient.cs:1233 |
| SMSG_PLAYERBINDERROR | 438 | 0x01B6 | NO | NO |  |
| SMSG_PLAYER_BOUND | 344 | 0x0158 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4838 |
| SMSG_PLAYER_SKINNED | 700 | 0x02BC | YES | YES | HermesProxy/World/Client/WorldClient.cs:834 |
| SMSG_PLAYER_VEHICLE_DATA | 1191 | 0x04A7 | NO | NO |  |
| SMSG_PLAY_DANCE | 1100 | 0x044C | NO | NO |  |
| SMSG_PLAY_MUSIC | 631 | 0x0277 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4976 |
| SMSG_PLAY_OBJECT_SOUND | 632 | 0x0278 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4993 |
| SMSG_PLAY_SOUND | 722 | 0x02D2 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4984 |
| SMSG_PLAY_SPELL_IMPACT | 503 | 0x01F7 | NO | NO |  |
| SMSG_PLAY_SPELL_VISUAL | 499 | 0x01F3 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8599 |
| SMSG_PLAY_TIME_WARNING | 757 | 0x02F5 | NO | YES |  |
| SMSG_PONG | 477 | 0x01DD | YES | YES | HermesProxy/World/Client/WorldClient.cs:4797 |
| SMSG_POWER_UPDATE | 1152 | 0x0480 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5080 |
| SMSG_PRE_RESSURECT | 1172 | 0x0494 | NO | NO |  |
| SMSG_PRINT_NOTIFICATION | 459 | 0x01CB | YES | YES | HermesProxy/World/Client/WorldClient.cs:1943 |
| SMSG_PROC_RESIST | 608 | 0x0260 | NO | NO |  |
| SMSG_PROFILE_DATA_RESPONSE | 1226 | 0x04CA | NO | NO |  |
| SMSG_PROPOSE_LEVEL_GRANT | 1055 | 0x041F | NO | NO |  |
| SMSG_PVP_CREDIT | 652 | 0x028C | YES | YES | HermesProxy/World/Client/WorldClient.cs:824 |
| SMSG_PVP_QUEUE_STATS | 1244 | 0x04DC | NO | NO |  |
| SMSG_QUERY_CREATURE_RESPONSE | 97 | 0x0061 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6631 |
| SMSG_QUERY_GAME_OBJECT_RESPONSE | 95 | 0x005F | YES | YES | HermesProxy/World/Client/WorldClient.cs:6718 |
| SMSG_QUERY_GUILD_INFO_RESPONSE | 85 | 0x0055 | YES | YES | HermesProxy/World/Client/WorldClient.cs:3640 |
| SMSG_QUERY_ITEM_TEXT_RESPONSE | 580 | 0x0244 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4697 |
| SMSG_QUERY_NPC_TEXT_RESPONSE | 384 | 0x0180 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6789 |
| SMSG_QUERY_OBJ_POSITION | 5 | 0x0005 | NO | NO |  |
| SMSG_QUERY_OBJ_ROTATION | 7 | 0x0007 | NO | NO |  |
| SMSG_QUERY_PAGE_TEXT_RESPONSE | 91 | 0x005B | YES | YES | HermesProxy/World/Client/WorldClient.cs:6773 |
| SMSG_QUERY_PETITION_RESPONSE | 455 | 0x01C7 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6294 |
| SMSG_QUERY_PET_NAME_RESPONSE | 83 | 0x0053 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6903 |
| SMSG_QUERY_PLAYER_NAME_RESPONSE | 81 | 0x0051 | YES | NO | HermesProxy/World/Client/WorldClient.cs:976 |
| SMSG_QUERY_QUESTS_COMPLETED_RESPONSE | 1281 | 0x0501 | NO | NO |  |
| SMSG_QUERY_QUEST_INFO_RESPONSE | 93 | 0x005D | YES | YES | HermesProxy/World/Client/WorldClient.cs:6386 |
| SMSG_QUERY_TIME_RESPONSE | 463 | 0x01CF | YES | YES | HermesProxy/World/Client/WorldClient.cs:6374 |
| SMSG_QUEST_CONFIRM_ACCEPT | 412 | 0x019C | YES | YES | HermesProxy/World/Client/WorldClient.cs:7417 |
| SMSG_QUEST_FORCE_REMOVED | 542 | 0x021E | NO | NO |  |
| SMSG_QUEST_GIVER_INVALID_QUEST | 399 | 0x018F | YES | YES | HermesProxy/World/Client/WorldClient.cs:7361 |
| SMSG_QUEST_GIVER_OFFER_REWARD_MESSAGE | 397 | 0x018D | YES | YES | HermesProxy/World/Client/WorldClient.cs:7244 |
| SMSG_QUEST_GIVER_QUEST_COMPLETE | 401 | 0x0191 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7284 |
| SMSG_QUEST_GIVER_QUEST_DETAILS | 392 | 0x0188 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6992 |
| SMSG_QUEST_GIVER_QUEST_FAILED | 402 | 0x0192 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7352 |
| SMSG_QUEST_GIVER_QUEST_LIST_MESSAGE | 389 | 0x0185 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7150 |
| SMSG_QUEST_GIVER_REQUEST_ITEMS | 395 | 0x018B | YES | YES | HermesProxy/World/Client/WorldClient.cs:7189 |
| SMSG_QUEST_GIVER_STATUS | 387 | 0x0183 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7126 |
| SMSG_QUEST_GIVER_STATUS_MULTIPLE | 1048 | 0x0418 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7135 |
| SMSG_QUEST_LOG_FULL | 405 | 0x0195 | NO | NO |  |
| SMSG_QUEST_POI_QUERY_RESPONSE | 484 | 0x01E4 | NO | YES |  |
| SMSG_QUEST_UPDATE_ADD_ITEM | 410 | 0x019A | YES | YES | HermesProxy/World/Client/WorldClient.cs:7379 |
| SMSG_QUEST_UPDATE_ADD_KILL | 409 | 0x0199 | YES | NO | HermesProxy/World/Client/WorldClient.cs:7403 |
| SMSG_QUEST_UPDATE_ADD_PVP_CREDIT | 1135 | 0x046F | NO | NO |  |
| SMSG_QUEST_UPDATE_COMPLETE | 408 | 0x0198 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7369 |
| SMSG_QUEST_UPDATE_FAILED | 406 | 0x0196 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7370 |
| SMSG_QUEST_UPDATE_FAILED_TIMER | 407 | 0x0197 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7371 |
| SMSG_RAID_GROUP_ONLY | 646 | 0x0286 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4026 |
| SMSG_RAID_INSTANCE_INFO | 716 | 0x02CC | YES | NO | HermesProxy/World/Client/WorldClient.cs:3976 |
| SMSG_RAID_INSTANCE_MESSAGE | 762 | 0x02FA | YES | YES | HermesProxy/World/Client/WorldClient.cs:4035 |
| SMSG_READY_CHECK_ERROR | 1032 | 0x0408 | NO | NO |  |
| SMSG_READ_ITEM_RESULT_FAILED | 175 | 0x00AF | YES | YES | HermesProxy/World/Client/WorldClient.cs:4152 |
| SMSG_READ_ITEM_RESULT_OK | 174 | 0x00AE | YES | YES | HermesProxy/World/Client/WorldClient.cs:4144 |
| SMSG_REALM_SPLIT | 907 | 0x038B | NO | NO |  |
| SMSG_REAL_GROUP_UPDATE | 919 | 0x0397 | NO | YES |  |
| SMSG_REFER_A_FRIEND_EXPIRED | 30 | 0x001E | NO | NO |  |
| SMSG_REFER_A_FRIEND_FAILURE | 1057 | 0x0421 | NO | NO |  |
| SMSG_REMOVED_FROM_PVP_QUEUE | 368 | 0x0170 | NO | NO |  |
| SMSG_REPORT_PVP_AFK_RESULT | 997 | 0x03E5 | NO | NO |  |
| SMSG_RESET_FAILED_NOTIFY | 918 | 0x0396 | YES | YES | HermesProxy/World/Client/WorldClient.cs:3968 |
| SMSG_RESET_RANGED_COMBAT_TIMER | 664 | 0x0298 | NO | NO |  |
| SMSG_RESISTLOG | 470 | 0x01D6 | NO | NO |  |
| SMSG_RESPOND_INSPECT_ACHIEVEMENTS | 1132 | 0x046C | NO | NO |  |
| SMSG_RESUME_CAST_BAR | 333 | 0x014D | NO | NO |  |
| SMSG_RESUME_COMMS | 1297 | 0x0511 | NO | YES |  |
| SMSG_RESURRECT_FAILED | 594 | 0x0252 | NO | NO |  |
| SMSG_RESURRECT_REQUEST | 347 | 0x015B | YES | YES | HermesProxy/World/Client/WorldClient.cs:8795 |
| SMSG_RESYNC_RUNES | 1159 | 0x0487 | NO | NO |  |
| SMSG_RWHOIS | 510 | 0x01FE | NO | NO |  |
| SMSG_SCRIPT_MESSAGE | 694 | 0x02B6 | NO | NO |  |
| SMSG_SELL_RESPONSE | 417 | 0x01A1 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4250 |
| SMSG_SEND_KNOWN_SPELLS | 298 | 0x012A | YES | YES | HermesProxy/World/Client/WorldClient.cs:7630 |
| SMSG_SEND_UNLEARN_SPELLS | 1054 | 0x041E | YES | YES | HermesProxy/World/Client/WorldClient.cs:7702 |
| SMSG_SERVERINFO | 1269 | 0x04F5 | NO | NO |  |
| SMSG_SERVERTIME | 73 | 0x0049 | NO | NO |  |
| SMSG_SERVER_BUCK_DATA | 1053 | 0x041D | NO | NO |  |
| SMSG_SERVER_BUCK_DATA_START | 1187 | 0x04A3 | NO | NO |  |
| SMSG_SERVER_FIRST_ACHIEVEMENT | 1176 | 0x0498 | NO | NO |  |
| SMSG_SERVER_INFO_RESPONSE | 1185 | 0x04A1 | NO | NO |  |
| SMSG_SET_EXTRA_AURA_INFO_NEED_UPDATE_OBSOLETE | 933 | 0x03A5 | NO | NO |  |
| SMSG_SET_EXTRA_AURA_INFO_OBSOLETE | 932 | 0x03A4 | NO | NO |  |
| SMSG_SET_FACTION_AT_WAR | 787 | 0x0313 | NO | NO |  |
| SMSG_SET_FACTION_STANDING | 292 | 0x0124 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7456 |
| SMSG_SET_FACTION_VISIBLE | 291 | 0x0123 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7500 |
| SMSG_SET_FLAT_SPELL_MODIFIER | 614 | 0x0266 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8819 |
| SMSG_SET_FORCED_REACTIONS | 677 | 0x02A5 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7483 |
| SMSG_SET_PCT_SPELL_MODIFIER | 615 | 0x0267 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8820 |
| SMSG_SET_PLAYER_DECLINED_NAMES_RESULT | 1050 | 0x041A | NO | YES |  |
| SMSG_SET_PROFICIENCY | 295 | 0x0127 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4062 |
| SMSG_SET_PROJECTILE_POSITION | 1215 | 0x04BF | NO | NO |  |
| SMSG_SHOW_BANK | 440 | 0x01B8 | YES | NO | HermesProxy/World/Client/WorldClient.cs:6023 |
| SMSG_SHOW_MAILBOX | 663 | 0x0297 | NO | NO |  |
| SMSG_SHOW_TAXI_NODES | 425 | 0x01A9 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8892 |
| SMSG_SOCKET_GEMS | 1291 | 0x050B | NO | NO |  |
| SMSG_SPECIAL_MOUNT_ANIM | 370 | 0x0172 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5011 |
| SMSG_SPELL_BREAK_LOG | 335 | 0x014F | NO | NO |  |
| SMSG_SPELL_CHANCE_PROC_LOG | 938 | 0x03AA | NO | NO |  |
| SMSG_SPELL_CHANCE_RESIST_PUSHBACK | 1028 | 0x0404 | NO | NO |  |
| SMSG_SPELL_COOLDOWN | 308 | 0x0134 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8216 |
| SMSG_SPELL_DAMAGE_SHIELD | 591 | 0x024F | YES | YES | HermesProxy/World/Client/WorldClient.cs:8505 |
| SMSG_SPELL_DELAYED | 482 | 0x01E2 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8455 |
| SMSG_SPELL_DISPELL_LOG | 635 | 0x027B | YES | YES | HermesProxy/World/Client/WorldClient.cs:8563 |
| SMSG_SPELL_ENERGIZE_LOG | 337 | 0x0151 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8443 |
| SMSG_SPELL_EXECUTE_LOG | 588 | 0x024C | NO | NO |  |
| SMSG_SPELL_FAILED_OTHER | 678 | 0x02A6 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7884 |
| SMSG_SPELL_FAILURE | 307 | 0x0133 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7878 |
| SMSG_SPELL_GO | 306 | 0x0132 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7991 |
| SMSG_SPELL_HEAL_LOG | 336 | 0x0150 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8331 |
| SMSG_SPELL_INSTAKILL_LOG | 815 | 0x032F | YES | YES | HermesProxy/World/Client/WorldClient.cs:8546 |
| SMSG_SPELL_MISS_LOG | 587 | 0x024B | NO | NO |  |
| SMSG_SPELL_NON_MELEE_DAMAGE_LOG | 592 | 0x0250 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8275 |
| SMSG_SPELL_OR_DAMAGE_IMMUNE | 611 | 0x0263 | NO | NO |  |
| SMSG_SPELL_PERIODIC_AURA_LOG | 590 | 0x024E | YES | YES | HermesProxy/World/Client/WorldClient.cs:8357 |
| SMSG_SPELL_START | 305 | 0x0131 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7935 |
| SMSG_SPELL_STEAL_LOG | 819 | 0x0333 | NO | NO |  |
| SMSG_SPELL_UPDATE_CHAIN_TARGETS | 816 | 0x0330 | NO | YES |  |
| SMSG_SPIRIT_HEALER_CONFIRM | 546 | 0x0222 | YES | NO | HermesProxy/World/Client/WorldClient.cs:6094 |
| SMSG_STAND_STATE_UPDATE | 669 | 0x029D | YES | YES | HermesProxy/World/Client/WorldClient.cs:4959 |
| SMSG_START_MIRROR_TIMER | 473 | 0x01D9 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5019 |
| SMSG_STOP_DANCE | 1103 | 0x044F | NO | NO |  |
| SMSG_STOP_MIRROR_TIMER | 475 | 0x01DB | YES | YES | HermesProxy/World/Client/WorldClient.cs:5041 |
| SMSG_SUMMON_CANCEL | 1060 | 0x0424 | NO | NO |  |
| SMSG_SUMMON_REQUEST | 683 | 0x02AB | YES | YES | HermesProxy/World/Client/WorldClient.cs:2707 |
| SMSG_SUPERCEDED_SPELLS | 300 | 0x012C | YES | YES | HermesProxy/World/Client/WorldClient.cs:7672 |
| SMSG_SUSPEND_COMMS | 1295 | 0x050F | NO | YES |  |
| SMSG_TALENTS_INVOLUNTARILY_RESET | 1274 | 0x04FA | NO | NO |  |
| SMSG_TAXI_NODE_STATUS | 427 | 0x01AB | YES | YES | HermesProxy/World/Client/WorldClient.cs:8882 |
| SMSG_TEST_DROP_RATE_RESULT | 661 | 0x0295 | NO | NO |  |
| SMSG_TEXT_EMOTE | 261 | 0x0105 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1928 |
| SMSG_THREAT_CLEAR | 1157 | 0x0485 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2051 |
| SMSG_THREAT_REMOVE | 1156 | 0x0484 | NO | YES |  |
| SMSG_THREAT_UPDATE | 1155 | 0x0483 | YES | YES | HermesProxy/World/Client/WorldClient.cs:2059 |
| SMSG_TIME_SYNC_REQUEST | 912 | 0x0390 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4864 |
| SMSG_TITLE_EARNED | 883 | 0x0373 | NO | YES |  |
| SMSG_TOGGLE_XP_GAIN | 1261 | 0x04ED | NO | NO |  |
| SMSG_TOTEM_CREATED | 1043 | 0x0413 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8808 |
| SMSG_TRADE_STATUS | 288 | 0x0120 | YES | YES | HermesProxy/World/Client/WorldClient.cs:8939 |
| SMSG_TRADE_STATUS_EXTENDED | 289 | 0x0121 | YES | NO | HermesProxy/World/Client/WorldClient.cs:9010 |
| SMSG_TRAINER_BUY_FAILED | 436 | 0x01B4 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6073 |
| SMSG_TRAINER_BUY_SUCCEEDED | 435 | 0x01B3 | NO | NO |  |
| SMSG_TRAINER_LIST | 433 | 0x01B1 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6032 |
| SMSG_TRANSFER_ABORTED | 64 | 0x0040 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5524 |
| SMSG_TRANSFER_PENDING | 63 | 0x003F | YES | YES | HermesProxy/World/Client/WorldClient.cs:5504 |
| SMSG_TRIGGER_CINEMATIC | 250 | 0x00FA | YES | YES | HermesProxy/World/Client/WorldClient.cs:5003 |
| SMSG_TRIGGER_MOVIE | 1124 | 0x0464 | NO | NO |  |
| SMSG_TURN_IN_PETITION_RESULT | 453 | 0x01C5 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6366 |
| SMSG_TUTORIAL_FLAGS | 253 | 0x00FD | YES | YES | HermesProxy/World/Client/WorldClient.cs:4804 |
| SMSG_UI_TIME | 1271 | 0x04F7 | NO | NO |  |
| SMSG_UNLEARNED_SPELLS | 515 | 0x0203 | YES | YES | HermesProxy/World/Client/WorldClient.cs:7715 |
| SMSG_UPDATE_ACCOUNT_DATA | 524 | 0x020C | NO | YES |  |
| SMSG_UPDATE_ACCOUNT_DATA_COMPLETE | 1123 | 0x0463 | NO | NO |  |
| SMSG_UPDATE_ACTION_BUTTONS | 297 | 0x0129 | YES | YES | HermesProxy/World/Client/WorldClient.cs:1151 |
| SMSG_UPDATE_COMBO_POINTS | 925 | 0x039D | YES | YES | HermesProxy/World/Client/WorldClient.cs:1267 |
| SMSG_UPDATE_INSTANCE_ENCOUNTER_UNIT | 532 | 0x0214 | NO | NO |  |
| SMSG_UPDATE_INSTANCE_OWNERSHIP | 811 | 0x032B | YES | YES | HermesProxy/World/Client/WorldClient.cs:3943 |
| SMSG_UPDATE_LAST_INSTANCE | 800 | 0x0320 | NO | YES |  |
| SMSG_UPDATE_OBJECT | 169 | 0x00A9 | YES | YES | HermesProxy/World/Client/WorldClient.cs:9090 |
| SMSG_UPDATE_TALENT_DATA | 1216 | 0x04C0 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5094 |
| SMSG_UPDATE_WORLD_STATE | 707 | 0x02C3 | YES | YES | HermesProxy/World/Client/WorldClient.cs:12245 |
| SMSG_USERLIST_ADD | 1008 | 0x03F0 | NO | NO |  |
| SMSG_USERLIST_REMOVE | 1009 | 0x03F1 | NO | NO |  |
| SMSG_USERLIST_UPDATE | 1010 | 0x03F2 | NO | NO |  |
| SMSG_USE_EQUIPMENT_SET_RESULT | 1238 | 0x04D6 | NO | NO |  |
| SMSG_VENDOR_INVENTORY | 415 | 0x019F | YES | YES | HermesProxy/World/Client/WorldClient.cs:5989 |
| SMSG_VOICESESSION_FULL | 1020 | 0x03FC | NO | NO |  |
| SMSG_VOICE_CHAT_STATUS | 995 | 0x03E3 | NO | NO |  |
| SMSG_VOICE_PARENTAL_CONTROLS | 945 | 0x03B1 | NO | NO |  |
| SMSG_VOICE_SESSION_ADJUST_PRIORITY | 928 | 0x03A0 | NO | NO |  |
| SMSG_VOICE_SESSION_ENABLE | 944 | 0x03B0 | NO | NO |  |
| SMSG_VOICE_SESSION_LEAVE | 927 | 0x039F | NO | NO |  |
| SMSG_VOICE_SESSION_ROSTER_UPDATE | 926 | 0x039E | NO | NO |  |
| SMSG_VOICE_SET_TALKER_MUTED | 930 | 0x03A2 | NO | NO |  |
| SMSG_WARDEN_DATA | 742 | 0x02E6 | NO | NO |  |
| SMSG_WEATHER | 756 | 0x02F4 | YES | YES | HermesProxy/World/Client/WorldClient.cs:4872 |
| SMSG_WHO | 99 | 0x0063 | YES | YES | HermesProxy/World/Client/WorldClient.cs:6946 |
| SMSG_WHO_IS | 101 | 0x0065 | NO | NO |  |
| SMSG_ZONE_MAP | 11 | 0x000B | NO | NO |  |
| SMSG_ZONE_UNDER_ATTACK | 596 | 0x0254 | YES | YES | HermesProxy/World/Client/WorldClient.cs:5061 |

## MSG (Bidirectional)

| Opcode | Value (Dec) | Value (Hex) | Handled | Modern Match | Handler Location |
|--------|-------------|-------------|---------|--------------|------------------|
| MSG_AUCTION_HELLO | 597 | 0x0255 | YES | NO | HermesProxy/World/Client/WorldClient.cs:201 |
| MSG_BATTLEGROUND_PLAYER_POSITIONS | 745 | 0x02E9 | YES | NO | HermesProxy/World/Client/WorldClient.cs:747; HermesProxy/World/Client/WorldClient.cs:776 |
| MSG_CHANNEL_START | 313 | 0x0139 | YES | NO | HermesProxy/World/Client/WorldClient.cs:8471 |
| MSG_CHANNEL_UPDATE | 314 | 0x013A | YES | NO | HermesProxy/World/Client/WorldClient.cs:8489 |
| MSG_CORPSE_QUERY | 534 | 0x0216 | YES | NO | HermesProxy/World/Client/WorldClient.cs:4933 |
| MSG_DELAY_GHOST_TELEPORT | 814 | 0x032E | NO | NO |  |
| MSG_DEV_SHOWLABEL | 685 | 0x02AD | NO | NO |  |
| MSG_GM_ACCOUNT_ONLINE | 622 | 0x026E | NO | NO |  |
| MSG_GM_BIND_OTHER | 488 | 0x01E8 | NO | NO |  |
| MSG_GM_CHANGE_ARENA_RATING | 1039 | 0x040F | NO | NO |  |
| MSG_GM_DESTROY_CORPSE | 784 | 0x0310 | NO | NO |  |
| MSG_GM_GEARRATING | 948 | 0x03B4 | NO | NO |  |
| MSG_GM_RESETINSTANCELIMIT | 828 | 0x033C | NO | NO |  |
| MSG_GM_SHOWLABEL | 495 | 0x01EF | NO | NO |  |
| MSG_GM_SUMMON | 489 | 0x01E9 | NO | NO |  |
| MSG_GUILD_BANK_LOG_QUERY | 1006 | 0x03EE | YES | NO | HermesProxy/World/Client/WorldClient.cs:3905 |
| MSG_GUILD_BANK_MONEY_WITHDRAWN | 1022 | 0x03FE | YES | NO | HermesProxy/World/Client/WorldClient.cs:3935 |
| MSG_GUILD_EVENT_LOG_QUERY | 1023 | 0x03FF | NO | NO |  |
| MSG_GUILD_PERMISSIONS | 1021 | 0x03FD | NO | NO |  |
| MSG_INSPECT_ARENA_TEAMS | 887 | 0x0377 | YES | NO | HermesProxy/World/Client/WorldClient.cs:1458 |
| MSG_INSPECT_HONOR_STATS | 726 | 0x02D6 | YES | NO | HermesProxy/World/Client/WorldClient.cs:1372; HermesProxy/World/Client/WorldClient.cs:1425 |
| MSG_LIST_STABLED_PETS | 623 | 0x026F | YES | NO | HermesProxy/World/Client/WorldClient.cs:6184 |
| MSG_MINIMAP_PING | 469 | 0x01D5 | YES | NO | HermesProxy/World/Client/WorldClient.cs:3456 |
| MSG_MOVE_FALL_LAND | 201 | 0x00C9 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5420 |
| MSG_MOVE_FEATHER_FALL | 688 | 0x02B0 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5424 |
| MSG_MOVE_GRAVITY_CHNG | 1234 | 0x04D2 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5412 |
| MSG_MOVE_HEARTBEAT | 238 | 0x00EE | YES | NO | HermesProxy/World/Client/WorldClient.cs:5419 |
| MSG_MOVE_HOVER | 247 | 0x00F7 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5423 |
| MSG_MOVE_JUMP | 187 | 0x00BB | YES | NO | HermesProxy/World/Client/WorldClient.cs:5399 |
| MSG_MOVE_KNOCK_BACK | 241 | 0x00F1 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5437 |
| MSG_MOVE_ROOT | 236 | 0x00EC | YES | NO | HermesProxy/World/Client/WorldClient.cs:5413 |
| MSG_MOVE_SET_ALL_SPEED_CHEAT | 214 | 0x00D6 | NO | NO |  |
| MSG_MOVE_SET_COLLISION_HGT | 1304 | 0x0518 | NO | NO |  |
| MSG_MOVE_SET_FACING | 218 | 0x00DA | YES | NO | HermesProxy/World/Client/WorldClient.cs:5409 |
| MSG_MOVE_SET_FLIGHT_BACK_SPEED | 896 | 0x0380 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5645 |
| MSG_MOVE_SET_FLIGHT_BACK_SPEED_CHEAT | 895 | 0x037F | NO | NO |  |
| MSG_MOVE_SET_FLIGHT_SPEED | 894 | 0x037E | YES | NO | HermesProxy/World/Client/WorldClient.cs:5646 |
| MSG_MOVE_SET_FLIGHT_SPEED_CHEAT | 893 | 0x037D | NO | NO |  |
| MSG_MOVE_SET_PITCH | 219 | 0x00DB | YES | NO | HermesProxy/World/Client/WorldClient.cs:5410 |
| MSG_MOVE_SET_PITCH_RATE | 1115 | 0x045B | YES | NO | HermesProxy/World/Client/WorldClient.cs:5647 |
| MSG_MOVE_SET_PITCH_RATE_CHEAT | 1114 | 0x045A | NO | NO |  |
| MSG_MOVE_SET_RUN_BACK_SPEED | 207 | 0x00CF | YES | NO | HermesProxy/World/Client/WorldClient.cs:5648 |
| MSG_MOVE_SET_RUN_BACK_SPEED_CHEAT | 206 | 0x00CE | NO | NO |  |
| MSG_MOVE_SET_RUN_MODE | 194 | 0x00C2 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5406 |
| MSG_MOVE_SET_RUN_SPEED | 205 | 0x00CD | YES | NO | HermesProxy/World/Client/WorldClient.cs:5649 |
| MSG_MOVE_SET_RUN_SPEED_CHEAT | 204 | 0x00CC | NO | NO |  |
| MSG_MOVE_SET_SWIM_BACK_SPEED | 213 | 0x00D5 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5650 |
| MSG_MOVE_SET_SWIM_BACK_SPEED_CHEAT | 212 | 0x00D4 | NO | NO |  |
| MSG_MOVE_SET_SWIM_SPEED | 211 | 0x00D3 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5651 |
| MSG_MOVE_SET_SWIM_SPEED_CHEAT | 210 | 0x00D2 | NO | NO |  |
| MSG_MOVE_SET_TURN_RATE | 216 | 0x00D8 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5652 |
| MSG_MOVE_SET_TURN_RATE_CHEAT | 215 | 0x00D7 | NO | NO |  |
| MSG_MOVE_SET_WALK_MODE | 195 | 0x00C3 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5407 |
| MSG_MOVE_SET_WALK_SPEED | 209 | 0x00D1 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5653 |
| MSG_MOVE_SET_WALK_SPEED_CHEAT | 208 | 0x00D0 | NO | NO |  |
| MSG_MOVE_START_ASCEND | 857 | 0x0359 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5396 |
| MSG_MOVE_START_BACKWARD | 182 | 0x00B6 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5391 |
| MSG_MOVE_START_DESCEND | 935 | 0x03A7 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5397 |
| MSG_MOVE_START_FORWARD | 181 | 0x00B5 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5390 |
| MSG_MOVE_START_PITCH_DOWN | 192 | 0x00C0 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5404 |
| MSG_MOVE_START_PITCH_UP | 191 | 0x00BF | YES | NO | HermesProxy/World/Client/WorldClient.cs:5403 |
| MSG_MOVE_START_STRAFE_LEFT | 184 | 0x00B8 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5393 |
| MSG_MOVE_START_STRAFE_RIGHT | 185 | 0x00B9 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5394 |
| MSG_MOVE_START_SWIM | 202 | 0x00CA | YES | NO | HermesProxy/World/Client/WorldClient.cs:5415 |
| MSG_MOVE_START_SWIM_CHEAT | 833 | 0x0341 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5417 |
| MSG_MOVE_START_TURN_LEFT | 188 | 0x00BC | YES | NO | HermesProxy/World/Client/WorldClient.cs:5400 |
| MSG_MOVE_START_TURN_RIGHT | 189 | 0x00BD | YES | NO | HermesProxy/World/Client/WorldClient.cs:5401 |
| MSG_MOVE_STOP | 183 | 0x00B7 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5392 |
| MSG_MOVE_STOP_ASCEND | 858 | 0x035A | YES | NO | HermesProxy/World/Client/WorldClient.cs:5398 |
| MSG_MOVE_STOP_PITCH | 193 | 0x00C1 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5405 |
| MSG_MOVE_STOP_STRAFE | 186 | 0x00BA | YES | NO | HermesProxy/World/Client/WorldClient.cs:5395 |
| MSG_MOVE_STOP_SWIM | 203 | 0x00CB | YES | NO | HermesProxy/World/Client/WorldClient.cs:5416 |
| MSG_MOVE_STOP_SWIM_CHEAT | 834 | 0x0342 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5418 |
| MSG_MOVE_STOP_TURN | 190 | 0x00BE | YES | NO | HermesProxy/World/Client/WorldClient.cs:5402 |
| MSG_MOVE_TELEPORT | 197 | 0x00C5 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5408 |
| MSG_MOVE_TELEPORT_ACK | 199 | 0x00C7 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5474 |
| MSG_MOVE_TELEPORT_CHEAT | 198 | 0x00C6 | NO | NO |  |
| MSG_MOVE_TIME_SKIPPED | 793 | 0x0319 | NO | NO |  |
| MSG_MOVE_TOGGLE_COLLISION_CHEAT | 217 | 0x00D9 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5411 |
| MSG_MOVE_TOGGLE_FALL_LOGGING | 200 | 0x00C8 | NO | NO |  |
| MSG_MOVE_TOGGLE_LOGGING | 196 | 0x00C4 | NO | NO |  |
| MSG_MOVE_UNROOT | 237 | 0x00ED | YES | NO | HermesProxy/World/Client/WorldClient.cs:5414 |
| MSG_MOVE_UPDATE_CAN_FLY | 941 | 0x03AD | YES | NO | HermesProxy/World/Client/WorldClient.cs:5421 |
| MSG_MOVE_UPDATE_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY | 842 | 0x034A | YES | NO | HermesProxy/World/Client/WorldClient.cs:5422 |
| MSG_MOVE_WATER_WALK | 689 | 0x02B1 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5425 |
| MSG_MOVE_WORLDPORT_ACK | 220 | 0x00DC | NO | NO |  |
| MSG_NOTIFY_PARTY_SQUELCH | 991 | 0x03DF | NO | NO |  |
| MSG_NULL_ACTION | 0 | 0x0000 | NO | YES |  |
| MSG_PARTY_ASSIGNMENT | 910 | 0x038E | NO | NO |  |
| MSG_PETITION_DECLINE | 450 | 0x01C2 | YES | NO | HermesProxy/World/Client/WorldClient.cs:6344 |
| MSG_PETITION_RENAME | 705 | 0x02C1 | YES | NO | HermesProxy/World/Client/WorldClient.cs:6335 |
| MSG_PVP_LOG_DATA | 736 | 0x02E0 | YES | NO | HermesProxy/World/Client/WorldClient.cs:623; HermesProxy/World/Client/WorldClient.cs:665 |
| MSG_QUERY_GUILD_BANK_TEXT | 1034 | 0x040A | YES | NO | HermesProxy/World/Client/WorldClient.cs:3896 |
| MSG_QUERY_NEXT_MAIL_TIME | 644 | 0x0284 | YES | NO | HermesProxy/World/Client/WorldClient.cs:4549 |
| MSG_QUEST_PUSH_RESULT | 630 | 0x0276 | YES | NO | HermesProxy/World/Client/WorldClient.cs:7427 |
| MSG_RAID_READY_CHECK | 802 | 0x0322 | YES | NO | HermesProxy/World/Client/WorldClient.cs:2610; HermesProxy/World/Client/WorldClient.cs:2638 |
| MSG_RAID_READY_CHECK_CONFIRM | 942 | 0x03AE | YES | NO | HermesProxy/World/Client/WorldClient.cs:2648 |
| MSG_RAID_READY_CHECK_FINISHED | 966 | 0x03C6 | YES | NO | HermesProxy/World/Client/WorldClient.cs:2667 |
| MSG_RAID_TARGET_UPDATE | 801 | 0x0321 | YES | NO | HermesProxy/World/Client/WorldClient.cs:2676 |
| MSG_RANDOM_ROLL | 507 | 0x01FB | YES | NO | HermesProxy/World/Client/WorldClient.cs:3465 |
| MSG_SAVE_GUILD_EMBLEM | 497 | 0x01F1 | YES | NO | HermesProxy/World/Client/WorldClient.cs:3804 |
| MSG_SET_DUNGEON_DIFFICULTY | 809 | 0x0329 | YES | NO | HermesProxy/World/Client/WorldClient.cs:5069 |
| MSG_SET_RAID_DIFFICULTY | 1259 | 0x04EB | NO | NO |  |
| MSG_TABARDVENDOR_ACTIVATE | 498 | 0x01F2 | YES | NO | HermesProxy/World/Client/WorldClient.cs:3796 |
| MSG_TALENT_WIPE_CONFIRM | 682 | 0x02AA | YES | NO | HermesProxy/World/Client/WorldClient.cs:6085 |
| MSG_VIEW_PHASE_SHIFT | 1273 | 0x04F9 | NO | NO |  |

## Other

| Opcode | Value (Dec) | Value (Hex) | Handled | Modern Match | Handler Location |
|--------|-------------|-------------|---------|--------------|------------------|
| UMSG_DELETE_GUILD_CHARTER | 704 | 0x02C0 | NO | NO |  |
| UMSG_UPDATE_GROUP_INFO | 1278 | 0x04FE | NO | NO |  |
| UMSG_UPDATE_GROUP_MEMBERS | 128 | 0x0080 | NO | NO |  |
| UMSG_UPDATE_GUILD | 148 | 0x0094 | NO | NO |  |

## Summary

- Total legacy opcodes: 1311
- CMSG: 618
- SMSG: 583
- MSG: 106
- Other: 4
- Handled: 621
- Unhandled: 690
- Also in modern: 600
- Legacy only (no modern equivalent): 711
