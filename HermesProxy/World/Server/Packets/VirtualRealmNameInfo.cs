using System;

namespace HermesProxy.World.Server.Packets;

internal struct VirtualRealmNameInfo
{
	public bool IsLocal;

	public bool IsInternalRealm;

	public string RealmNameActual;

	public string RealmNameNormalized;

	public VirtualRealmNameInfo(bool isHomeRealm, bool isInternalRealm, string realmNameActual, string realmNameNormalized)
	{
		this.IsLocal = isHomeRealm;
		this.IsInternalRealm = isInternalRealm;
		this.RealmNameActual = realmNameActual;
		this.RealmNameNormalized = realmNameNormalized;
	}

	public void Write(WorldPacket data)
	{
		data.WriteBit(this.IsLocal);
		data.WriteBit(this.IsInternalRealm);
		data.WriteBits(this.RealmNameActual.GetByteCount(), 8);
		data.WriteBits(this.RealmNameNormalized.GetByteCount(), 8);
		data.FlushBits();
		data.WriteString(this.RealmNameActual);
		data.WriteString(this.RealmNameNormalized);
	}
}
