using System.Collections.Generic;
using HermesProxy.World;
using HermesProxy.World.Enums;

namespace BNetServer.Networking;

public class AccountInfo
{
	public uint Id;

	public string Login;

	public uint LoginTicketExpiry;

	public bool IsBanned;

	public bool IsPermanenetlyBanned;

	public Dictionary<uint, GameAccountInfo> GameAccounts;

	public WowGuid128 BnetAccountGuid => WowGuid128.Create(HighGuidType703.BNetAccount, this.Id);

	public AccountInfo(string name)
	{
		this.Id = 1u;
		this.Login = name;
		this.LoginTicketExpiry = (uint)(Time.UnixTime + 10000);
		this.IsBanned = false;
		this.IsPermanenetlyBanned = false;
		this.GameAccounts = new Dictionary<uint, GameAccountInfo>();
		GameAccountInfo account = new GameAccountInfo(name);
		this.GameAccounts[1u] = account;
	}
}
