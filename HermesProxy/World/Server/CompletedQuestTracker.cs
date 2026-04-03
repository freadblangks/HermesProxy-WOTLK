using System.Collections.Generic;
using HermesProxy.World.Enums;
using HermesProxy.World.Server.Packets;

namespace HermesProxy.World.Server;

public class CompletedQuestTracker
{
	private Dictionary<int, ulong> _cachedQuestCompleted = new Dictionary<int, ulong>();

	public GlobalSessionData Session { get; }

	public CompletedQuestTracker(GlobalSessionData globalSession)
	{
		this.Session = globalSession;
	}

	public void MarkQuestAsNotCompleted(uint questQuestId)
	{
		this.Session.AccountMetaDataMgr.MarkQuestAsNotCompleted(this.Session.GameState.CurrentPlayerInfo.Realm.Name, this.Session.GameState.CurrentPlayerInfo.Name, questQuestId);
		uint? questBit = GameData.GetUniqueQuestBit(questQuestId);
		if (questBit.HasValue)
		{
			this.SendSingleUpdateToClient(questBit.Value, isSet: false);
		}
	}

	public void MarkQuestAsCompleted(uint questQuestId)
	{
		this.Session.AccountMetaDataMgr.MarkQuestAsCompleted(this.Session.GameState.CurrentPlayerInfo.Realm.Name, this.Session.GameState.CurrentPlayerInfo.Name, questQuestId);
		uint? questBit = GameData.GetUniqueQuestBit(questQuestId);
		if (questBit.HasValue)
		{
			this.SendSingleUpdateToClient(questBit.Value, isSet: true);
		}
	}

	public void Reload()
	{
		List<uint> questIds = this.Session.AccountMetaDataMgr.GetAllCompletedQuests(this.Session.GameState.CurrentPlayerInfo.Realm.Name, this.Session.GameState.CurrentPlayerInfo.Name);
		this._cachedQuestCompleted = new Dictionary<int, ulong>();
		foreach (uint questId in questIds)
		{
			uint? questBit = GameData.GetUniqueQuestBit(questId);
			if (questBit.HasValue)
			{
				int idx = (int)(questBit - 1 >> 6).Value;
				int bitIdx = (int)((questBit - 1) & 0x3F).Value;
				this._cachedQuestCompleted.TryAdd(idx, 0uL);
				this._cachedQuestCompleted[idx] |= (ulong)(1L << bitIdx);
			}
		}
	}

	private void SendSingleUpdateToClient(uint questBit, bool isSet)
	{
		int idx = (int)(questBit - 1 >> 6);
		int bitIdx = (int)((questBit - 1) & 0x3F);
		this._cachedQuestCompleted.TryAdd(idx, 0uL);
		if (isSet)
		{
			this._cachedQuestCompleted[idx] |= (ulong)(1L << bitIdx);
		}
		else
		{
			this._cachedQuestCompleted[idx] &= (ulong)(~(1L << bitIdx));
		}
		ObjectUpdate updateData = new ObjectUpdate(this.Session.GameState.CurrentPlayerGuid, UpdateTypeModern.Values, this.Session);
		updateData.ActivePlayerData.QuestCompleted[idx] = this._cachedQuestCompleted[idx];
		UpdateObject updatePacket = new UpdateObject(this.Session.GameState);
		updatePacket.ObjectUpdates.Add(updateData);
		this.Session.WorldClient.SendPacketToClient(updatePacket);
	}

	public void WriteAllCompletedIntoArray(ulong?[] dest)
	{
		foreach (KeyValuePair<int, ulong> kv in this._cachedQuestCompleted)
		{
			dest[kv.Key] = kv.Value;
		}
	}
}
