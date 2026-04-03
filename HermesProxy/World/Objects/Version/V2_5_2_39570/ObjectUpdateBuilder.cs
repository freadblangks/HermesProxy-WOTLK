using System;
using System.Collections.Generic;
using Framework.GameMath;
using HermesProxy.World.Enums;
using HermesProxy.World.Enums.V2_5_2_39570;
using HermesProxy.World.Server.Packets;

namespace HermesProxy.World.Objects.Version.V2_5_2_39570;

public class ObjectUpdateBuilder
{
	protected bool m_alreadyWritten;

	protected ObjectUpdate m_updateData;

	protected UpdateFieldsArray m_fields;

	protected DynamicUpdateFieldsArray m_dynamicFields;

	protected ObjectTypeBCC m_objectType;

	protected ObjectTypeMask m_objectTypeMask;

	protected CreateObjectBits m_createBits;

	protected GameSessionData m_gameState;

	public ObjectUpdateBuilder(ObjectUpdate updateData, GameSessionData gameState)
	{
		this.m_alreadyWritten = false;
		this.m_updateData = updateData;
		this.m_gameState = gameState;
		ObjectType objectType = updateData.Guid.GetObjectType();
		if (updateData.CreateData != null)
		{
			objectType = updateData.CreateData.ObjectType;
			if (updateData.CreateData.ThisIsYou)
			{
				objectType = ObjectType.ActivePlayer;
			}
		}
		if (objectType == ObjectType.Player && this.m_gameState.CurrentPlayerGuid == updateData.Guid)
		{
			objectType = ObjectType.ActivePlayer;
		}
		this.m_objectType = ObjectTypeConverter.ConvertToBCC(objectType);
		this.m_objectTypeMask = ObjectTypeMask.Object;
		uint fieldsSize;
		uint dynamicFieldsSize;
		switch (this.m_objectType)
		{
		case ObjectTypeBCC.Item:
			fieldsSize = 80u;
			dynamicFieldsSize = 4u;
			this.m_objectTypeMask |= ObjectTypeMask.Item;
			break;
		case ObjectTypeBCC.Container:
			fieldsSize = 225u;
			dynamicFieldsSize = 4u;
			this.m_objectTypeMask |= ObjectTypeMask.Item;
			this.m_objectTypeMask |= ObjectTypeMask.Container;
			break;
		case ObjectTypeBCC.Unit:
			fieldsSize = 215u;
			dynamicFieldsSize = 3u;
			this.m_objectTypeMask |= ObjectTypeMask.Unit;
			break;
		case ObjectTypeBCC.Player:
			fieldsSize = 759u;
			dynamicFieldsSize = 4u;
			this.m_objectTypeMask |= ObjectTypeMask.Unit;
			this.m_objectTypeMask |= ObjectTypeMask.Player;
			break;
		case ObjectTypeBCC.ActivePlayer:
			fieldsSize = 4679u;
			dynamicFieldsSize = 18u;
			this.m_objectTypeMask |= ObjectTypeMask.Unit;
			this.m_objectTypeMask |= ObjectTypeMask.Player;
			this.m_objectTypeMask |= ObjectTypeMask.ActivePlayer;
			break;
		case ObjectTypeBCC.GameObject:
			fieldsSize = 33u;
			dynamicFieldsSize = 1u;
			this.m_objectTypeMask |= ObjectTypeMask.GameObject;
			break;
		case ObjectTypeBCC.DynamicObject:
			fieldsSize = 16u;
			dynamicFieldsSize = 0u;
			this.m_objectTypeMask |= ObjectTypeMask.DynamicObject;
			break;
		case ObjectTypeBCC.Corpse:
			fieldsSize = 115u;
			dynamicFieldsSize = 0u;
			this.m_objectTypeMask |= ObjectTypeMask.Corpse;
			break;
		default:
			throw new ArgumentOutOfRangeException("Unsupported object type!");
		}
		this.m_dynamicFields = new DynamicUpdateFieldsArray(dynamicFieldsSize, this.m_updateData.Type);
		this.m_gameState.ObjectCacheMutex.WaitOne();
		if (this.m_updateData.CreateData == null && this.m_gameState.ObjectCacheModern.TryGetValue(updateData.Guid, out this.m_fields) && this.m_fields != null)
		{
			this.m_fields.m_updateMask.Clear();
		}
		else
		{
			this.m_fields = new UpdateFieldsArray(fieldsSize);
			this.m_gameState.ObjectCacheModern.Remove(updateData.Guid);
			this.m_gameState.ObjectCacheModern.Add(updateData.Guid, this.m_fields);
		}
		this.m_gameState.ObjectCacheMutex.ReleaseMutex();
	}

	public void WriteToPacket(WorldPacket packet)
	{
		packet.WriteUInt8((byte)this.m_updateData.Type);
		packet.WritePackedGuid128(this.m_updateData.Guid);
		if (this.m_updateData.Type != UpdateTypeModern.Values)
		{
			packet.WriteUInt8((byte)this.m_objectType);
			packet.WriteInt32((int)this.m_objectTypeMask);
			this.SetCreateObjectBits();
			this.BuildMovementUpdate(packet);
		}
		this.BuildValuesUpdate(packet);
		this.BuildDynamicValuesUpdate(packet);
	}

	public void SetCreateObjectBits()
	{
		this.m_createBits.Clear();
		this.m_createBits.PlayHoverAnim = ((this.m_updateData.CreateData != null) & (this.m_updateData.CreateData.MoveInfo != null)) && this.m_updateData.CreateData.MoveInfo.Hover;
		this.m_createBits.MovementUpdate = ((this.m_updateData.CreateData != null) & (this.m_updateData.CreateData.MoveInfo != null)) && this.m_objectTypeMask.HasAnyFlag(ObjectTypeMask.Unit);
		this.m_createBits.MovementTransport = ((this.m_updateData.CreateData != null) & (this.m_updateData.CreateData.MoveInfo != null)) && this.m_updateData.CreateData.MoveInfo.TransportGuid != null && this.m_objectType == ObjectTypeBCC.GameObject;
		this.m_createBits.Stationary = ((this.m_updateData.CreateData != null) & (this.m_updateData.CreateData.MoveInfo != null)) && !this.m_objectTypeMask.HasAnyFlag(ObjectTypeMask.Unit);
		this.m_createBits.ServerTime = ((this.m_updateData.CreateData != null) & (this.m_updateData.CreateData.MoveInfo != null)) && this.m_updateData.Guid.GetHighType() == HighGuidType.Transport;
		this.m_createBits.CombatVictim = this.m_updateData.CreateData != null && this.m_updateData.CreateData.AutoAttackVictim != null;
		this.m_createBits.Vehicle = ((this.m_updateData.CreateData != null) & (this.m_updateData.CreateData.MoveInfo != null)) && this.m_updateData.CreateData.MoveInfo.VehicleId != 0;
		this.m_createBits.Rotation = ((this.m_updateData.CreateData != null) & (this.m_updateData.CreateData.MoveInfo != null)) && this.m_objectType == ObjectTypeBCC.GameObject;
		this.m_createBits.ThisIsYou = (this.m_createBits.ActivePlayer = this.m_objectType == ObjectTypeBCC.ActivePlayer);
	}

	public void BuildValuesUpdate(WorldPacket packet)
	{
		this.WriteValuesToArray();
		this.m_fields.WriteToPacket(packet);
	}

	public void BuildDynamicValuesUpdate(WorldPacket packet)
	{
		this.m_dynamicFields.WriteToPacket(packet);
	}

