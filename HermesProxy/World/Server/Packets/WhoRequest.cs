using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class WhoRequest
{
	public int MinLevel;

	public int MaxLevel;

	public string Name;

	public string VirtualRealmName;

	public string Guild;

	public string GuildVirtualRealmName;

	public long RaceFilter;

	public int ClassFilter = -1;

	public List<string> Words = new List<string>();

	public bool ShowEnemies;

	public bool ShowArenaPlayers;

	public bool ExactName;

	public WhoRequestServerInfo ServerInfo;

	public void Read(WorldPacket data)
	{
		this.MinLevel = data.ReadInt32();
		this.MaxLevel = data.ReadInt32();
		this.RaceFilter = data.ReadInt64();
		this.ClassFilter = data.ReadInt32();
		uint nameLength = data.ReadBits<uint>(6);
		uint virtualRealmNameLength = data.ReadBits<uint>(9);
		uint guildNameLength = data.ReadBits<uint>(7);
		uint guildVirtualRealmNameLength = data.ReadBits<uint>(9);
		uint wordsCount = data.ReadBits<uint>(3);
		this.ShowEnemies = data.HasBit();
		this.ShowArenaPlayers = data.HasBit();
		this.ExactName = data.HasBit();
		if (data.HasBit())
		{
			this.ServerInfo = new WhoRequestServerInfo();
		}
		data.ResetBitPos();
		for (int i = 0; i < wordsCount; i++)
		{
			this.Words.Add(data.ReadString(data.ReadBits<uint>(7)));
			data.ResetBitPos();
		}
		this.Name = data.ReadString(nameLength);
		this.VirtualRealmName = data.ReadString(virtualRealmNameLength);
		this.Guild = data.ReadString(guildNameLength);
		this.GuildVirtualRealmName = data.ReadString(guildVirtualRealmNameLength);
		if (this.ServerInfo != null)
		{
			this.ServerInfo.Read(data);
		}
	}
}
