namespace HermesProxy.World.Server;

public class CurrentPlayerStorage
{
	private readonly GlobalSessionData _globalSession;

	public CompletedQuestTracker CompletedQuests { get; private set; }

	public PlayerSettings Settings { get; private set; }

	public CurrentPlayerStorage(GlobalSessionData globalSession)
	{
		this._globalSession = globalSession;
	}

	public void LoadCurrentPlayer()
	{
		this.CompletedQuests = new CompletedQuestTracker(this._globalSession);
		this.Settings = new PlayerSettings(this._globalSession);
		this.CompletedQuests.Reload();
		this.Settings.Reload();
	}
}
