using Framework.GameMath;
using Framework.IO;
using HermesProxy.World.Enums.V3_4_3_54621;
using HermesProxy.World.Server.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesProxy.World.Objects.Version.V3_4_3_54621
{
    // WotLK Classic 3.4.3.54621
    // TODO: This builder is based on TBC Classic (V2_5_3) as a structural starting point.
    // The movement update format and field layout must be verified against actual 3.4.3 packet captures.
    // Differences from TBC Classic include:
    //   - Vehicle seat data in movement packets
    //   - Rune/runic power fields (Death Knight)
    //   - Additional unit flags (UNIT_FIELD_FLAGS, FLAGS_2)
    //   - WotLK-specific player fields (glyphs, daily quests, arena team info)
    //   - Achievement system fields
    public class ObjectUpdateBuilder
    {
        public ObjectUpdateBuilder(ObjectUpdate updateData, GameSessionData gameState)
        {
            m_alreadyWritten = false;
            m_updateData = updateData;
            m_gameState = gameState;

            Enums.ObjectType objectType = updateData.Guid.GetObjectType();
            if (updateData.CreateData != null)
            {
                objectType = updateData.CreateData.ObjectType;
                if (updateData.CreateData.ThisIsYou)
                    objectType = Enums.ObjectType.ActivePlayer;
            }
            if (objectType == Enums.ObjectType.Player && m_gameState.CurrentPlayerGuid == updateData.Guid)
                objectType = Enums.ObjectType.ActivePlayer;
            m_objectType = ObjectTypeConverter.ConvertToBCC(objectType);
            m_objectTypeMask = Enums.ObjectTypeMask.Object;

            uint fieldsSize;
            uint dynamicFieldsSize;
            switch (m_objectType)
            {
                case Enums.ObjectTypeBCC.Item:
                    fieldsSize = (uint)ItemField.ITEM_END;
                    dynamicFieldsSize = (uint)ItemDynamicField.ITEM_DYNAMIC_END;
                    m_objectTypeMask |= Enums.ObjectTypeMask.Item;
                    break;
                case Enums.ObjectTypeBCC.Container:
                    fieldsSize = (uint)ContainerField.CONTAINER_END;
                    dynamicFieldsSize = (uint)ContainerDynamicField.CONTAINER_DYNAMIC_END;
                    m_objectTypeMask |= Enums.ObjectTypeMask.Item;
                    m_objectTypeMask |= Enums.ObjectTypeMask.Container;
                    break;
                case Enums.ObjectTypeBCC.Unit:
                    fieldsSize = (uint)UnitField.UNIT_END;
                    dynamicFieldsSize = (uint)UnitDynamicField.UNIT_DYNAMIC_END;
                    m_objectTypeMask |= Enums.ObjectTypeMask.Unit;
                    break;
                case Enums.ObjectTypeBCC.Player:
                    fieldsSize = (uint)PlayerField.PLAYER_END;
                    dynamicFieldsSize = (uint)PlayerDynamicField.PLAYER_DYNAMIC_END;
                    m_objectTypeMask |= Enums.ObjectTypeMask.Unit;
                    m_objectTypeMask |= Enums.ObjectTypeMask.Player;
                    break;
                case Enums.ObjectTypeBCC.ActivePlayer:
                    fieldsSize = (uint)ActivePlayerField.ACTIVE_PLAYER_END;
                    dynamicFieldsSize = (uint)ActivePlayerDynamicField.ACTIVE_PLAYER_DYNAMIC_END;
                    m_objectTypeMask |= Enums.ObjectTypeMask.Unit;
                    m_objectTypeMask |= Enums.ObjectTypeMask.Player;
                    m_objectTypeMask |= Enums.ObjectTypeMask.ActivePlayer;
                    break;
                case Enums.ObjectTypeBCC.GameObject:
                    fieldsSize = (uint)GameObjectField.GAMEOBJECT_END;
                    dynamicFieldsSize = (uint)GameObjectDynamicField.GAMEOBJECT_DYNAMIC_END;
                    m_objectTypeMask |= Enums.ObjectTypeMask.GameObject;
                    break;
                case Enums.ObjectTypeBCC.DynamicObject:
                    fieldsSize = (uint)DynamicObjectField.DYNAMICOBJECT_END;
                    dynamicFieldsSize = (uint)DynamicObjectDynamicField.DYNAMICOBJECT_DYNAMIC_END;
                    m_objectTypeMask |= Enums.ObjectTypeMask.DynamicObject;
                    break;
                case Enums.ObjectTypeBCC.Corpse:
                    fieldsSize = (uint)CorpseField.CORPSE_END;
                    dynamicFieldsSize = (uint)CorpseDynamicField.CORPSE_DYNAMIC_END;
                    m_objectTypeMask |= Enums.ObjectTypeMask.Corpse;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unsupported object type!");
            }

            m_dynamicFields = new(dynamicFieldsSize, m_updateData.Type);

            m_gameState.ObjectCacheMutex.WaitOne();
            if (m_updateData.CreateData == null &&
                m_gameState.ObjectCacheModern.TryGetValue(updateData.Guid, out m_fields) &&
                m_fields != null)
            {
                m_fields.m_updateMask.Clear();
            }
            else
            {
                m_fields = new UpdateFieldsArray(fieldsSize);
                m_gameState.ObjectCacheModern.Remove(updateData.Guid);
                m_gameState.ObjectCacheModern.Add(updateData.Guid, m_fields);
            }
            m_gameState.ObjectCacheMutex.ReleaseMutex();
        }

        protected bool m_alreadyWritten;
        protected ObjectUpdate m_updateData;
        protected UpdateFieldsArray m_fields;
        protected DynamicUpdateFieldsArray m_dynamicFields;
        protected Enums.ObjectTypeBCC m_objectType;
        protected Enums.ObjectTypeMask m_objectTypeMask;
        protected CreateObjectBits m_createBits;
        protected GameSessionData m_gameState;

        public void WriteToPacket(WorldPacket packet)
        {
            packet.WriteUInt8((byte)m_updateData.Type);
            packet.WritePackedGuid128(m_updateData.Guid);

            if (m_updateData.Type != Enums.UpdateTypeModern.Values)
            {
                packet.WriteUInt8((byte)m_objectType);
                packet.WriteInt32((int)m_objectTypeMask); //< HeirFlags

                SetCreateObjectBits();
                BuildMovementUpdate(packet);
            }
            BuildValuesUpdate(packet);
            BuildDynamicValuesUpdate(packet);
        }

        public void SetCreateObjectBits()
        {
            m_createBits.Clear();
            m_createBits.PlayHoverAnim = m_updateData.CreateData != null & m_updateData.CreateData.MoveInfo != null && m_updateData.CreateData.MoveInfo.Hover;
            m_createBits.MovementUpdate = m_updateData.CreateData != null & m_updateData.CreateData.MoveInfo != null && m_objectTypeMask.HasAnyFlag(Enums.ObjectTypeMask.Unit);
            m_createBits.MovementTransport = m_updateData.CreateData != null & m_updateData.CreateData.MoveInfo != null && m_updateData.CreateData.MoveInfo.TransportGuid != null && m_objectType == Enums.ObjectTypeBCC.GameObject;
            m_createBits.Stationary = m_updateData.CreateData != null & m_updateData.CreateData.MoveInfo != null && !m_objectTypeMask.HasAnyFlag(Enums.ObjectTypeMask.Unit);
            m_createBits.ServerTime = m_updateData.CreateData != null & m_updateData.CreateData.MoveInfo != null && m_updateData.Guid.GetHighType() == Enums.HighGuidType.Transport;
            m_createBits.CombatVictim = m_updateData.CreateData != null && m_updateData.CreateData.AutoAttackVictim != null;
            m_createBits.Vehicle = m_updateData.CreateData != null & m_updateData.CreateData.MoveInfo != null && m_updateData.CreateData.MoveInfo.VehicleId != 0;
            m_createBits.Rotation = m_updateData.CreateData != null & m_updateData.CreateData.MoveInfo != null && m_objectType == Enums.ObjectTypeBCC.GameObject;
            m_createBits.ThisIsYou = m_createBits.ActivePlayer = m_objectType == Enums.ObjectTypeBCC.ActivePlayer;
        }

        public void BuildValuesUpdate(WorldPacket packet)
        {
            WriteValuesToArray();
            m_fields.WriteToPacket(packet);
        }

        public void BuildDynamicValuesUpdate(WorldPacket packet)
        {
            m_dynamicFields.WriteToPacket(packet);
        }

        public void BuildMovementUpdate(WorldPacket data)
        {
            int PauseTimesCount = 0;

            data.WriteBit(m_createBits.NoBirthAnim);
            data.WriteBit(m_createBits.EnablePortals);
            data.WriteBit(m_createBits.PlayHoverAnim);
            data.WriteBit(m_createBits.MovementUpdate);
            data.WriteBit(m_createBits.MovementTransport);
            data.WriteBit(m_createBits.Stationary);
            data.WriteBit(m_createBits.CombatVictim);
            data.WriteBit(m_createBits.ServerTime);
            data.WriteBit(m_createBits.Vehicle);
            data.WriteBit(m_createBits.AnimKit);
            data.WriteBit(m_createBits.Rotation);
            data.WriteBit(m_createBits.AreaTrigger);
            data.WriteBit(m_createBits.GameObject);
            data.WriteBit(m_createBits.SmoothPhasing);
            data.WriteBit(m_createBits.ThisIsYou);
            data.WriteBit(m_createBits.SceneObject);
            data.WriteBit(m_createBits.ActivePlayer);
            data.WriteBit(m_createBits.Conversation);
            data.FlushBits();

            if (m_createBits.MovementUpdate)
            {
                MovementInfo moveInfo = m_updateData.CreateData.MoveInfo;
                bool hasSpline = m_updateData.CreateData.MoveSpline != null;
                moveInfo.WriteMovementInfoModern(data, m_updateData.Guid);

                data.WriteFloat(moveInfo.WalkSpeed);
                data.WriteFloat(moveInfo.RunSpeed);
                data.WriteFloat(moveInfo.RunBackSpeed);
                data.WriteFloat(moveInfo.SwimSpeed);
                data.WriteFloat(moveInfo.SwimBackSpeed);
                data.WriteFloat(moveInfo.FlightSpeed);
                data.WriteFloat(moveInfo.FlightBackSpeed);
                data.WriteFloat(moveInfo.TurnRate);
                data.WriteFloat(moveInfo.PitchRate);

                data.WriteUInt32(0);
                data.WriteFloat(1.0f); // MovementForcesModMagnitude

                data.WriteBit(hasSpline);
                data.FlushBits();

                if (hasSpline)
                    WriteCreateObjectSplineDataBlock(m_updateData.CreateData.MoveSpline, data);
            }

            data.WriteInt32(PauseTimesCount);

            if (m_createBits.Stationary)
            {
                data.WriteFloat(m_updateData.CreateData.MoveInfo.Position.X);
                data.WriteFloat(m_updateData.CreateData.MoveInfo.Position.Y);
                data.WriteFloat(m_updateData.CreateData.MoveInfo.Position.Z);
                data.WriteFloat(m_updateData.CreateData.MoveInfo.Orientation);
            }

            if (m_createBits.CombatVictim)
                data.WritePackedGuid128(m_updateData.CreateData.AutoAttackVictim);

            if (m_createBits.ServerTime)
            {
                if (m_updateData.CreateData.MoveInfo.TransportPathTimer != 0)
                    data.WriteUInt32(m_updateData.CreateData.MoveInfo.TransportPathTimer);
                else
                    data.WriteUInt32((uint)Time.UnixTime);
            }

            if (m_createBits.Vehicle)
            {
                data.WriteUInt32(m_updateData.CreateData.MoveInfo.VehicleId);
                data.WriteFloat(m_updateData.CreateData.MoveInfo.VehicleOrientation);
            }

            if (m_createBits.AnimKit)
            {
                data.WriteUInt16(0); // AiID
                data.WriteUInt16(0); // MovementID
                data.WriteUInt16(0); // MeleeID
            }

            if (m_createBits.Rotation)
                data.WriteInt64(m_updateData.CreateData.MoveInfo.Rotation.GetPackedRotation());

            for (int i = 0; i < PauseTimesCount; ++i)
                data.WriteUInt32(0);

            if (m_createBits.MovementTransport)
                m_updateData.CreateData.MoveInfo.WriteTransportInfoModern(data);

            if (m_createBits.GameObject)
            {
                bool bit8 = false;
                uint Int1 = 0;

                data.WriteUInt32(0); // WorldEffectID

                data.WriteBit(bit8);
                data.FlushBits();
                if (bit8)
                    data.WriteUInt32(Int1);
            }

            if (m_createBits.ActivePlayer)
            {
                bool hasSceneInstanceIDs = false;
                bool hasRuneState = false;
                bool hasActionButtons = m_gameState.ActionButtons.Count != 0;

                data.WriteBit(hasSceneInstanceIDs);
                data.WriteBit(hasRuneState);
                data.WriteBit(hasActionButtons);
                data.FlushBits();

                if (hasSceneInstanceIDs)
                {
                    var sceneInstanceIDs = 0;
                    data.WriteInt32(sceneInstanceIDs);
                    for (var i = 0; i < sceneInstanceIDs; ++i)
                        data.WriteInt32(0);
                }

                if (hasRuneState)
                {
                    byte RechargingRuneMask = 0;
                    byte UsableRuneMask = 0;
                    data.WriteUInt8(RechargingRuneMask);
                    data.WriteUInt8(UsableRuneMask);

                    uint runeCount = 0;
                    data.WriteUInt32(runeCount);
                    for (var i = 0; i < runeCount; ++i)
                        data.WriteUInt8(0); // RuneCooldown
                }

                if (hasActionButtons)
                {
                    for (int i = 0; i < 132; i++)
                        data.WriteInt32(m_gameState.ActionButtons[i]);
                }
            }
        }

        public static void WriteCreateObjectSplineDataBlock(ServerSideMovement moveSpline, WorldPacket data)
        {
            data.WriteUInt32(moveSpline.SplineId);

            if (!moveSpline.SplineFlags.HasAnyFlag(Enums.SplineFlagModern.Cyclic))
                data.WriteVector3(moveSpline.EndPosition);
            else
                data.WriteVector3(Vector3.Zero);

            bool hasSplineMove = data.WriteBit(moveSpline.SplineCount != 0);
            data.FlushBits();

            if (hasSplineMove)
            {
                data.WriteUInt32((uint)moveSpline.SplineFlags);
                data.WriteUInt32(moveSpline.SplineTime);
                data.WriteUInt32(moveSpline.SplineTimeFull);
                data.WriteFloat(1.0f);
                data.WriteFloat(1.0f);
                data.WriteBits((byte)moveSpline.SplineType, 2);
                bool hasFadeObjectTime = data.WriteBit(false);
                data.WriteBits(moveSpline.SplineCount, 16);
                data.WriteBit(false); // HasSplineFilter
                data.WriteBit(false); // HasSpellEffectExtraData
                data.WriteBit(false); // HasJumpExtraData
                data.WriteBit(false); // HasAnimationTierTransition
                data.FlushBits();

                switch (moveSpline.SplineType)
                {
                    case Enums.SplineTypeModern.FacingSpot:
                        data.WriteVector3(moveSpline.FinalFacingSpot);
                        break;
                    case Enums.SplineTypeModern.FacingTarget:
                        data.WritePackedGuid128(moveSpline.FinalFacingGuid);
                        break;
                    case Enums.SplineTypeModern.FacingAngle:
                        data.WriteFloat(moveSpline.FinalOrientation);
                        break;
                }

                if (hasFadeObjectTime)
                    data.WriteInt32(0);

                foreach (var vec in moveSpline.SplinePoints)
                    data.WriteVector3(vec);
            }
        }

        public void WriteValuesToArray()
        {
            if (m_alreadyWritten)
                return;

            // Object fields
            ObjectData objectData = m_updateData.ObjectData;
            if (objectData.Guid != null)
                m_fields.SetUpdateField<WowGuid128>(ObjectField.OBJECT_FIELD_GUID, objectData.Guid);
            if (objectData.EntryID != null)
                m_fields.SetUpdateField<int>(ObjectField.OBJECT_FIELD_ENTRY, (int)objectData.EntryID);
            if (objectData.DynamicFlags != null)
                m_fields.SetUpdateField<uint>(ObjectField.OBJECT_DYNAMIC_FLAGS, (uint)objectData.DynamicFlags);
            if (objectData.Scale != null)
                m_fields.SetUpdateField<float>(ObjectField.OBJECT_FIELD_SCALE_X, (float)objectData.Scale);

            // Item fields
            ItemData itemData = m_updateData.ItemData;
            if (itemData != null)
            {
                if (itemData.Owner != null)
                    m_fields.SetUpdateField<WowGuid128>(ItemField.ITEM_FIELD_OWNER, itemData.Owner);
                if (itemData.ContainedIn != null)
                    m_fields.SetUpdateField<WowGuid128>(ItemField.ITEM_FIELD_CONTAINED, itemData.ContainedIn);
                if (itemData.Creator != null)
                    m_fields.SetUpdateField<WowGuid128>(ItemField.ITEM_FIELD_CREATOR, itemData.Creator);
                if (itemData.GiftCreator != null)
                    m_fields.SetUpdateField<WowGuid128>(ItemField.ITEM_FIELD_GIFTCREATOR, itemData.GiftCreator);
                if (itemData.StackCount != null)
                    m_fields.SetUpdateField<uint>(ItemField.ITEM_FIELD_STACK_COUNT, (uint)itemData.StackCount);
                if (itemData.Duration != null)
                    m_fields.SetUpdateField<uint>(ItemField.ITEM_FIELD_DURATION, (uint)itemData.Duration);
                for (int i = 0; i < 5; i++)
                {
                    int startIndex = (int)ItemField.ITEM_FIELD_SPELL_CHARGES;
                    if (itemData.SpellCharges[i] != null)
                        m_fields.SetUpdateField<int>(startIndex + i, (int)itemData.SpellCharges[i]);
                }
                if (itemData.Flags != null)
                    m_fields.SetUpdateField<uint>(ItemField.ITEM_FIELD_FLAGS, (uint)itemData.Flags);
                for (int i = 0; i < 13; i++)
                {
                    int startIndex = (int)ItemField.ITEM_FIELD_ENCHANTMENT;
                    int sizePerEntry = 3;
                    if (itemData.Enchantment[i] != null)
                    {
                        if (itemData.Enchantment[i].ID != null)
                            m_fields.SetUpdateField<int>(startIndex + i * sizePerEntry, (int)itemData.Enchantment[i].ID);
                        if (itemData.Enchantment[i].Duration != null)
                            m_fields.SetUpdateField<uint>(startIndex + i * sizePerEntry + 1, (uint)itemData.Enchantment[i].Duration);
                        if (itemData.Enchantment[i].Charges != null)
                            m_fields.SetUpdateField<ushort>(startIndex + i * sizePerEntry + 2, (ushort)itemData.Enchantment[i].Charges, 0);
                        if (itemData.Enchantment[i].Inactive != null)
                            m_fields.SetUpdateField<ushort>(startIndex + i * sizePerEntry + 2, (ushort)itemData.Enchantment[i].Inactive, 1);
                    }
                }
                if (itemData.PropertySeed != null)
                    m_fields.SetUpdateField<uint>(ItemField.ITEM_FIELD_PROPERTY_SEED, (uint)itemData.PropertySeed);
                if (itemData.RandomProperty != null)
                    m_fields.SetUpdateField<uint>(ItemField.ITEM_FIELD_RANDOM_PROPERTIES_ID, (uint)itemData.RandomProperty);
                if (itemData.Durability != null)
                    m_fields.SetUpdateField<uint>(ItemField.ITEM_FIELD_DURABILITY, (uint)itemData.Durability);
                if (itemData.MaxDurability != null)
                    m_fields.SetUpdateField<uint>(ItemField.ITEM_FIELD_MAXDURABILITY, (uint)itemData.MaxDurability);
                if (itemData.CreatePlayedTime != null)
                    m_fields.SetUpdateField<uint>(ItemField.ITEM_FIELD_CREATE_PLAYED_TIME, (uint)itemData.CreatePlayedTime);
            }

            // Container fields
            ContainerData containerData = m_updateData.ContainerData;
            if (containerData != null)
            {
                for (int i = 0; i < 36; i++)
                {
                    int startIndex = (int)ContainerField.CONTAINER_FIELD_SLOT_1;
                    int sizePerEntry = 4;
                    if (containerData.Slots[i] != null)
                        m_fields.SetUpdateField<WowGuid128>(startIndex + i * sizePerEntry, containerData.Slots[i]);
                }
                if (containerData.NumSlots != null)
                    m_fields.SetUpdateField<uint>(ContainerField.CONTAINER_FIELD_NUM_SLOTS, (uint)containerData.NumSlots);
            }

            // Unit fields
            UnitData unitData = m_updateData.UnitData;
            if (unitData != null)
            {
                if (unitData.Charm != null)
                    m_fields.SetUpdateField<WowGuid128>(UnitField.UNIT_FIELD_CHARM, unitData.Charm);
                if (unitData.Summon != null)
                    m_fields.SetUpdateField<WowGuid128>(UnitField.UNIT_FIELD_SUMMON, unitData.Summon);
                if (unitData.Critter != null)
                    m_fields.SetUpdateField<WowGuid128>(UnitField.UNIT_FIELD_CRITTER, unitData.Critter);
                if (unitData.CharmedBy != null)
                    m_fields.SetUpdateField<WowGuid128>(UnitField.UNIT_FIELD_CHARMEDBY, unitData.CharmedBy);
                if (unitData.SummonedBy != null)
                    m_fields.SetUpdateField<WowGuid128>(UnitField.UNIT_FIELD_SUMMONEDBY, unitData.SummonedBy);
                if (unitData.CreatedBy != null)
                    m_fields.SetUpdateField<WowGuid128>(UnitField.UNIT_FIELD_CREATEDBY, unitData.CreatedBy);
                if (unitData.Target != null)
                    m_fields.SetUpdateField<WowGuid128>(UnitField.UNIT_FIELD_TARGET, unitData.Target);
                if (unitData.ChannelData != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_CHANNEL_SPELL, (int)unitData.ChannelData.SpellID);
                if (unitData.RaceId != null || unitData.ClassId != null || unitData.SexId != null)
                {
                    if (unitData.RaceId != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_0, (byte)unitData.RaceId, 0);
                    if (unitData.ClassId != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_0, (byte)unitData.ClassId, 1);
                    if (unitData.PlayerClassId != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_0, (byte)unitData.PlayerClassId, 2);
                    if (unitData.SexId != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_0, (byte)unitData.SexId, 3);
                }
                if (unitData.Health != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_HEALTH, (uint)unitData.Health);
                for (int i = 0; i < 7; i++)
                {
                    if (unitData.Power[i] != null)
                        m_fields.SetUpdateField<int>((int)UnitField.UNIT_FIELD_POWER1 + i, (int)unitData.Power[i]);
                }
                if (unitData.MaxHealth != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_MAXHEALTH, (uint)unitData.MaxHealth);
                for (int i = 0; i < 7; i++)
                {
                    if (unitData.MaxPower[i] != null)
                        m_fields.SetUpdateField<int>((int)UnitField.UNIT_FIELD_MAXPOWER1 + i, (int)unitData.MaxPower[i]);
                }
                if (unitData.Level != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_FIELD_LEVEL, (int)unitData.Level);
                if (unitData.FactionTemplate != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_FIELD_FACTIONTEMPLATE, (int)unitData.FactionTemplate);
                for (int i = 0; i < 3; i++)
                {
                    if (unitData.VirtualItems[i] != null)
                        m_fields.SetUpdateField<int>((int)UnitField.UNIT_VIRTUAL_ITEM_SLOT_ID + i, (int)unitData.VirtualItems[i].ItemID);
                }
                if (unitData.Flags != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_FLAGS, (uint)unitData.Flags);
                if (unitData.Flags2 != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_FLAGS_2, (uint)unitData.Flags2);
                if (unitData.AuraState != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_AURASTATE, (uint)unitData.AuraState);
                for (int i = 0; i < 2; i++)
                {
                    if (unitData.AttackRoundBaseTime[i] != null)
                        m_fields.SetUpdateField<uint>((int)UnitField.UNIT_FIELD_BASEATTACKTIME + i, (uint)unitData.AttackRoundBaseTime[i]);
                }
                if (unitData.RangedAttackRoundBaseTime != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_RANGEDATTACKTIME, (uint)unitData.RangedAttackRoundBaseTime);
                if (unitData.BoundingRadius != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_BOUNDINGRADIUS, (float)unitData.BoundingRadius);
                if (unitData.CombatReach != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_COMBATREACH, (float)unitData.CombatReach);
                if (unitData.DisplayID != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_FIELD_DISPLAYID, (int)unitData.DisplayID);
                if (unitData.NativeDisplayID != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_FIELD_NATIVEDISPLAYID, (int)unitData.NativeDisplayID);
                if (unitData.MountDisplayID != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_FIELD_MOUNTDISPLAYID, (int)unitData.MountDisplayID);
                if (unitData.MinDamage != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_MINDAMAGE, (float)unitData.MinDamage);
                if (unitData.MaxDamage != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_MAXDAMAGE, (float)unitData.MaxDamage);
                if (unitData.MinOffHandDamage != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_MINOFFHANDDAMAGE, (float)unitData.MinOffHandDamage);
                if (unitData.MaxOffHandDamage != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_MAXOFFHANDDAMAGE, (float)unitData.MaxOffHandDamage);
                if (unitData.StandState != null || unitData.PetLoyaltyIndex != null || unitData.VisFlags != null || unitData.AnimTier != null)
                {
                    if (unitData.StandState != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_1, (byte)unitData.StandState, 0);
                    if (unitData.PetLoyaltyIndex != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_1, (byte)unitData.PetLoyaltyIndex, 1);
                    if (unitData.VisFlags != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_1, (byte)unitData.VisFlags, 2);
                    if (unitData.AnimTier != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_1, (byte)unitData.AnimTier, 3);
                }
                if (unitData.PetNumber != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_PETNUMBER, (uint)unitData.PetNumber);
                if (unitData.PetNameTimestamp != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_PET_NAME_TIMESTAMP, (uint)unitData.PetNameTimestamp);
                if (unitData.PetExperience != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_PETEXPERIENCE, (uint)unitData.PetExperience);
                if (unitData.PetNextLevelExperience != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_PETNEXTLEVELEXP, (uint)unitData.PetNextLevelExperience);
                if (unitData.DynamicFlags != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_DYNAMIC_FLAGS, (uint)unitData.DynamicFlags);
                if (unitData.ModCastSpeed != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_MOD_CAST_SPEED, (float)unitData.ModCastSpeed);
                if (unitData.ModCastHaste != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_MOD_CAST_HASTE, (float)unitData.ModCastHaste);
                if (unitData.CreatedBySpell != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_CREATED_BY_SPELL, (int)unitData.CreatedBySpell);
                if (unitData.NpcFlags != null && unitData.NpcFlags[0] != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_NPC_FLAGS, (uint)unitData.NpcFlags[0]);
                if (unitData.EmoteState != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_NPC_EMOTESTATE, (int)unitData.EmoteState);
                for (int i = 0; i < 5; i++)
                {
                    if (unitData.Stats[i] != null)
                        m_fields.SetUpdateField<int>((int)UnitField.UNIT_FIELD_STAT0 + i, (int)unitData.Stats[i]);
                }
                for (int i = 0; i < 5; i++)
                {
                    if (unitData.StatPosBuff[i] != null)
                        m_fields.SetUpdateField<int>((int)UnitField.UNIT_FIELD_POSSTAT0 + i, (int)unitData.StatPosBuff[i]);
                }
                for (int i = 0; i < 5; i++)
                {
                    if (unitData.StatNegBuff[i] != null)
                        m_fields.SetUpdateField<int>((int)UnitField.UNIT_FIELD_NEGSTAT0 + i, (int)unitData.StatNegBuff[i]);
                }
                for (int i = 0; i < 7; i++)
                {
                    if (unitData.Resistances[i] != null)
                        m_fields.SetUpdateField<int>((int)UnitField.UNIT_FIELD_RESISTANCES + i, (int)unitData.Resistances[i]);
                }
                if (unitData.BaseMana != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_BASE_MANA, (uint)unitData.BaseMana);
                if (unitData.BaseHealth != null)
                    m_fields.SetUpdateField<uint>(UnitField.UNIT_FIELD_BASE_HEALTH, (uint)unitData.BaseHealth);
                if (unitData.SheathState != null || unitData.PvpFlags != null || unitData.PetFlags != null || unitData.ShapeshiftForm != null)
                {
                    if (unitData.SheathState != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_2, (byte)unitData.SheathState, 0);
                    if (unitData.PvpFlags != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_2, (byte)unitData.PvpFlags, 1);
                    if (unitData.PetFlags != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_2, (byte)unitData.PetFlags, 2);
                    if (unitData.ShapeshiftForm != null)
                        m_fields.SetUpdateField<byte>(UnitField.UNIT_FIELD_BYTES_2, (byte)unitData.ShapeshiftForm, 3);
                }
                if (unitData.AttackPower != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_FIELD_ATTACK_POWER, (int)unitData.AttackPower);
                if (unitData.AttackPowerModPos != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_FIELD_ATTACK_POWER_MOD_POS, (int)unitData.AttackPowerModPos);
                if (unitData.AttackPowerModNeg != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_FIELD_ATTACK_POWER_MOD_NEG, (int)unitData.AttackPowerModNeg);
                if (unitData.AttackPowerMultiplier != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_ATTACK_POWER_MULTIPLIER, (float)unitData.AttackPowerMultiplier);
                if (unitData.RangedAttackPower != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_FIELD_RANGED_ATTACK_POWER, (int)unitData.RangedAttackPower);
                if (unitData.RangedAttackPowerModPos != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_FIELD_RANGED_ATTACK_POWER_MOD_POS, (int)unitData.RangedAttackPowerModPos);
                if (unitData.RangedAttackPowerModNeg != null)
                    m_fields.SetUpdateField<int>(UnitField.UNIT_FIELD_RANGED_ATTACK_POWER_MOD_NEG, (int)unitData.RangedAttackPowerModNeg);
                if (unitData.RangedAttackPowerMultiplier != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER, (float)unitData.RangedAttackPowerMultiplier);
                if (unitData.MinRangedDamage != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_MINRANGEDDAMAGE, (float)unitData.MinRangedDamage);
                if (unitData.MaxRangedDamage != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_MAXRANGEDDAMAGE, (float)unitData.MaxRangedDamage);
                for (int i = 0; i < 7; i++)
                {
                    if (unitData.PowerCostModifier[i] != null)
                        m_fields.SetUpdateField<int>((int)UnitField.UNIT_FIELD_POWER_COST_MODIFIER + i, (int)unitData.PowerCostModifier[i]);
                }
                for (int i = 0; i < 7; i++)
                {
                    if (unitData.PowerCostMultiplier[i] != null)
                        m_fields.SetUpdateField<float>((int)UnitField.UNIT_FIELD_POWER_COST_MULTIPLIER + i, (float)unitData.PowerCostMultiplier[i]);
                }
                if (unitData.MaxHealthModifier != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_MAXHEALTHMODIFIER, (float)unitData.MaxHealthModifier);
                if (unitData.HoverHeight != null)
                    m_fields.SetUpdateField<float>(UnitField.UNIT_FIELD_HOVERHEIGHT, (float)unitData.HoverHeight);
                // TODO: UNIT_FIELD_VEHICLE_ID when VehicleId is available in UnitData
            }

            // Player/ActivePlayer fields
            PlayerData playerData = m_updateData.PlayerData;
            if (playerData != null)
            {
                if (playerData.DuelArbiter != null)
                    m_fields.SetUpdateField<WowGuid128>(PlayerField.PLAYER_DUEL_ARBITER, playerData.DuelArbiter);
                if (playerData.PlayerFlags != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_FLAGS, (uint)playerData.PlayerFlags);
                if (playerData.GuildId != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_GUILDID, (uint)playerData.GuildId);
                if (playerData.GuildRankId != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_GUILDRANK, (uint)playerData.GuildRankId);
                if (playerData.SkinId != null || playerData.FaceId != null || playerData.HairStyleId != null || playerData.HairColorId != null)
                {
                    if (playerData.SkinId != null)
                        m_fields.SetUpdateField<byte>(PlayerField.PLAYER_BYTES, (byte)playerData.SkinId, 0);
                    if (playerData.FaceId != null)
                        m_fields.SetUpdateField<byte>(PlayerField.PLAYER_BYTES, (byte)playerData.FaceId, 1);
                    if (playerData.HairStyleId != null)
                        m_fields.SetUpdateField<byte>(PlayerField.PLAYER_BYTES, (byte)playerData.HairStyleId, 2);
                    if (playerData.HairColorId != null)
                        m_fields.SetUpdateField<byte>(PlayerField.PLAYER_BYTES, (byte)playerData.HairColorId, 3);
                }
                if (playerData.CustomDisplayOption != null || playerData.FacialHairStyleId != null)
                {
                    if (playerData.FacialHairStyleId != null)
                        m_fields.SetUpdateField<byte>(PlayerField.PLAYER_BYTES_2, (byte)playerData.FacialHairStyleId, 0);
                }
                if (playerData.DuelTeam != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_DUEL_TEAM, (uint)playerData.DuelTeam);
                if (playerData.GuildTimestamp != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_GUILD_TIMESTAMP, (uint)playerData.GuildTimestamp);
                if (playerData.PlayerTitle != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_FIELD_KNOWN_TITLES, (uint)playerData.PlayerTitle);
                if (playerData.Xp != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_XP, (uint)playerData.Xp);
                if (playerData.NextLevelXp != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_NEXT_LEVEL_XP, (uint)playerData.NextLevelXp);
                if (playerData.RestExperience != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_REST_STATE_EXPERIENCE, (uint)playerData.RestExperience);
                if (playerData.Coinage != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_FIELD_COINAGE, (uint)playerData.Coinage);
                if (playerData.WatchedFactionIndex != null)
                    m_fields.SetUpdateField<int>(PlayerField.PLAYER_FIELD_WATCHED_FACTION_INDEX, (int)playerData.WatchedFactionIndex);
                if (playerData.LifetimeHonorableKills != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_FIELD_LIFETIME_HONORABLE_KILLS, (uint)playerData.LifetimeHonorableKills);
                if (playerData.HonorCurrency != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_FIELD_HONOR_CURRENCY, (uint)playerData.HonorCurrency);
                if (playerData.ArenaCurrency != null)
                    m_fields.SetUpdateField<uint>(PlayerField.PLAYER_FIELD_ARENA_CURRENCY, (uint)playerData.ArenaCurrency);
                // TODO: Quest log, skill info, inventory slots, combat ratings, arena team, daily quests
                // TODO: Glyph slots (WotLK-specific): PLAYER_FIELD_GLYPH_SLOTS_1, PLAYER_FIELD_GLYPHS_1
            }

            // GameObject fields
            GameObjectData goData = m_updateData.GameObjectData;
            if (goData != null)
            {
                if (goData.CreatedBy != null)
                    m_fields.SetUpdateField<WowGuid128>(GameObjectField.GAMEOBJECT_FIELD_CREATED_BY, goData.CreatedBy);
                if (goData.DisplayID != null)
                    m_fields.SetUpdateField<uint>(GameObjectField.GAMEOBJECT_DISPLAYID, (uint)goData.DisplayID);
                if (goData.Flags != null)
                    m_fields.SetUpdateField<uint>(GameObjectField.GAMEOBJECT_FLAGS, (uint)goData.Flags);
                if (goData.Faction != null)
                    m_fields.SetUpdateField<uint>(GameObjectField.GAMEOBJECT_FACTION, (uint)goData.Faction);
                if (goData.Level != null)
                    m_fields.SetUpdateField<int>(GameObjectField.GAMEOBJECT_LEVEL, (int)goData.Level);
                if (goData.State != null || goData.TypeID != null || goData.ArtKit != null || goData.AnimProgress != null)
                {
                    if (goData.State != null)
                        m_fields.SetUpdateField<byte>(GameObjectField.GAMEOBJECT_BYTES_1, (byte)goData.State, 0);
                    if (goData.TypeID != null)
                        m_fields.SetUpdateField<byte>(GameObjectField.GAMEOBJECT_BYTES_1, (byte)goData.TypeID, 1);
                    if (goData.ArtKit != null)
                        m_fields.SetUpdateField<byte>(GameObjectField.GAMEOBJECT_BYTES_1, (byte)goData.ArtKit, 2);
                    if (goData.AnimProgress != null)
                        m_fields.SetUpdateField<byte>(GameObjectField.GAMEOBJECT_BYTES_1, (byte)goData.AnimProgress, 3);
                }
            }

            // DynamicObject fields
            DynamicObjectData dynObjData = m_updateData.DynamicObjectData;
            if (dynObjData != null)
            {
                if (dynObjData.Caster != null)
                    m_fields.SetUpdateField<WowGuid128>(DynamicObjectField.DYNAMICOBJECT_CASTER, dynObjData.Caster);
                if (dynObjData.SpellID != null)
                    m_fields.SetUpdateField<int>(DynamicObjectField.DYNAMICOBJECT_SPELLID, (int)dynObjData.SpellID);
                if (dynObjData.Radius != null)
                    m_fields.SetUpdateField<float>(DynamicObjectField.DYNAMICOBJECT_RADIUS, (float)dynObjData.Radius);
                if (dynObjData.CastTime != null)
                    m_fields.SetUpdateField<uint>(DynamicObjectField.DYNAMICOBJECT_CASTTIME, (uint)dynObjData.CastTime);
            }

            // Corpse fields
            CorpseData corpseData = m_updateData.CorpseData;
            if (corpseData != null)
            {
                if (corpseData.Owner != null)
                    m_fields.SetUpdateField<WowGuid128>(CorpseField.CORPSE_FIELD_OWNER, corpseData.Owner);
                if (corpseData.PartyGUID != null)
                    m_fields.SetUpdateField<WowGuid128>(CorpseField.CORPSE_FIELD_PARTY, corpseData.PartyGUID);
                if (corpseData.DisplayID != null)
                    m_fields.SetUpdateField<uint>(CorpseField.CORPSE_FIELD_DISPLAY_ID, (uint)corpseData.DisplayID);
                if (corpseData.Flags != null)
                    m_fields.SetUpdateField<uint>(CorpseField.CORPSE_FIELD_FLAGS, (uint)corpseData.Flags);
                if (corpseData.DynamicFlags != null)
                    m_fields.SetUpdateField<uint>(CorpseField.CORPSE_FIELD_DYNAMIC_FLAGS, (uint)corpseData.DynamicFlags);
                if (corpseData.Guild != null)
                    m_fields.SetUpdateField<uint>(CorpseField.CORPSE_FIELD_GUILD, (uint)corpseData.Guild);
            }

            m_alreadyWritten = true;
        }
    }
}
