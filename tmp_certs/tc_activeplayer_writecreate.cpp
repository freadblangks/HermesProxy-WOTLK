void ActivePlayerData::WriteCreate(ByteBuffer& data, EnumFlag<UpdateFieldFlag> fieldVisibilityFlags, Player const* owner, Player const* receiver) const
{
    for (uint32 i = 0; i < 141; ++i)
    {
        data << InvSlots[i];
    }
    data << FarsightObject;
    data << SummonedBattlePetGUID;
    data << uint32(KnownTitles.size());
    data << uint64(Coinage);
    data << int32(XP);
    data << int32(NextLevelXP);
    data << int32(TrialXP);
    Skill->WriteCreate(data, owner, receiver);
    data << int32(CharacterPoints);
    data << int32(MaxTalentTiers);
    data << uint32(TrackCreatureMask);
    for (uint32 i = 0; i < 2; ++i)
    {
        data << uint32(TrackResourceMask[i]);
    }
    data << float(MainhandExpertise);
    data << float(OffhandExpertise);
    data << float(RangedExpertise);
    data << float(CombatRatingExpertise);
    data << float(BlockPercentage);
    data << float(DodgePercentage);
    data << float(DodgePercentageFromAttribute);
    data << float(ParryPercentage);
    data << float(ParryPercentageFromAttribute);
    data << float(CritPercentage);
    data << float(RangedCritPercentage);
    data << float(OffhandCritPercentage);
    for (uint32 i = 0; i < 7; ++i)
    {
        data << float(SpellCritPercentage[i]);
        data << int32(ModDamageDonePos[i]);
        data << int32(ModDamageDoneNeg[i]);
        data << float(ModDamageDonePercent[i]);
    }
    data << int32(ShieldBlock);
    data << float(ShieldBlockCritPercentage);
    data << float(Mastery);
    data << float(Speed);
    data << float(Avoidance);
    data << float(Sturdiness);
    data << int32(Versatility);
    data << float(VersatilityBonus);
    data << float(PvpPowerDamage);
    data << float(PvpPowerHealing);
    for (uint32 i = 0; i < 240; ++i)
    {
        data << uint64(ExploredZones[i]);
    }
    for (uint32 i = 0; i < 2; ++i)
    {
        RestInfo[i].WriteCreate(data, owner, receiver);
    }
    data << int32(ModHealingDonePos);
    data << float(ModHealingPercent);
    data << float(ModHealingDonePercent);
    data << float(ModPeriodicHealingDonePercent);
    for (uint32 i = 0; i < 3; ++i)
    {
        data << float(WeaponDmgMultipliers[i]);
        data << float(WeaponAtkSpeedMultipliers[i]);
    }
    data << float(ModSpellPowerPercent);
    data << float(ModResiliencePercent);
    data << float(OverrideSpellPowerByAPPercent);
    data << float(OverrideAPBySpellPowerPercent);
    data << int32(ModTargetResistance);
    data << int32(ModTargetPhysicalResistance);
    data << uint32(LocalFlags);
    data << uint8(GrantableLevels);
    data << uint8(MultiActionBars);
    data << uint8(LifetimeMaxRank);
    data << uint8(NumRespecs);
    data << int32(AmmoID);
    data << uint32(PvpMedals);
    for (uint32 i = 0; i < 12; ++i)
    {
        data << uint32(BuybackPrice[i]);
        data << int64(BuybackTimestamp[i]);
    }
    data << uint16(TodayHonorableKills);
    data << uint16(TodayDishonorableKills);
    data << uint16(YesterdayHonorableKills);
    data << uint16(YesterdayDishonorableKills);
    data << uint16(LastWeekHonorableKills);
    data << uint16(LastWeekDishonorableKills);
    data << uint16(ThisWeekHonorableKills);
    data << uint16(ThisWeekDishonorableKills);
    data << uint32(ThisWeekContribution);
    data << uint32(LifetimeHonorableKills);
    data << uint32(LifetimeDishonorableKills);
    data << uint32(Field_F24);
    data << uint32(YesterdayContribution);
    data << uint32(LastWeekContribution);
    data << uint32(LastWeekRank);
    data << int32(WatchedFactionIndex);
    for (uint32 i = 0; i < 32; ++i)
    {
        data << int32(CombatRatings[i]);
    }
    data << int32(MaxLevel);
    data << int32(ScalingPlayerLevelDelta);
    data << int32(MaxCreatureScalingLevel);
    for (uint32 i = 0; i < 4; ++i)
    {
        data << uint32(NoReagentCostMask[i]);
    }
    data << int32(PetSpellPower);
    for (uint32 i = 0; i < 2; ++i)
    {
        data << int32(ProfessionSkillLine[i]);
    }
    data << float(UiHitModifier);
    data << float(UiSpellHitModifier);
    data << int32(HomeRealmTimeOffset);
    data << float(ModPetHaste);
    data << uint8(LocalRegenFlags);
    data << uint8(AuraVision);
    data << uint8(NumBackpackSlots);
    data << int32(OverrideSpellsID);
    data << int32(LfgBonusFactionID);
    data << uint16(LootSpecID);
    data << uint32(OverrideZonePVPType);
    for (uint32 i = 0; i < 4; ++i)
    {
        data << uint32(BagSlotFlags[i]);
    }
    for (uint32 i = 0; i < 7; ++i)
    {
        data << uint32(BankBagSlotFlags[i]);
    }
    for (uint32 i = 0; i < 875; ++i)
    {
        data << uint64(QuestCompleted[i]);
    }
    data << int32(Honor);
    data << int32(HonorNextLevel);
    data << int32(Field_F74);
    data << int32(PvpTierMaxFromWins);
    data << int32(PvpLastWeeksTierMaxFromWins);
    data << uint8(PvpRankProgress);
    data << int32(PerksProgramCurrency);
    for (uint32 i = 0; i < 1; ++i)
    {
        data << uint32(ResearchSites[i].size());
        data << uint32(ResearchSiteProgress[i].size());
        data << uint32(Research[i].size());
        for (uint32 j = 0; j < ResearchSites[i].size(); ++j)
        {
            data << uint16(ResearchSites[i][j]);
        }
        for (uint32 j = 0; j < ResearchSiteProgress[i].size(); ++j)
        {
            data << uint32(ResearchSiteProgress[i][j]);
        }
        for (uint32 j = 0; j < Research[i].size(); ++j)
        {
            Research[i][j].WriteCreate(data, owner, receiver);
        }
    }
    data << uint32(DailyQuestsCompleted.size());
    data << uint32(AvailableQuestLineXQuestIDs.size());
    data << uint32(Field_1000.size());
    data << uint32(Heirlooms.size());
    data << uint32(HeirloomFlags.size());
    data << uint32(Toys.size());
    data << uint32(Transmog.size());
    data << uint32(ConditionalTransmog.size());
    data << uint32(SelfResSpells.size());
    data << uint32(CharacterRestrictions.size());
    data << uint32(SpellPctModByLabel.size());
    data << uint32(SpellFlatModByLabel.size());
    data << uint32(TaskQuests.size());
    data << int32(TransportServerTime);
    data << uint32(TraitConfigs.size());
    data << uint32(ActiveCombatTraitConfigID);
    for (uint32 i = 0; i < 6; ++i)
    {
        data << uint32(GlyphSlots[i]);
        data << uint32(Glyphs[i]);
    }
    data << uint8(GlyphsEnabled);
    data << uint8(LfgRoles);
    data << uint32(CategoryCooldownMods.size());
    data << uint32(WeeklySpellUses.size());
    data << uint8(NumStableSlots);
    for (uint32 i = 0; i < KnownTitles.size(); ++i)
    {
        data << uint64(KnownTitles[i]);
    }
    for (uint32 i = 0; i < DailyQuestsCompleted.size(); ++i)
    {
        data << int32(DailyQuestsCompleted[i]);
    }
    for (uint32 i = 0; i < AvailableQuestLineXQuestIDs.size(); ++i)
    {
        data << int32(AvailableQuestLineXQuestIDs[i]);
    }
    for (uint32 i = 0; i < Field_1000.size(); ++i)
    {
        data << int32(Field_1000[i]);
    }
    for (uint32 i = 0; i < Heirlooms.size(); ++i)
    {
        data << int32(Heirlooms[i]);
    }
    for (uint32 i = 0; i < HeirloomFlags.size(); ++i)
    {
        data << uint32(HeirloomFlags[i]);
    }
    for (uint32 i = 0; i < Toys.size(); ++i)
    {
        data << int32(Toys[i]);
    }
    for (uint32 i = 0; i < Transmog.size(); ++i)
    {
        data << uint32(Transmog[i]);
    }
    for (uint32 i = 0; i < ConditionalTransmog.size(); ++i)
    {
        data << int32(ConditionalTransmog[i]);
    }
    for (uint32 i = 0; i < SelfResSpells.size(); ++i)
    {
        data << int32(SelfResSpells[i]);
    }
    for (uint32 i = 0; i < SpellPctModByLabel.size(); ++i)
    {
        SpellPctModByLabel[i].WriteCreate(data, owner, receiver);
    }
    for (uint32 i = 0; i < SpellFlatModByLabel.size(); ++i)
    {
        SpellFlatModByLabel[i].WriteCreate(data, owner, receiver);
    }
    for (uint32 i = 0; i < TaskQuests.size(); ++i)
    {
        TaskQuests[i].WriteCreate(data, owner, receiver);
    }
    for (uint32 i = 0; i < CategoryCooldownMods.size(); ++i)
    {
        CategoryCooldownMods[i].WriteCreate(data, owner, receiver);
    }
    for (uint32 i = 0; i < WeeklySpellUses.size(); ++i)
    {
        WeeklySpellUses[i].WriteCreate(data, owner, receiver);
    }
    for (uint32 i = 0; i < 7; ++i)
    {
        PvpInfo[i].WriteCreate(data, owner, receiver);
    }
    data.FlushBits();
    data.WriteBit(SortBagsRightToLeft);
    data.WriteBit(InsertItemsLeftToRight);
    data.WriteBits(PetStable.has_value(), 1);
    data.FlushBits();
    ResearchHistory->WriteCreate(data, owner, receiver);
    data << FrozenPerksVendorItem;
    for (uint32 i = 0; i < CharacterRestrictions.size(); ++i)
    {
        CharacterRestrictions[i].WriteCreate(data, owner, receiver);
    }
    for (uint32 i = 0; i < TraitConfigs.size(); ++i)
    {
        TraitConfigs[i].WriteCreate(data, owner, receiver);
    }
    if (PetStable.has_value())
    {
        PetStable->WriteCreate(data, owner, receiver);
    }
    data.FlushBits();
}

