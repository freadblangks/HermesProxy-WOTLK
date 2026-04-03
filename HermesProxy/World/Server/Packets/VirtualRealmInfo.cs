namespace HermesProxy.World.Server.Packets;

internal struct VirtualRealmInfo
{
	public uint RealmAddress;

	public VirtualRealmNameInfo RealmNameInfo;

	public VirtualRealmInfo(uint realmAddress, bool isHomeRealm, bool isInternalRealm, string realmNameActual, string realmNameNormalized)
	{
		this.RealmAddress = realmAddress;
		this.RealmNameInfo = new VirtualRealmNameInfo(isHomeRealm, isInternalRealm, realmNameActual, realmNameNormalized);
	}

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.RealmAddress);
		this.RealmNameInfo.Write(data);
	}
}
