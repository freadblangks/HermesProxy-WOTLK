using HermesProxy.World.Enums;

namespace HermesProxy.World.Server;

public class PlayerSettings
{
	public class InternalStorage
	{
		public bool AutoBlockGuildInvites { get; set; }
	}

	private InternalStorage _internalStorage;

	private PlayerFlags _lastCapturedFlags;

	public bool NeedToForcePatchFlags { get; private set; }

	public GlobalSessionData Session { get; }

	public PlayerSettings(GlobalSessionData globalSession)
	{
		this.Session = globalSession;
	}

	public void SetAutoBlockGuildInvites(bool value)
	{
		this._internalStorage.AutoBlockGuildInvites = value;
		this.NeedToForcePatchFlags = true;
		this.Save();
	}

	public void PatchFlags(ref PlayerFlags flags)
	{
		this._lastCapturedFlags = flags;
		this.NeedToForcePatchFlags = false;
		if (this._internalStorage.AutoBlockGuildInvites)
		{
			flags |= PlayerFlags.AutoDeclineGuild;
		}
		else
		{
			flags &= ~PlayerFlags.AutoDeclineGuild;
		}
	}

	public PlayerFlags CreateNewFlags()
	{
		PlayerFlags flags = this._lastCapturedFlags;
		this.PatchFlags(ref flags);
		return flags;
	}

	private void Save()
	{
		this.Session.AccountMetaDataMgr.SaveCharacterSettingsStorage(this.Session.GameState.CurrentPlayerInfo.Realm.Name, this.Session.GameState.CurrentPlayerInfo.Name, this._internalStorage);
	}

	public void Reload()
	{
		this._internalStorage = this.Session.AccountMetaDataMgr.LoadCharacterSettingsStorage(this.Session.GameState.CurrentPlayerInfo.Realm.Name, this.Session.GameState.CurrentPlayerInfo.Name);
	}
}