void ActivePlayerData::WriteUpdate(ByteBuffer& data, EnumFlag<UpdateFieldFlag> fieldVisibilityFlags, Player const* owner, Player const* receiver) const
{
    WriteUpdate(data, _changesMask, false, owner, receiver);
}

void ActivePlayerData::WriteUpdate(ByteBuffer& data, Mask const& changesMask, bool ignoreNestedChangesMask, Player const* owner, Player const* receiver) const
{
    for (uint32 i = 0; i < 1; ++i)
        data << uint32(changesMask.GetBlocksMask(i));
    data.WriteBits(changesMask.GetBlocksMask(1), 16);
    for (uint32 i = 0; i < 48; ++i)
        if (changesMask.GetBlock(i))
            data.WriteBits(changesMask.GetBlock(i), 32);

    if (changesMask[0])
    {
        if (changesMask[1])
        {
            data.WriteBit(SortBagsRightToLeft);
        }
        if (changesMask[2])
        {
            data.WriteBit(InsertItemsLeftToRight);
        }
        if (changesMask[3])
        {
            if (!ignoreNestedChangesMask)
                KnownTitles.WriteUpdateMask(data);
            else
                WriteCompleteDynamicFieldUpdateMask(KnownTitles.size(), data);
        }
    }
    if (changesMask[20])
    {
        for (uint32 i = 0; i < 1; ++i)
        {
            if (changesMask[21 + i])
            {
                if (!ignoreNestedChangesMask)
                    ResearchSites[i].WriteUpdateMask(data);
                else
                    WriteCompleteDynamicFieldUpdateMask(ResearchSites[i].size(), data);
            }
        }
    }
    if (changesMask[22])
    {
        for (uint32 i = 0; i < 1; ++i)
        {
            if (changesMask[23 + i])
            {
                if (!ignoreNestedChangesMask)
                    ResearchSiteProgress[i].WriteUpdateMask(data);
                else
                    WriteCompleteDynamicFieldUpdateMask(ResearchSiteProgress[i].size(), data);
            }
        }
    }
    if (changesMask[24])
    {
        for (uint32 i = 0; i < 1; ++i)
        {
            if (changesMask[25 + i])
            {
                if (!ignoreNestedChangesMask)
                    Research[i].WriteUpdateMask(data);
                else
                    WriteCompleteDynamicFieldUpdateMask(Research[i].size(), data);
            }
        }
    }
    if (changesMask[20])
    {