	public void BuildMovementUpdate(WorldPacket data)
	{
		int PauseTimesCount = 0;
		data.WriteBit(this.m_createBits.NoBirthAnim);
		data.WriteBit(this.m_createBits.EnablePortals);
		data.WriteBit(this.m_createBits.PlayHoverAnim);
		data.WriteBit(this.m_createBits.MovementUpdate);
		data.WriteBit(this.m_createBits.MovementTransport);
		data.WriteBit(this.m_createBits.Stationary);
		data.WriteBit(this.m_createBits.CombatVictim);
		data.WriteBit(this.m_createBits.ServerTime);
		data.WriteBit(this.m_createBits.Vehicle);
		data.WriteBit(this.m_createBits.AnimKit);
		data.WriteBit(this.m_createBits.Rotation);
		data.WriteBit(this.m_createBits.AreaTrigger);
		data.WriteBit(this.m_createBits.GameObject);
		data.WriteBit(this.m_createBits.SmoothPhasing);
		data.WriteBit(this.m_createBits.ThisIsYou);
		data.WriteBit(this.m_createBits.SceneObject);
		data.WriteBit(this.m_createBits.ActivePlayer);
		data.WriteBit(this.m_createBits.Conversation);
		data.FlushBits();
		if (this.m_createBits.MovementUpdate)
		{
			MovementInfo moveInfo = this.m_updateData.CreateData.MoveInfo;
			bool hasSpline = this.m_updateData.CreateData.MoveSpline != null;
			moveInfo.WriteMovementInfoModern(data, this.m_updateData.Guid);
			data.WriteFloat(moveInfo.WalkSpeed);
			data.WriteFloat(moveInfo.RunSpeed);
			data.WriteFloat(moveInfo.RunBackSpeed);
			data.WriteFloat(moveInfo.SwimSpeed);
			data.WriteFloat(moveInfo.SwimBackSpeed);
			data.WriteFloat(moveInfo.FlightSpeed);
			data.WriteFloat(moveInfo.FlightBackSpeed);
			data.WriteFloat(moveInfo.TurnRate);
			data.WriteFloat(moveInfo.PitchRate);
			data.WriteUInt32(0u);
			data.WriteFloat(1f);
			data.WriteBit(hasSpline);
			data.FlushBits();
			if (hasSpline)
			{
				ObjectUpdateBuilder.WriteCreateObjectSplineDataBlock(this.m_updateData.CreateData.MoveSpline, data);
			}
		}
		data.WriteInt32(PauseTimesCount);
		if (this.m_createBits.Stationary)
		{
			data.WriteFloat(this.m_updateData.CreateData.MoveInfo.Position.X);
			data.WriteFloat(this.m_updateData.CreateData.MoveInfo.Position.Y);
			data.WriteFloat(this.m_updateData.CreateData.MoveInfo.Position.Z);
			data.WriteFloat(this.m_updateData.CreateData.MoveInfo.Orientation);
		}
		if (this.m_createBits.CombatVictim)
		{
			data.WritePackedGuid128(this.m_updateData.CreateData.AutoAttackVictim);
		}
		if (this.m_createBits.ServerTime)
		{
			if (this.m_updateData.CreateData.MoveInfo.TransportPathTimer != 0)
			{
				data.WriteUInt32(this.m_updateData.CreateData.MoveInfo.TransportPathTimer);
			}
			else
			{
				data.WriteUInt32((uint)Time.UnixTime);
			}
		}
		if (this.m_createBits.Vehicle)
		{
			data.WriteUInt32(this.m_updateData.CreateData.MoveInfo.VehicleId);
			data.WriteFloat(this.m_updateData.CreateData.MoveInfo.VehicleOrientation);
		}
		if (this.m_createBits.AnimKit)
		{
			data.WriteUInt16(0);
			data.WriteUInt16(0);
			data.WriteUInt16(0);
		}
		if (this.m_createBits.Rotation)
		{
			data.WriteInt64(this.m_updateData.CreateData.MoveInfo.Rotation.GetPackedRotation());
		}
		for (int i = 0; i < PauseTimesCount; i++)
		{
			data.WriteUInt32(0u);
		}
		if (this.m_createBits.MovementTransport)
		{
			this.m_updateData.CreateData.MoveInfo.WriteTransportInfoModern(data);
		}
		if (this.m_createBits.GameObject)
		{
			bool bit8 = false;
			uint Int1 = 0u;
			data.WriteUInt32(0u);
			data.WriteBit(bit8);
			data.FlushBits();
			if (bit8)
			{
				data.WriteUInt32(Int1);
			}
		}
		if (!this.m_createBits.ActivePlayer)
		{
			return;
		}
		bool hasSceneInstanceIDs = false;
		bool hasRuneState = false;
		bool hasActionButtons = this.m_gameState.ActionButtons.Count != 0;
		data.WriteBit(hasSceneInstanceIDs);
		data.WriteBit(hasRuneState);
		data.WriteBit(hasActionButtons);
		data.FlushBits();
		if (hasSceneInstanceIDs)
		{
			int sceneInstanceIDs = 0;
			data.WriteInt32(sceneInstanceIDs);
			for (int j = 0; j < sceneInstanceIDs; j++)
			{
				data.WriteInt32(0);
			}
		}
		if (hasRuneState)
		{
			byte RechargingRuneMask = 0;
			byte UsableRuneMask = 0;
			data.WriteUInt8(RechargingRuneMask);
			data.WriteUInt8(UsableRuneMask);
			uint runeCount = 0u;
			data.WriteUInt32(runeCount);
			for (int k = 0; k < runeCount; k++)
			{
				data.WriteUInt8(0);
			}
		}
		if (hasActionButtons)
		{
			for (int l = 0; l < 132; l++)
			{
				data.WriteInt32(this.m_gameState.ActionButtons[l]);
			}
		}
	}

	public static void WriteCreateObjectSplineDataBlock(ServerSideMovement moveSpline, WorldPacket data)
	{
		data.WriteUInt32(moveSpline.SplineId);
		if (!moveSpline.SplineFlags.HasAnyFlag(SplineFlagModern.Cyclic))
		{
			data.WriteVector3(moveSpline.EndPosition);
		}
		else
		{
			data.WriteVector3(Vector3.Zero);
		}
		bool hasSplineMove = data.WriteBit(moveSpline.SplineCount != 0);
		data.FlushBits();
		if (!hasSplineMove)
		{
			return;
		}
		data.WriteUInt32((uint)moveSpline.SplineFlags);
		data.WriteUInt32(moveSpline.SplineTime);
		data.WriteUInt32(moveSpline.SplineTimeFull);
		data.WriteFloat(1f);
		data.WriteFloat(1f);
		data.WriteBits((byte)moveSpline.SplineType, 2);
		bool hasFadeObjectTime = data.WriteBit(bit: false);
		data.WriteBits(moveSpline.SplineCount, 16);
		data.WriteBit(bit: false);
		data.WriteBit(bit: false);
		data.WriteBit(bit: false);
		data.WriteBit(bit: false);
		data.FlushBits();
		switch (moveSpline.SplineType)
		{
		case SplineTypeModern.FacingSpot:
			data.WriteVector3(moveSpline.FinalFacingSpot);
			break;
		case SplineTypeModern.FacingTarget:
			data.WritePackedGuid128(moveSpline.FinalFacingGuid);
			break;
		case SplineTypeModern.FacingAngle:
			data.WriteFloat(moveSpline.FinalOrientation);
			break;
		}
		if (hasFadeObjectTime)
		{
			data.WriteInt32(0);
		}
		foreach (Vector3 vec in moveSpline.SplinePoints)
		{
			data.WriteVector3(vec);
		}
	}

