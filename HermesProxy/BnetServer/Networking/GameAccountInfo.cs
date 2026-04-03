using HermesProxy.World;
using HermesProxy.World.Enums;

namespace BNetServer.Networking;

public class GameAccountInfo
{
	public uint Id;

	public string Name;

	public string DisplayName;

	public uint UnbanDate;

	public bool IsBanned;

	public bool IsPermanenetlyBanned;

	public WowGuid128 WoWAccountGuid => WowGuid128.Create(HighGuidType703.WowAccount, this.Id);

	public GameAccountInfo(string name)
	{
		this.Id = 1u;
		this.Name = name;
		this.UnbanDate = 0u;
		this.IsPermanenetlyBanned = false;
		this.IsBanned = this.IsPermanenetlyBanned || this.UnbanDate > Time.UnixTime;
		int hashPos = this.Name.IndexOf('#');
		if (hashPos != -1)
		{
			string name2 = this.Name;
			int num = hashPos + 1;
			this.DisplayName = "WoW" + name2.Substring(num, name2.Length - num);
		}
		else
		{
			this.DisplayName = this.Name;
		}
	}
}
