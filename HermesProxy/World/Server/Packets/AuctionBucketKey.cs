namespace HermesProxy.World.Server.Packets;

public class AuctionBucketKey
{
	public uint ItemID;

	public ushort ItemLevel;

	public ushort? BattlePetSpeciesID = 0;

	public ushort? SuffixItemNameDescriptionID = 0;

	public AuctionBucketKey()
	{
	}

	public AuctionBucketKey(WorldPacket data)
	{
		data.ResetBitPos();
		this.ItemID = data.ReadBits<uint>(20);
		if (data.HasBit())
		{
			this.BattlePetSpeciesID = 0;
		}
		this.ItemLevel = data.ReadBits<ushort>(11);
		if (data.HasBit())
		{
			this.SuffixItemNameDescriptionID = 0;
		}
		if (this.BattlePetSpeciesID.HasValue)
		{
			this.BattlePetSpeciesID = data.ReadUInt16();
		}
		if (this.SuffixItemNameDescriptionID.HasValue)
		{
			this.SuffixItemNameDescriptionID = data.ReadUInt16();
		}
	}

	public void Write(WorldPacket data)
	{
		data.WriteBits(this.ItemID, 20);
		data.WriteBit(this.BattlePetSpeciesID.HasValue);
		data.WriteBits(this.ItemLevel, 11);
		data.WriteBit(this.SuffixItemNameDescriptionID.HasValue);
		data.FlushBits();
		if (this.BattlePetSpeciesID.HasValue)
		{
			data.WriteUInt16(this.BattlePetSpeciesID.Value);
		}
		if (this.SuffixItemNameDescriptionID.HasValue)
		{
			data.WriteUInt16(this.SuffixItemNameDescriptionID.Value);
		}
	}
}