	public void WriteValuesToArray()
	{
		if (this.m_alreadyWritten)
		{
			return;
		}
		ObjectData objectData = this.m_updateData.ObjectData;
		if (objectData.Guid != null)
		{
			this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ObjectField.OBJECT_FIELD_GUID, objectData.Guid, 0);
		}
		if (objectData.EntryID.HasValue)
		{
			this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ObjectField.OBJECT_FIELD_ENTRY, objectData.EntryID.Value, 0);
		}
		if (objectData.DynamicFlags.HasValue)
		{
			this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ObjectField.OBJECT_DYNAMIC_FLAGS, objectData.DynamicFlags.Value, 0);
		}
		if (objectData.Scale.HasValue)
		{
			this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ObjectField.OBJECT_FIELD_SCALE_X, objectData.Scale.Value, 0);
		}
		ItemData itemData = this.m_updateData.ItemData;
		if (itemData != null)
		{
			if (itemData.Owner != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_OWNER, itemData.Owner, 0);
			}
			if (itemData.ContainedIn != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_CONTAINED, itemData.ContainedIn, 0);
			}
			if (itemData.Creator != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_CREATOR, itemData.Creator, 0);
			}
			if (itemData.GiftCreator != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_GIFTCREATOR, itemData.GiftCreator, 0);
			}
			if (itemData.StackCount.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_STACK_COUNT, itemData.StackCount.Value, 0);
			}
			if (itemData.Duration.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_DURATION, itemData.Duration.Value, 0);
			}
			for (int i = 0; i < 5; i++)
			{
				int startIndex = 25;
				if (itemData.SpellCharges[i].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex + i, itemData.SpellCharges[i].Value, 0);
				}
			}
			if (itemData.Flags.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_FLAGS, itemData.Flags.Value, 0);
			}
			for (int j = 0; j < 13; j++)
			{
				int startIndex2 = 31;
				int sizePerEntry = 3;
				if (itemData.Enchantment[j] != null)
				{
					if (itemData.Enchantment[j].ID.HasValue)
					{
						this.m_fields.SetUpdateField(startIndex2 + j * sizePerEntry, itemData.Enchantment[j].ID.Value, 0);
					}
					if (itemData.Enchantment[j].Duration.HasValue)
					{
						this.m_fields.SetUpdateField(startIndex2 + j * sizePerEntry + 1, itemData.Enchantment[j].Duration.Value, 0);
					}
					if (itemData.Enchantment[j].Charges.HasValue)
					{
						this.m_fields.SetUpdateField(startIndex2 + j * sizePerEntry + 2, itemData.Enchantment[j].Charges.Value, 0);
					}
					if (itemData.Enchantment[j].Inactive.HasValue)
					{
						this.m_fields.SetUpdateField(startIndex2 + j * sizePerEntry + 2, itemData.Enchantment[j].Inactive.Value, 1);
					}
				}
			}
			if (itemData.PropertySeed.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_PROPERTY_SEED, itemData.PropertySeed.Value, 0);
			}
			if (itemData.RandomProperty.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_RANDOM_PROPERTIES_ID, itemData.RandomProperty.Value, 0);
			}
			if (itemData.Durability.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_DURABILITY, itemData.Durability.Value, 0);
			}
			if (itemData.MaxDurability.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_MAXDURABILITY, itemData.MaxDurability.Value, 0);
			}
			if (itemData.CreatePlayedTime.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_CREATE_PLAYED_TIME, itemData.CreatePlayedTime.Value, 0);
			}
			if (itemData.ModifiersMask.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_MODIFIERS_MASK, itemData.ModifiersMask.Value, 0);
			}
			if (itemData.Context.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_CONTEXT, itemData.Context.Value, 0);
			}
			if (itemData.ArtifactXP.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_ARTIFACT_XP, itemData.ArtifactXP.Value, 0);
			}
			if (itemData.ItemAppearanceModID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ItemField.ITEM_FIELD_APPEARANCE_MOD_ID, itemData.ItemAppearanceModID.Value, 0);
			}
			if (itemData.HasGemsUpdate)
			{
				uint[] fields = new uint[30];
				uint[] gems = this.m_gameState.GetGemsForItem(this.m_updateData.Guid);
				fields[0] = gems[0];
				fields[10] = gems[1];
				fields[20] = gems[2];
				this.m_dynamicFields.SetUpdateField(3, fields, DynamicFieldChangeType.ValueAndSizeChanged);
			}
		}
		ContainerData containerData = this.m_updateData.ContainerData;
		if (containerData != null)
		{
			for (int k = 0; k < 36; k++)
			{
				int startIndex3 = 80;
				int sizePerEntry2 = 4;
				if (containerData.Slots[k] != null)
				{
					this.m_fields.SetUpdateField(startIndex3 + k * sizePerEntry2, containerData.Slots[k], 0);
				}
			}
			if (containerData.NumSlots.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ContainerField.CONTAINER_FIELD_NUM_SLOTS, containerData.NumSlots.Value, 0);
			}
		}
		UnitData unitData = this.m_updateData.UnitData;
		if (unitData != null)
		{
			if (unitData.Charm != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_CHARM, unitData.Charm, 0);
			}
			if (unitData.Summon != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_SUMMON, unitData.Summon, 0);
			}
			if (unitData.Critter != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_CRITTER, unitData.Critter, 0);
			}
			if (unitData.CharmedBy != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_CHARMEDBY, unitData.CharmedBy, 0);
			}
			if (unitData.SummonedBy != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_SUMMONEDBY, unitData.SummonedBy, 0);
			}
			if (unitData.CreatedBy != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_CREATEDBY, unitData.CreatedBy, 0);
			}
			if (unitData.DemonCreator != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_DEMON_CREATOR, unitData.DemonCreator, 0);
			}
			if (unitData.LookAtControllerTarget != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_LOOK_AT_CONTROLLER_TARGET, unitData.LookAtControllerTarget, 0);
			}
			if (unitData.Target != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_TARGET, unitData.Target, 0);
			}
			if (unitData.BattlePetCompanionGUID != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BATTLE_PET_COMPANION_GUID, unitData.BattlePetCompanionGUID, 0);
			}
			if (unitData.BattlePetDBID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BATTLE_PET_DB_ID, unitData.BattlePetDBID.Value, 0);
			}
			if (unitData.ChannelData != null)
			{
				int startIndex4 = 49;
				this.m_fields.SetUpdateField(startIndex4, unitData.ChannelData.SpellID, 0);
				this.m_fields.SetUpdateField(startIndex4 + 1, unitData.ChannelData.SpellXSpellVisualID, 0);
			}
			if (unitData.SummonedByHomeRealm.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_SUMMONED_BY_HOME_REALM, unitData.SummonedByHomeRealm.Value, 0);
			}
			if (unitData.RaceId.HasValue || unitData.ClassId.HasValue || unitData.PlayerClassId.HasValue || unitData.SexId.HasValue)
			{
				if (unitData.RaceId.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_0, unitData.RaceId.Value, 0);
				}
				if (unitData.ClassId.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_0, unitData.ClassId.Value, 1);
				}
				if (unitData.PlayerClassId.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_0, unitData.PlayerClassId.Value, 2);
				}
				if (unitData.SexId.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_0, unitData.SexId.Value, 3);
				}
			}
			if (unitData.DisplayPower.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_DISPLAY_POWER, unitData.DisplayPower.Value, 0);
			}
			if (unitData.OverrideDisplayPowerID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_OVERRIDE_DISPLAY_POWER_ID, unitData.OverrideDisplayPowerID.Value, 0);
			}
			if (unitData.Health.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_HEALTH, (ulong)unitData.Health.Value, 0);
			}
			for (int l = 0; l < 6; l++)
			{
				int startIndex5 = 57;
				if (unitData.Power[l].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex5 + l, unitData.Power[l].Value, 0);
				}
			}
			if (unitData.MaxHealth.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MAXHEALTH, (ulong)unitData.MaxHealth.Value, 0);
			}
			for (int m = 0; m < 6; m++)
			{
				int startIndex6 = 65;
				if (unitData.MaxPower[m].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex6 + m, unitData.MaxPower[m].Value, 0);
				}
			}
			for (int n = 0; n < 6; n++)
			{
				int startIndex7 = 71;
				if (unitData.ModPowerRegen[n].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex7 + n, unitData.ModPowerRegen[n].Value, 0);
				}
			}
			if (unitData.Level.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_LEVEL, unitData.Level.Value, 0);
			}
			if (unitData.EffectiveLevel.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_EFFECTIVE_LEVEL, unitData.EffectiveLevel.Value, 0);
			}
			if (unitData.ContentTuningID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_CONTENT_TUNING_ID, unitData.ContentTuningID.Value, 0);
			}
			if (unitData.ScalingLevelMin.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_SCALING_LEVEL_MIN, unitData.ScalingLevelMin.Value, 0);
			}
			if (unitData.ScalingLevelMax.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_SCALING_LEVEL_MAX, unitData.ScalingLevelMax.Value, 0);
			}
			if (unitData.ScalingLevelDelta.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_SCALING_LEVEL_DELTA, unitData.ScalingLevelDelta.Value, 0);
			}
			if (unitData.ScalingFactionGroup.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_SCALING_FACTION_GROUP, unitData.ScalingFactionGroup.Value, 0);
			}
			if (unitData.ScalingHealthItemLevelCurveID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_SCALING_HEALTH_ITEM_LEVEL_CURVE_ID, unitData.ScalingHealthItemLevelCurveID.Value, 0);
			}
			if (unitData.ScalingDamageItemLevelCurveID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_SCALING_DAMAGE_ITEM_LEVEL_CURVE_ID, unitData.ScalingDamageItemLevelCurveID.Value, 0);
			}
			if (unitData.FactionTemplate.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_FACTIONTEMPLATE, unitData.FactionTemplate.Value, 0);
			}
			for (int num = 0; num < 3; num++)
			{
				int startIndex8 = 87;
				int sizePerEntry3 = 2;
				if (unitData.VirtualItems[num] != null)
				{
					this.m_fields.SetUpdateField(startIndex8 + num * sizePerEntry3, unitData.VirtualItems[num].ItemID, 0);
					this.m_fields.SetUpdateField(startIndex8 + num * sizePerEntry3 + 1, unitData.VirtualItems[num].ItemAppearanceModID, 0);
					this.m_fields.SetUpdateField(startIndex8 + num * sizePerEntry3 + 1, unitData.VirtualItems[num].ItemVisual, 1);
				}
			}
			if (unitData.Flags.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_FLAGS, unitData.Flags.Value, 0);
			}
			if (unitData.Flags2.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_FLAGS_2, unitData.Flags2.Value, 0);
			}
			if (unitData.Flags3.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_FLAGS_3, unitData.Flags3.Value, 0);
			}
			if (unitData.AuraState.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_AURASTATE, unitData.AuraState.Value, 0);
			}
			for (int num2 = 0; num2 < 2; num2++)
			{
				int startIndex9 = 97;
				if (unitData.AttackRoundBaseTime[num2].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex9 + num2, unitData.AttackRoundBaseTime[num2].Value, 0);
				}
			}
			if (unitData.RangedAttackRoundBaseTime.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_RANGEDATTACKTIME, unitData.RangedAttackRoundBaseTime.Value, 0);
			}
			if (unitData.BoundingRadius.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BOUNDINGRADIUS, unitData.BoundingRadius.Value, 0);
			}
			if (unitData.CombatReach.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_COMBATREACH, unitData.CombatReach.Value, 0);
			}
			if (unitData.DisplayID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_DISPLAYID, unitData.DisplayID.Value, 0);
			}
			if (unitData.DisplayScale.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_DISPLAY_SCALE, unitData.DisplayScale.Value, 0);
			}
			if (unitData.NativeDisplayID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_NATIVEDISPLAYID, unitData.NativeDisplayID.Value, 0);
			}
			if (unitData.NativeXDisplayScale.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_NATIVE_X_DISPLAY_SCALE, unitData.NativeXDisplayScale.Value, 0);
			}
			if (unitData.MountDisplayID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MOUNTDISPLAYID, unitData.MountDisplayID.Value, 0);
			}
			if (unitData.MinDamage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MINDAMAGE, unitData.MinDamage.Value, 0);
			}
			if (unitData.MaxDamage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MAXDAMAGE, unitData.MaxDamage.Value, 0);
			}
			if (unitData.MinOffHandDamage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MINOFFHANDDAMAGE, unitData.MinOffHandDamage.Value, 0);
			}
			if (unitData.MaxOffHandDamage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MAXOFFHANDDAMAGE, unitData.MaxOffHandDamage.Value, 0);
			}
			if (unitData.StandState.HasValue || unitData.PetLoyaltyIndex.HasValue || unitData.VisFlags.HasValue || unitData.AnimTier.HasValue)
			{
				if (unitData.StandState.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_1, unitData.StandState.Value, 0);
				}
				if (unitData.PetLoyaltyIndex.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_1, unitData.PetLoyaltyIndex.Value, 1);
				}
				if (unitData.VisFlags.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_1, unitData.VisFlags.Value, 2);
				}
				if (unitData.AnimTier.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_1, unitData.AnimTier.Value, 3);
				}
			}
			if (unitData.PetNumber.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_PETNUMBER, unitData.PetNumber.Value, 0);
			}
			if (unitData.PetNameTimestamp.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_PET_NAME_TIMESTAMP, unitData.PetNameTimestamp.Value, 0);
			}
			if (unitData.PetExperience.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_PETEXPERIENCE, unitData.PetExperience.Value, 0);
			}
			if (unitData.PetNextLevelExperience.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_PETNEXTLEVELXP, unitData.PetNextLevelExperience.Value, 0);
			}
			if (unitData.ModCastSpeed.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_MOD_CAST_SPEED, unitData.ModCastSpeed.Value, 0);
			}
			if (unitData.ModCastHaste.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_MOD_CAST_HASTE, unitData.ModCastHaste.Value, 0);
			}
			if (unitData.ModHaste.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MOD_HASTE, unitData.ModHaste.Value, 0);
			}
			if (unitData.ModRangedHaste.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MOD_RANGED_HASTE, unitData.ModRangedHaste.Value, 0);
			}
			if (unitData.ModHasteRegen.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MOD_HASTE_REGEN, unitData.ModHasteRegen.Value, 0);
			}
			if (unitData.ModTimeRate.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MOD_TIME_RATE, unitData.ModTimeRate.Value, 0);
			}
			if (unitData.CreatedBySpell.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_CREATED_BY_SPELL, unitData.CreatedBySpell.Value, 0);
			}
			for (int num3 = 0; num3 < 2; num3++)
			{
				int startIndex10 = 123;
				if (unitData.NpcFlags[num3].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex10 + num3, unitData.NpcFlags[num3].Value, 0);
				}
			}
			if (unitData.EmoteState.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_NPC_EMOTESTATE, unitData.EmoteState.Value, 0);
			}
			if (unitData.TrainingPointsUsed.HasValue && unitData.TrainingPointsTotal.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_TRAINING_POINTS_TOTAL, unitData.TrainingPointsUsed.Value, 0);
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_TRAINING_POINTS_TOTAL, unitData.TrainingPointsTotal.Value, 1);
			}
			for (int num4 = 0; num4 < 5; num4++)
			{
				int startIndex11 = 127;
				if (unitData.Stats[num4].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex11 + num4, unitData.Stats[num4].Value, 0);
				}
			}
			for (int num5 = 0; num5 < 5; num5++)
			{
				int startIndex12 = 132;
				if (unitData.StatPosBuff[num5].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex12 + num5, unitData.StatPosBuff[num5].Value, 0);
				}
			}
			for (int num6 = 0; num6 < 5; num6++)
			{
				int startIndex13 = 137;
				if (unitData.StatNegBuff[num6].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex13 + num6, unitData.StatNegBuff[num6].Value, 0);
				}
			}
			for (int num7 = 0; num7 < 7; num7++)
			{
				int startIndex14 = 142;
				if (unitData.Resistances[num7].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex14 + num7, unitData.Resistances[num7].Value, 0);
				}
			}
			for (int num8 = 0; num8 < 7; num8++)
			{
				int startIndex15 = 149;
				if (unitData.ResistanceBuffModsPositive[num8].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex15 + num8, unitData.ResistanceBuffModsPositive[num8].Value, 0);
				}
			}
			for (int num9 = 0; num9 < 7; num9++)
			{
				int startIndex16 = 156;
				if (unitData.ResistanceBuffModsNegative[num9].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex16 + num9, unitData.ResistanceBuffModsNegative[num9].Value, 0);
				}
			}
			if (unitData.BaseMana.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BASE_MANA, unitData.BaseMana.Value, 0);
			}
			if (unitData.BaseHealth.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BASE_HEALTH, unitData.BaseHealth.Value, 0);
			}
			if (unitData.SheatheState.HasValue || unitData.PvpFlags.HasValue || unitData.PetFlags.HasValue || unitData.ShapeshiftForm.HasValue)
			{
				if (unitData.SheatheState.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_2, unitData.SheatheState.Value, 0);
				}
				if (unitData.PvpFlags.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_2, unitData.PvpFlags.Value, 1);
				}
				if (unitData.PetFlags.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_2, unitData.PetFlags.Value, 2);
				}
				if (unitData.ShapeshiftForm.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BYTES_2, unitData.ShapeshiftForm.Value, 3);
				}
			}
			if (unitData.AttackPower.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_ATTACK_POWER, unitData.AttackPower.Value, 0);
			}
			if (unitData.AttackPowerModPos.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_ATTACK_POWER_MOD_POS, unitData.AttackPowerModPos.Value, 0);
			}
			if (unitData.AttackPowerModNeg.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_ATTACK_POWER_MOD_NEG, unitData.AttackPowerModNeg.Value, 0);
			}
			if (unitData.AttackPowerMultiplier.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_ATTACK_POWER_MULTIPLIER, unitData.AttackPowerMultiplier.Value, 0);
			}
			if (unitData.RangedAttackPower.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_RANGED_ATTACK_POWER, unitData.RangedAttackPower.Value, 0);
			}
			if (unitData.RangedAttackPowerModPos.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_RANGED_ATTACK_POWER_MOD_POS, unitData.RangedAttackPowerModPos.Value, 0);
			}
			if (unitData.RangedAttackPowerModNeg.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_RANGED_ATTACK_POWER_MOD_NEG, unitData.RangedAttackPowerModNeg.Value, 0);
			}
			if (unitData.RangedAttackPowerMultiplier.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER, unitData.RangedAttackPowerMultiplier.Value, 0);
			}
			if (unitData.AttackSpeedAura.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_ATTACK_SPEED_AURA, unitData.AttackSpeedAura.Value, 0);
			}
			if (unitData.Lifesteal.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_LIFESTEAL, unitData.Lifesteal.Value, 0);
			}
			if (unitData.MinRangedDamage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MINRANGEDDAMAGE, unitData.MinRangedDamage.Value, 0);
			}
			if (unitData.MaxRangedDamage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MAXRANGEDDAMAGE, unitData.MaxRangedDamage.Value, 0);
			}
			for (int num10 = 0; num10 < 7; num10++)
			{
				int startIndex17 = 178;
				if (unitData.PowerCostModifier[num10].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex17 + num10, unitData.PowerCostModifier[num10].Value, 0);
				}
			}
			for (int num11 = 0; num11 < 7; num11++)
			{
				int startIndex18 = 185;
				if (unitData.PowerCostMultiplier[num11].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex18 + num11, unitData.PowerCostMultiplier[num11].Value, 0);
				}
			}
			if (unitData.MaxHealthModifier.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MAXHEALTHMODIFIER, unitData.MaxHealthModifier.Value, 0);
			}
			if (unitData.HoverHeight.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_HOVERHEIGHT, unitData.HoverHeight.Value, 0);
			}
			if (unitData.MinItemLevelCutoff.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MIN_ITEM_LEVEL_CUTOFF, unitData.MinItemLevelCutoff.Value, 0);
			}
			if (unitData.MinItemLevel.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MIN_ITEM_LEVEL, unitData.MinItemLevel.Value, 0);
			}
			if (unitData.MaxItemLevel.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_MAXITEMLEVEL, unitData.MaxItemLevel.Value, 0);
			}
			if (unitData.WildBattlePetLevel.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_WILD_BATTLEPET_LEVEL, unitData.WildBattlePetLevel.Value, 0);
			}
			if (unitData.BattlePetCompanionNameTimestamp.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_BATTLEPET_COMPANION_NAME_TIMESTAMP, unitData.BattlePetCompanionNameTimestamp.Value, 0);
			}
			if (unitData.InteractSpellID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_INTERACT_SPELLID, unitData.InteractSpellID.Value, 0);
			}
			if (unitData.StateSpellVisualID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_STATE_SPELL_VISUAL_ID, unitData.StateSpellVisualID.Value, 0);
			}
			if (unitData.StateAnimID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_STATE_ANIM_ID, unitData.StateAnimID.Value, 0);
			}
			if (unitData.StateAnimKitID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_STATE_ANIM_KIT_ID, unitData.StateAnimKitID.Value, 0);
			}
			if (unitData.StateWorldEffectsID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_STATE_WORLD_EFFECT_ID, unitData.StateWorldEffectsID.Value, 0);
			}
			if (unitData.ScaleDuration.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_SCALE_DURATION, unitData.ScaleDuration.Value, 0);
			}
			if (unitData.LooksLikeMountID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_LOOKS_LIKE_MOUNT_ID, unitData.LooksLikeMountID.Value, 0);
			}
			if (unitData.LooksLikeCreatureID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_LOOKS_LIKE_CREATURE_ID, unitData.LooksLikeCreatureID.Value, 0);
			}
			if (unitData.LookAtControllerID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_LOOK_AT_CONTROLLER_ID, unitData.LookAtControllerID.Value, 0);
			}
			if (unitData.GuildGUID != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitField.UNIT_FIELD_GUILD_GUID, unitData.GuildGUID, 0);
			}
			if (unitData.ChannelObject != null)
			{
				this.m_dynamicFields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.UnitDynamicField.UNIT_DYNAMIC_FIELD_CHANNEL_OBJECTS, unitData.ChannelObject, DynamicFieldChangeType.ValueAndSizeChanged);
			}
		}
		PlayerData playerData = this.m_updateData.PlayerData;
		if (playerData != null)
		{
			if (playerData.DuelArbiter != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_DUEL_ARBITER, playerData.DuelArbiter, 0);
			}
			if (playerData.WowAccount != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_WOW_ACCOUNT, playerData.WowAccount, 0);
			}
			if (playerData.LootTargetGUID != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_LOOT_TARGET_GUID, playerData.LootTargetGUID, 0);
			}
			if (playerData.PlayerFlags.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_FLAGS, playerData.PlayerFlags.Value, 0);
			}
			if (playerData.PlayerFlagsEx.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_FLAGS_EX, playerData.PlayerFlagsEx.Value, 0);
			}
			if (playerData.GuildRankID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_GUILDRANK, playerData.GuildRankID.Value, 0);
			}
			if (playerData.GuildDeleteDate.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_GUILDDELETE_DATE, playerData.GuildDeleteDate.Value, 0);
			}
			if (playerData.GuildLevel.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_GUILDLEVEL, playerData.GuildLevel.Value, 0);
			}
			if (playerData.PartyType.HasValue || playerData.NumBankSlots.HasValue || playerData.NativeSex.HasValue || playerData.Inebriation.HasValue)
			{
				if (playerData.PartyType.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_BYTES, playerData.PartyType.Value, 0);
				}
				if (playerData.NumBankSlots.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_BYTES, playerData.NumBankSlots.Value, 1);
				}
				if (playerData.NativeSex.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_BYTES, playerData.NativeSex.Value, 2);
				}
				if (playerData.Inebriation.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_BYTES, playerData.Inebriation.Value, 3);
				}
			}
			if (playerData.PvpTitle.HasValue || playerData.ArenaFaction.HasValue || playerData.PvPRank.HasValue)
			{
				if (playerData.PvpTitle.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_BYTES_2, playerData.PvpTitle.Value, 0);
				}
				if (playerData.ArenaFaction.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_BYTES_2, playerData.ArenaFaction.Value, 1);
				}
				if (playerData.PvPRank.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_BYTES_2, playerData.PvPRank.Value, 2);
				}
			}
			if (playerData.DuelTeam.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_DUEL_TEAM, playerData.DuelTeam.Value, 0);
			}
			if (playerData.GuildTimeStamp.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_GUILD_TIMESTAMP, playerData.GuildTimeStamp.Value, 0);
			}
			for (int num12 = 0; num12 < 25; num12++)
			{
				int startIndex19 = 236;
				int sizePerEntry4 = 16;
				if (playerData.QuestLog[num12] == null)
				{
					continue;
				}
				if (playerData.QuestLog[num12].QuestID.HasValue)
				{
					this.m_fields.SetUpdateField(startIndex19 + num12 * sizePerEntry4, playerData.QuestLog[num12].QuestID.Value, 0);
				}
				if (playerData.QuestLog[num12].StateFlags.HasValue)
				{
					this.m_fields.SetUpdateField(startIndex19 + num12 * sizePerEntry4 + 1, playerData.QuestLog[num12].StateFlags.Value, 0);
				}
				for (int num13 = 0; num13 < 24; num13++)
				{
					if (playerData.QuestLog[num12].ObjectiveProgress[num13].HasValue)
					{
						this.m_fields.SetUpdateField(startIndex19 + num12 * sizePerEntry4 + 2 + num13 / 2, (ushort)playerData.QuestLog[num12].ObjectiveProgress[num13].Value, (byte)(num13 & 1));
					}
				}
				if (playerData.QuestLog[num12].EndTime.HasValue)
				{
					this.m_fields.SetUpdateField(startIndex19 + num12 * sizePerEntry4 + 2 + 12, playerData.QuestLog[num12].EndTime.Value, 0);
				}
				if (playerData.QuestLog[num12].AcceptTime.HasValue)
				{
					this.m_fields.SetUpdateField(startIndex19 + num12 * sizePerEntry4 + 3 + 12, playerData.QuestLog[num12].AcceptTime.Value, 0);
				}
			}
			for (int num14 = 0; num14 < 19; num14++)
			{
				int startIndex20 = 636;
				int sizePerEntry5 = 2;
				if (playerData.VisibleItems[num14] != null)
				{
					this.m_fields.SetUpdateField(startIndex20 + num14 * sizePerEntry5, playerData.VisibleItems[num14].ItemID, 0);
					this.m_fields.SetUpdateField(startIndex20 + num14 * sizePerEntry5 + 1, playerData.VisibleItems[num14].ItemAppearanceModID, 0);
					this.m_fields.SetUpdateField(startIndex20 + num14 * sizePerEntry5 + 1, playerData.VisibleItems[num14].ItemVisual, 1);
				}
			}
			if (playerData.ChosenTitle.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_CHOSEN_TITLE, playerData.ChosenTitle.Value, 0);
			}
			if (playerData.FakeInebriation.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_FAKE_INEBRIATION, playerData.FakeInebriation.Value, 0);
			}
			if (playerData.VirtualPlayerRealm.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_FIELD_VIRTUAL_PLAYER_REALM, playerData.VirtualPlayerRealm.Value, 0);
			}
			if (playerData.CurrentSpecID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_FIELD_CURRENT_SPEC_ID, playerData.CurrentSpecID.Value, 0);
			}
			if (playerData.TaxiMountAnimKitID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_FIELD_TAXI_MOUNT_ANIM_KIT_ID, playerData.TaxiMountAnimKitID.Value, 0);
			}
			for (int num15 = 0; num15 < 6; num15++)
			{
				int startIndex21 = 679;
				if (playerData.AvgItemLevel[num15].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex21 + num15, playerData.AvgItemLevel[num15].Value, 0);
				}
			}
			if (playerData.CurrentBattlePetBreedQuality.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_FIELD_CURRENT_BATTLE_PET_BREED_QUALITY, playerData.CurrentBattlePetBreedQuality.Value, 0);
			}
			if (playerData.HonorLevel.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.PlayerField.PLAYER_FIELD_HONOR_LEVEL, playerData.HonorLevel.Value, 0);
			}
			for (int num16 = 0; num16 < 36; num16++)
			{
				int startIndex22 = 687;
				int sizePerEntry6 = 2;
				if (playerData.Customizations[num16] != null)
				{
					this.m_fields.SetUpdateField(startIndex22 + num16 * sizePerEntry6, playerData.Customizations[num16].ChrCustomizationOptionID, 0);
					this.m_fields.SetUpdateField(startIndex22 + num16 * sizePerEntry6 + 1, playerData.Customizations[num16].ChrCustomizationChoiceID, 0);
				}
			}
		}
		ActivePlayerData activeData = this.m_updateData.ActivePlayerData;
		if (activeData != null && this.m_objectType == ObjectTypeBCC.ActivePlayer)
		{
			for (int num17 = 0; num17 < 23; num17++)
			{
				int startIndex23 = 759;
				int sizePerEntry7 = 4;
				if (activeData.InvSlots[num17] != null)
				{
					this.m_fields.SetUpdateField(startIndex23 + num17 * sizePerEntry7, activeData.InvSlots[num17], 0);
				}
			}
			for (int num18 = 0; num18 < 24; num18++)
			{
				int startIndex24 = 851;
				int sizePerEntry8 = 4;
				if (activeData.PackSlots[num18] != null)
				{
					this.m_fields.SetUpdateField(startIndex24 + num18 * sizePerEntry8, activeData.PackSlots[num18], 0);
				}
			}
			for (int num19 = 0; num19 < 28; num19++)
			{
				int startIndex25 = 947;
				int sizePerEntry9 = 4;
				if (activeData.BankSlots[num19] != null)
				{
					this.m_fields.SetUpdateField(startIndex25 + num19 * sizePerEntry9, activeData.BankSlots[num19], 0);
				}
			}
			for (int num20 = 0; num20 < 7; num20++)
			{
				int startIndex26 = 1059;
				int sizePerEntry10 = 4;
				if (activeData.BankBagSlots[num20] != null)
				{
					this.m_fields.SetUpdateField(startIndex26 + num20 * sizePerEntry10, activeData.BankBagSlots[num20], 0);
				}
			}
			for (int num21 = 0; num21 < 12; num21++)
			{
				int startIndex27 = 1087;
				int sizePerEntry11 = 4;
				if (activeData.BuyBackSlots[num21] != null)
				{
					this.m_fields.SetUpdateField(startIndex27 + num21 * sizePerEntry11, activeData.BuyBackSlots[num21], 0);
				}
			}
			for (int num22 = 0; num22 < 32; num22++)
			{
				int startIndex28 = 1135;
				int sizePerEntry12 = 4;
				if (activeData.KeyringSlots[num22] != null)
				{
					this.m_fields.SetUpdateField(startIndex28 + num22 * sizePerEntry12, activeData.KeyringSlots[num22], 0);
				}
			}
			if (activeData.FarsightObject != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_FARSIGHT, activeData.FarsightObject, 0);
			}
			if (activeData.ComboTarget != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_COMBO_TARGET, activeData.ComboTarget, 0);
			}
			if (activeData.SummonedBattlePetGUID != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_SUMMONED_BATTLE_PET_ID, activeData.SummonedBattlePetGUID, 0);
			}
			for (int num23 = 0; num23 < 12; num23++)
			{
				int startIndex29 = 1287;
				if (activeData.KnownTitles[num23].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex29 + num23, activeData.KnownTitles[num23].Value, 0);
				}
			}
			if (activeData.Coinage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_COINAGE, activeData.Coinage.Value, 0);
			}
			if (activeData.XP.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_XP, activeData.XP.Value, 0);
			}
			if (activeData.NextLevelXP.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_NEXT_LEVEL_XP, activeData.NextLevelXP.Value, 0);
			}
			if (activeData.TrialXP.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_TRIAL_XP, activeData.TrialXP.Value, 0);
			}
			for (int num24 = 0; num24 < 256; num24++)
			{
				if (activeData.Skill.SkillLineID[num24].HasValue)
				{
					int startIndex30 = 1304;
					this.m_fields.SetUpdateField(startIndex30 + num24 / 2, activeData.Skill.SkillLineID[num24].Value, (byte)(num24 & 1));
				}
				if (activeData.Skill.SkillStep[num24].HasValue)
				{
					int startIndex31 = 1432;
					this.m_fields.SetUpdateField(startIndex31 + num24 / 2, activeData.Skill.SkillStep[num24].Value, (byte)(num24 & 1));
				}
				if (activeData.Skill.SkillRank[num24].HasValue)
				{
					int startIndex32 = 1560;
					this.m_fields.SetUpdateField(startIndex32 + num24 / 2, activeData.Skill.SkillRank[num24].Value, (byte)(num24 & 1));
				}
				if (activeData.Skill.SkillStartingRank[num24].HasValue)
				{
					int startIndex33 = 1688;
					this.m_fields.SetUpdateField(startIndex33 + num24 / 2, activeData.Skill.SkillStartingRank[num24].Value, (byte)(num24 & 1));
				}
				if (activeData.Skill.SkillMaxRank[num24].HasValue)
				{
					int startIndex34 = 1816;
					this.m_fields.SetUpdateField(startIndex34 + num24 / 2, activeData.Skill.SkillMaxRank[num24].Value, (byte)(num24 & 1));
				}
				if (activeData.Skill.SkillTempBonus[num24].HasValue)
				{
					int startIndex35 = 1944;
					this.m_fields.SetUpdateField(startIndex35 + num24 / 2, (ushort)activeData.Skill.SkillTempBonus[num24].Value, (byte)(num24 & 1));
				}
				if (activeData.Skill.SkillPermBonus[num24].HasValue)
				{
					int startIndex36 = 2072;
					this.m_fields.SetUpdateField(startIndex36 + num24 / 2, activeData.Skill.SkillPermBonus[num24].Value, (byte)(num24 & 1));
				}
			}
			if (activeData.CharacterPoints.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_CHARACTER_POINTS, activeData.CharacterPoints.Value, 0);
			}
			if (activeData.MaxTalentTiers.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MAX_TALENT_TIERS, activeData.MaxTalentTiers.Value, 0);
			}
			if (activeData.TrackCreatureMask.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_TRACK_CREATURES, activeData.TrackCreatureMask.Value, 0);
			}
			for (int num25 = 0; num25 < 2; num25++)
			{
				int startIndex37 = 2203;
				if (activeData.TrackResourceMask[num25].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex37 + num25, activeData.TrackResourceMask[num25].Value, 0);
				}
			}
			if (activeData.MainhandExpertise.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_EXPERTISE, activeData.MainhandExpertise.Value, 0);
			}
			if (activeData.OffhandExpertise.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_OFFHAND_EXPERTISE, activeData.OffhandExpertise.Value, 0);
			}
			if (activeData.RangedExpertise.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_RANGED_EXPERTISE, activeData.RangedExpertise.Value, 0);
			}
			if (activeData.CombatRatingExpertise.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_COMBAT_RATING_EXPERTISE, activeData.CombatRatingExpertise.Value, 0);
			}
			if (activeData.BlockPercentage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BLOCK_PERCENTAGE, activeData.BlockPercentage.Value, 0);
			}
			if (activeData.DodgePercentage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_DODGE_PERCENTAGE, activeData.DodgePercentage.Value, 0);
			}
			if (activeData.DodgePercentageFromAttribute.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_DODGE_PERCENTAGE_FROM_ATTRIBUTE, activeData.DodgePercentageFromAttribute.Value, 0);
			}
			if (activeData.ParryPercentage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_PARRY_PERCENTAGE, activeData.ParryPercentage.Value, 0);
			}
			if (activeData.ParryPercentageFromAttribute.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_PARRY_PERCENTAGE_FROM_ATTRIBUTE, activeData.ParryPercentageFromAttribute.Value, 0);
			}
			if (activeData.CritPercentage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_CRIT_PERCENTAGE, activeData.CritPercentage.Value, 0);
			}
			if (activeData.RangedCritPercentage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_RANGED_CRIT_PERCENTAGE, activeData.RangedCritPercentage.Value, 0);
			}
			if (activeData.OffhandCritPercentage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_OFFHAND_CRIT_PERCENTAGE, activeData.OffhandCritPercentage.Value, 0);
			}
			for (int num26 = 0; num26 < 7; num26++)
			{
				int startIndex38 = 2217;
				if (activeData.SpellCritPercentage[num26].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex38 + num26, activeData.SpellCritPercentage[num26].Value, 0);
				}
			}
			if (activeData.ShieldBlock.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_SHIELD_BLOCK, activeData.ShieldBlock.Value, 0);
			}
			if (activeData.Mastery.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MASTERY, activeData.Mastery.Value, 0);
			}
			if (activeData.Speed.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_SPEED, activeData.Speed.Value, 0);
			}
			if (activeData.Avoidance.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_AVOIDANCE, activeData.Avoidance.Value, 0);
			}
			if (activeData.Sturdiness.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_STURDINESS, activeData.Sturdiness.Value, 0);
			}
			if (activeData.Versatility.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_VERSATILITY, activeData.Versatility.Value, 0);
			}
			if (activeData.VersatilityBonus.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_VERSATILITY_BONUS, activeData.VersatilityBonus.Value, 0);
			}
			if (activeData.PvpPowerDamage.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_PVP_POWER_DAMAGE, activeData.PvpPowerDamage.Value, 0);
			}
			if (activeData.PvpPowerHealing.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_PVP_POWER_HEALING, activeData.PvpPowerHealing.Value, 0);
			}
			for (int num27 = 0; num27 < 240; num27++)
			{
				int startIndex39 = 2233;
				if (activeData.ExploredZones[num27].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex39 + num27 * 2, activeData.ExploredZones[num27].Value, 0);
				}
			}
			for (int num28 = 0; num28 < 2; num28++)
			{
				int startIndex40 = 2713;
				int sizePerEntry13 = 2;
				if (activeData.RestInfo[num28] != null)
				{
					if (activeData.RestInfo[num28].StateID.HasValue)
					{
						this.m_fields.SetUpdateField(startIndex40 + num28 * sizePerEntry13, activeData.RestInfo[num28].StateID.Value, 0);
					}
					if (activeData.RestInfo[num28].Threshold.HasValue)
					{
						this.m_fields.SetUpdateField(startIndex40 + num28 * sizePerEntry13 + 1, activeData.RestInfo[num28].Threshold.Value, 0);
					}
				}
			}
			for (int num29 = 0; num29 < 7; num29++)
			{
				int startIndex41 = 2717;
				if (activeData.ModDamageDonePos[num29].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex41 + num29, activeData.ModDamageDonePos[num29].Value, 0);
				}
			}
			for (int num30 = 0; num30 < 7; num30++)
			{
				int startIndex42 = 2724;
				if (activeData.ModDamageDoneNeg[num30].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex42 + num30, activeData.ModDamageDoneNeg[num30].Value, 0);
				}
			}
			for (int num31 = 0; num31 < 7; num31++)
			{
				int startIndex43 = 2731;
				if (activeData.ModDamageDonePercent[num31].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex43 + num31, activeData.ModDamageDonePercent[num31].Value, 0);
				}
			}
			if (activeData.ModHealingDonePos.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MOD_HEALING_DONE_POS, activeData.ModHealingDonePos.Value, 0);
			}
			if (activeData.ModHealingPercent.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MOD_HEALING_PCT, activeData.ModHealingPercent.Value, 0);
			}
			if (activeData.ModHealingDonePercent.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MOD_HEALING_DONE_PCT, activeData.ModHealingDonePercent.Value, 0);
			}
			if (activeData.ModPeriodicHealingDonePercent.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MOD_PERIODIC_HEALING_DONE_PERCENT, activeData.ModPeriodicHealingDonePercent.Value, 0);
			}
			for (int num32 = 0; num32 < 3; num32++)
			{
				int startIndex44 = 2742;
				if (activeData.WeaponDmgMultipliers[num32].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex44 + num32, activeData.WeaponDmgMultipliers[num32].Value, 0);
				}
			}
			for (int num33 = 0; num33 < 3; num33++)
			{
				int startIndex45 = 2745;
				if (activeData.WeaponAtkSpeedMultipliers[num33].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex45 + num33, activeData.WeaponAtkSpeedMultipliers[num33].Value, 0);
				}
			}
			if (activeData.ModSpellPowerPercent.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MOD_SPELL_POWER_PCT, activeData.ModSpellPowerPercent.Value, 0);
			}
			if (activeData.ModResiliencePercent.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MOD_RESILIENCE_PERCENT, activeData.ModResiliencePercent.Value, 0);
			}
			if (activeData.OverrideSpellPowerByAPPercent.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_OVERRIDE_SPELL_POWER_BY_AP_PCT, activeData.OverrideSpellPowerByAPPercent.Value, 0);
			}
			if (activeData.OverrideAPBySpellPowerPercent.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_OVERRIDE_AP_BY_SPELL_POWER_PERCENT, activeData.OverrideAPBySpellPowerPercent.Value, 0);
			}
			if (activeData.ModTargetResistance.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MOD_TARGET_RESISTANCE, activeData.ModTargetResistance.Value, 0);
			}
			if (activeData.ModTargetPhysicalResistance.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MOD_TARGET_PHYSICAL_RESISTANCE, activeData.ModTargetPhysicalResistance.Value, 0);
			}
			if (activeData.LocalFlags.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_LOCAL_FLAGS, activeData.LocalFlags.Value, 0);
			}
			if (activeData.GrantableLevels.HasValue || activeData.MultiActionBars.HasValue || activeData.LifetimeMaxRank.HasValue || activeData.NumRespecs.HasValue)
			{
				if (activeData.GrantableLevels.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES, activeData.GrantableLevels.Value, 0);
				}
				if (activeData.MultiActionBars.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES, activeData.MultiActionBars.Value, 1);
				}
				if (activeData.LifetimeMaxRank.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES, activeData.LifetimeMaxRank.Value, 2);
				}
				if (activeData.NumRespecs.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES, activeData.NumRespecs.Value, 3);
				}
			}
			if (activeData.AmmoID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_AMMO_ID, activeData.AmmoID.Value, 0);
			}
			if (activeData.PvpMedals.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_PVP_MEDALS, activeData.PvpMedals.Value, 0);
			}
			for (int num34 = 0; num34 < 12; num34++)
			{
				int startIndex46 = 2758;
				if (activeData.BuybackPrice[num34].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex46 + num34, activeData.BuybackPrice[num34].Value, 0);
				}
			}
			for (int num35 = 0; num35 < 12; num35++)
			{
				int startIndex47 = 2770;
				if (activeData.BuybackTimestamp[num35].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex47 + num35, activeData.BuybackTimestamp[num35].Value, 0);
				}
			}
			if (activeData.TodayHonorableKills.HasValue && activeData.YesterdayHonorableKills.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES_2, activeData.TodayHonorableKills.Value, 0);
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES_2, activeData.YesterdayHonorableKills.Value, 1);
			}
			if (activeData.LastWeekHonorableKills.HasValue && activeData.ThisWeekHonorableKills.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES_3, activeData.LastWeekHonorableKills.Value, 0);
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES_3, activeData.ThisWeekHonorableKills.Value, 1);
			}
			if (activeData.ThisWeekContribution.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_THIS_WEEK_CONTRIBUTION, activeData.ThisWeekContribution.Value, 0);
			}
			if (activeData.LifetimeHonorableKills.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_LIFETIME_HONORABLE_KILLS, activeData.LifetimeHonorableKills.Value, 0);
			}
			if (activeData.YesterdayContribution.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_YESTERDAY_CONTRIBUTION, activeData.YesterdayContribution.Value, 0);
			}
			if (activeData.LastWeekContribution.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_LAST_WEEK_CONTRIBUTION, activeData.LastWeekContribution.Value, 0);
			}
			if (activeData.LastWeekRank.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_LAST_WEEK_RANK, activeData.LastWeekRank.Value, 0);
			}
			if (activeData.WatchedFactionIndex.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_WATCHED_FACTION_INDEX, activeData.WatchedFactionIndex.Value, 0);
			}
			for (int num36 = 0; num36 < 32; num36++)
			{
				int startIndex48 = 2790;
				if (activeData.CombatRatings[num36].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex48 + num36, activeData.CombatRatings[num36].Value, 0);
				}
			}
			for (int num37 = 0; num37 < 6; num37++)
			{
				int startIndex49 = 2822;
				int sizePerEntry14 = 12;
				if (activeData.PvpInfo[num37] != null)
				{
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14, activeData.PvpInfo[num37].WeeklyPlayed, 0);
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14 + 1, activeData.PvpInfo[num37].WeeklyWon, 0);
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14 + 2, activeData.PvpInfo[num37].SeasonPlayed, 0);
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14 + 3, activeData.PvpInfo[num37].SeasonWon, 0);
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14 + 4, activeData.PvpInfo[num37].Rating, 0);
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14 + 5, activeData.PvpInfo[num37].WeeklyBestRating, 0);
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14 + 6, activeData.PvpInfo[num37].SeasonBestRating, 0);
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14 + 7, activeData.PvpInfo[num37].PvpTierID, 0);
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14 + 8, activeData.PvpInfo[num37].WeeklyBestWinPvpTierID, 0);
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14 + 9, activeData.PvpInfo[num37].Field_28, 0);
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14 + 10, activeData.PvpInfo[num37].Field_2C, 0);
					this.m_fields.SetUpdateField(startIndex49 + num37 * sizePerEntry14 + 11, activeData.PvpInfo[num37].Disqualified ? 1u : 0u, 0);
				}
			}
			if (activeData.MaxLevel.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MAX_LEVEL, activeData.MaxLevel.Value, 0);
			}
			if (activeData.ScalingPlayerLevelDelta.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_SCALING_PLAYER_LEVEL_DELTA, activeData.ScalingPlayerLevelDelta.Value, 0);
			}
			if (activeData.MaxCreatureScalingLevel.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MAX_CREATURE_SCALING_LEVEL, activeData.MaxCreatureScalingLevel.Value, 0);
			}
			for (int num38 = 0; num38 < 4; num38++)
			{
				int startIndex50 = 2897;
				if (activeData.NoReagentCostMask[num38].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex50 + num38, activeData.NoReagentCostMask[num38].Value, 0);
				}
			}
			if (activeData.PetSpellPower.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_PET_SPELL_POWER, activeData.PetSpellPower.Value, 0);
			}
			for (int num39 = 0; num39 < 2; num39++)
			{
				int startIndex51 = 2902;
				if (activeData.ProfessionSkillLine[num39].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex51 + num39, activeData.ProfessionSkillLine[num39].Value, 0);
				}
			}
			if (activeData.UiHitModifier.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_UI_HIT_MODIFIER, activeData.UiHitModifier.Value, 0);
			}
			if (activeData.UiSpellHitModifier.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_UI_SPELL_HIT_MODIFIER, activeData.UiSpellHitModifier.Value, 0);
			}
			if (activeData.HomeRealmTimeOffset.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_HOME_REALM_TIME_OFFSET, activeData.HomeRealmTimeOffset.Value, 0);
			}
			if (activeData.ModPetHaste.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_MOD_PET_HASTE, activeData.ModPetHaste.Value, 0);
			}
			if (activeData.LocalRegenFlags.HasValue || activeData.AuraVision.HasValue || activeData.NumBackpackSlots.HasValue)
			{
				if (activeData.LocalRegenFlags.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES_4, activeData.LocalRegenFlags.Value, 0);
				}
				if (activeData.AuraVision.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES_4, activeData.AuraVision.Value, 1);
				}
				if (activeData.NumBackpackSlots.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES_4, activeData.NumBackpackSlots.Value, 2);
				}
			}
			if (activeData.OverrideSpellsID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_OVERRIDE_SPELLS_ID, activeData.OverrideSpellsID.Value, 0);
			}
			if (activeData.LfgBonusFactionID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_LFG_BONUS_FACTION_ID, activeData.LfgBonusFactionID.Value, 0);
			}
			if (activeData.LootSpecID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_LOOT_SPEC_ID, activeData.LootSpecID.Value, 0);
			}
			if (activeData.OverrideZonePVPType.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_OVERRIDE_ZONE_PVP_TYPE, activeData.OverrideZonePVPType.Value, 0);
			}
			for (int num40 = 0; num40 < 4; num40++)
			{
				int startIndex52 = 2913;
				if (activeData.BagSlotFlags[num40].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex52 + num40, activeData.BagSlotFlags[num40].Value, 0);
				}
			}
			for (int num41 = 0; num41 < 7; num41++)
			{
				int startIndex53 = 2917;
				if (activeData.BankBagSlotFlags[num41].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex53 + num41, activeData.BankBagSlotFlags[num41].Value, 0);
				}
			}
			for (int num42 = 0; num42 < 875; num42++)
			{
				int startIndex54 = 2924;
				if (activeData.QuestCompleted[num42].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex54 + num42 * 2, activeData.QuestCompleted[num42].Value, 0);
				}
			}
			if (activeData.Honor.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_HONOR, activeData.Honor.Value, 0);
			}
			if (activeData.HonorNextLevel.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_HONOR_NEXT_LEVEL, activeData.HonorNextLevel.Value, 0);
			}
			if (activeData.PvPTierMaxFromWins.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_PVP_TIER_MAX_FROM_WINS, activeData.PvPTierMaxFromWins.Value, 0);
			}
			if (activeData.PvPLastWeeksTierMaxFromWins.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_PVP_LAST_WEEKS_TIER_MAX_FROM_WINS, activeData.PvPLastWeeksTierMaxFromWins.Value, 0);
			}
			if (activeData.InsertItemsLeftToRight.HasValue || activeData.PvPRankProgress.HasValue)
			{
				if (activeData.InsertItemsLeftToRight.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES_5, (byte)((activeData.InsertItemsLeftToRight == true) ? 1u : 0u), 0);
				}
				if (activeData.PvPRankProgress.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.ActivePlayerField.ACTIVE_PLAYER_FIELD_BYTES_5, activeData.PvPRankProgress.Value, 1);
				}
			}
			if (activeData.SelfResSpells != null)
			{
				uint[] fields2 = new uint[activeData.SelfResSpells.Count];
				for (int num43 = 0; num43 < activeData.SelfResSpells.Count; num43++)
				{
					fields2[num43] = activeData.SelfResSpells[num43];
				}
				this.m_dynamicFields.SetUpdateField(14, fields2, DynamicFieldChangeType.ValueAndSizeChanged);
			}
			if (activeData.HasDailyQuestsUpdate)
			{
				uint[] fields3 = new uint[this.m_gameState.DailyQuestsDone.Count];
				int counter = 0;
				foreach (KeyValuePair<uint, uint> itr in this.m_gameState.DailyQuestsDone)
				{
					fields3[counter++] = itr.Value;
				}
				this.m_dynamicFields.SetUpdateField(7, fields3, DynamicFieldChangeType.ValueAndSizeChanged);
			}
		}
		GameObjectData goData = this.m_updateData.GameObjectData;
		if (goData != null)
		{
			if (goData.CreatedBy != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_FIELD_CREATED_BY, goData.CreatedBy, 0);
			}
			if (goData.DisplayID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_DISPLAYID, goData.DisplayID.Value, 0);
			}
			if (goData.Flags.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_FLAGS, goData.Flags.Value, 0);
			}
			for (int num44 = 0; num44 < 4; num44++)
			{
				int startIndex55 = 17;
				if (goData.ParentRotation[num44].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex55 + num44, goData.ParentRotation[num44].Value, 0);
				}
			}
			if (goData.FactionTemplate.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_FACTION, goData.FactionTemplate.Value, 0);
			}
			if (goData.Level.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_LEVEL, goData.Level.Value, 0);
			}
			if (goData.State.HasValue || goData.TypeID.HasValue || goData.ArtKit.HasValue || goData.PercentHealth.HasValue)
			{
				if (goData.State.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_BYTES_1, (byte)goData.State.Value, 0);
				}
				if (goData.TypeID.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_BYTES_1, (byte)goData.TypeID.Value, 1);
				}
				if (goData.ArtKit.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_BYTES_1, goData.ArtKit.Value, 2);
				}
				if (goData.PercentHealth.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_BYTES_1, goData.PercentHealth.Value, 3);
				}
			}
			if (goData.SpellVisualID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_SPELL_VISUAL_ID, goData.SpellVisualID.Value, 0);
			}
			if (goData.StateSpellVisualID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_STATE_SPELL_VISUAL_ID, goData.StateSpellVisualID.Value, 0);
			}
			if (goData.StateAnimID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_STATE_ANIM_ID, goData.StateAnimID.Value, 0);
			}
			if (goData.StateAnimKitID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_STATE_ANIM_KIT_ID, goData.StateAnimKitID.Value, 0);
			}
			for (int num45 = 0; num45 < 4; num45++)
			{
				int startIndex56 = 28;
				if (goData.StateWorldEffectIDs[num45].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex56 + num45, goData.StateWorldEffectIDs[num45].Value, 0);
				}
			}
			if (goData.CustomParam.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.GameObjectField.GAMEOBJECT_FIELD_CUSTOM_PARAM, goData.CustomParam.Value, 0);
			}
		}
		DynamicObjectData dynData = this.m_updateData.DynamicObjectData;
		if (dynData != null)
		{
			if (dynData.Caster != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.DynamicObjectField.DYNAMICOBJECT_CASTER, dynData.Caster, 0);
			}
			if (dynData.Type.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.DynamicObjectField.DYNAMICOBJECT_TYPE, dynData.Type.Value, 0);
			}
			if (dynData.SpellXSpellVisualID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.DynamicObjectField.DYNAMICOBJECT_SPELL_X_SPELL_VISUAL_ID, dynData.SpellXSpellVisualID.Value, 0);
			}
			if (dynData.SpellID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.DynamicObjectField.DYNAMICOBJECT_SPELLID, dynData.SpellID.Value, 0);
			}
			if (dynData.Radius.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.DynamicObjectField.DYNAMICOBJECT_RADIUS, dynData.Radius.Value, 0);
			}
			if (dynData.CastTime.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.DynamicObjectField.DYNAMICOBJECT_CASTTIME, dynData.CastTime.Value, 0);
			}
		}
		CorpseData corpseData = this.m_updateData.CorpseData;
		if (corpseData != null)
		{
			if (corpseData.Owner != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.CorpseField.CORPSE_FIELD_OWNER, corpseData.Owner, 0);
			}
			if (corpseData.PartyGUID != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.CorpseField.CORPSE_FIELD_PARTY_GUID, corpseData.PartyGUID, 0);
			}
			if (corpseData.GuildGUID != null)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.CorpseField.CORPSE_FIELD_GUILD_GUID, corpseData.GuildGUID, 0);
			}
			if (corpseData.DisplayID.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.CorpseField.CORPSE_FIELD_DISPLAY_ID, corpseData.DisplayID.Value, 0);
			}
			for (int num46 = 0; num46 < 19; num46++)
			{
				int startIndex57 = 20;
				if (corpseData.Items[num46].HasValue)
				{
					this.m_fields.SetUpdateField(startIndex57 + num46, corpseData.Items[num46].Value, 0);
				}
			}
			if (corpseData.RaceId.HasValue || corpseData.SexId.HasValue || corpseData.ClassId.HasValue)
			{
				if (corpseData.RaceId.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.CorpseField.CORPSE_FIELD_BYTES_1, corpseData.RaceId.Value, 0);
				}
				if (corpseData.SexId.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.CorpseField.CORPSE_FIELD_BYTES_1, corpseData.SexId.Value, 1);
				}
				if (corpseData.ClassId.HasValue)
				{
					this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.CorpseField.CORPSE_FIELD_BYTES_1, corpseData.ClassId.Value, 2);
				}
			}
			if (corpseData.Flags.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.CorpseField.CORPSE_FIELD_FLAGS, corpseData.Flags.Value, 0);
			}
			if (corpseData.DynamicFlags.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.CorpseField.CORPSE_FIELD_DYNAMIC_FLAGS, corpseData.DynamicFlags.Value, 0);
			}
			if (corpseData.FactionTemplate.HasValue)
			{
				this.m_fields.SetUpdateField(HermesProxy.World.Enums.V2_5_2_39570.CorpseField.CORPSE_FIELD_FACTION_TEMPLATE, corpseData.FactionTemplate.Value, 0);
			}
			for (int num47 = 0; num47 < 36; num47++)
			{
				int startIndex58 = 43;
				int sizePerEntry15 = 2;
				if (corpseData.Customizations[num47] != null)
				{
					this.m_fields.SetUpdateField(startIndex58 + num47 * sizePerEntry15, corpseData.Customizations[num47].ChrCustomizationOptionID, 0);
					this.m_fields.SetUpdateField(startIndex58 + num47 * sizePerEntry15 + 1, corpseData.Customizations[num47].ChrCustomizationChoiceID, 0);
				}
			}
		}
		this.m_alreadyWritten = true;
	}
}
