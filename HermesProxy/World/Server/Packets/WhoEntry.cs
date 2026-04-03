using System;

namespace HermesProxy.World.Server.Packets;

public class WhoEntry
{
	public PlayerGuidLookupData PlayerData = new PlayerGuidLookupData();

	public WowGuid128 GuildGUID = WowGuid128.Empty;

	public uint GuildVirtualRealmAddress;

	public string GuildName = "";

	public int AreaID;

	public bool IsGM;

	public void Write(WorldPacket data)
	{
		this.PlayerData.Write(data);
		data.WritePackedGuid128(this.GuildGUID);
		data.WriteUInt32(this.GuildVirtualRealmAddress);
		data.WriteInt32(this.AreaID);
		data.WriteBits(this.GuildName.GetByteCount(), 7);
		data.WriteBit(this.IsGM);
		data.WriteString(this.GuildName);
		data.FlushBits();
	}
}
