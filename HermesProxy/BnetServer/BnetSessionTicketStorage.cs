using System.Collections.Generic;
using HermesProxy;

namespace BNetServer;

public static class BnetSessionTicketStorage
{
	public static Dictionary<string, GlobalSessionData> SessionsByName = new Dictionary<string, GlobalSessionData>();

	public static Dictionary<string, GlobalSessionData> SessionsByTicket = new Dictionary<string, GlobalSessionData>();

	public static Dictionary<ulong, GlobalSessionData> SessionsByKey = new Dictionary<ulong, GlobalSessionData>();

	public static void AddNewSessionByName(string name, GlobalSessionData session)
	{
		if (BnetSessionTicketStorage.SessionsByName.ContainsKey(name))
		{
			BnetSessionTicketStorage.SessionsByName[name].OnDisconnect();
			BnetSessionTicketStorage.SessionsByName[name] = session;
		}
		else
		{
			BnetSessionTicketStorage.SessionsByName.Add(name, session);
		}
	}

	public static void AddNewSessionByTicket(string loginTicket, GlobalSessionData session)
	{
		if (BnetSessionTicketStorage.SessionsByTicket.ContainsKey(loginTicket))
		{
			BnetSessionTicketStorage.SessionsByTicket[loginTicket].OnDisconnect();
			BnetSessionTicketStorage.SessionsByTicket[loginTicket] = session;
		}
		else
		{
			BnetSessionTicketStorage.SessionsByTicket.Add(loginTicket, session);
		}
	}

	public static void AddNewSessionByKey(ulong connectKey, GlobalSessionData session)
	{
		if (BnetSessionTicketStorage.SessionsByKey.ContainsKey(connectKey))
		{
			BnetSessionTicketStorage.SessionsByKey[connectKey].OnDisconnect();
			BnetSessionTicketStorage.SessionsByKey[connectKey] = session;
		}
		else
		{
			BnetSessionTicketStorage.SessionsByKey.Add(connectKey, session);
		}
	}
}
