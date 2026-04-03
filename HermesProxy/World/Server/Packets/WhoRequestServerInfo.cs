namespace HermesProxy.World.Server.Packets;

public class WhoRequestServerInfo
{
	public int FactionGroup;

	public int Locale;

	public uint RequesterVirtualRealmAddress;

	public void Read(WorldPacket data)
	{
		this.FactionGroup = data.ReadInt32();
		this.Locale = data.ReadInt32();
		this.RequesterVirtualRealmAddress = data.ReadUInt32();
	}
}
