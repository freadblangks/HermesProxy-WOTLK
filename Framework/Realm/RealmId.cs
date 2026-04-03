using System;

namespace Framework.Realm;

public struct RealmId : IEquatable<RealmId>
{
	public uint Index { get; set; }

	public byte Region { get; set; }

	public byte Site { get; set; }

	public RealmId(byte region, byte battlegroup, uint index)
	{
		this.Region = region;
		this.Site = battlegroup;
		this.Index = index;
	}

	public RealmId(uint realmAddress)
	{
		this.Region = (byte)((realmAddress >> 24) & 0xFF);
		this.Site = (byte)((realmAddress >> 16) & 0xFF);
		this.Index = realmAddress & 0xFFFF;
	}

	public uint GetAddress()
	{
		return (uint)((this.Region << 24) | (this.Site << 16) | (ushort)this.Index);
	}

	public string GetAddressString()
	{
		return $"{this.Region}-{this.Site}-{this.Index}";
	}

	public string GetSubRegionAddress()
	{
		return $"{this.Region}-{this.Site}-0";
	}

	public override bool Equals(object obj)
	{
		return obj != null && obj is RealmId && this.Equals((RealmId)obj);
	}

	public bool Equals(RealmId other)
	{
		return other.Index == this.Index;
	}

	public override int GetHashCode()
	{
		return new { this.Site, this.Region, this.Index }.GetHashCode();
	}

	public override string ToString()
	{
		return $"Realm{{Index={this.Index},Region={this.Region},Index={this.Index}}}";
	}
}
