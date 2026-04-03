using System;

namespace HermesProxy.World.Server.Packets;

public class ChrCustomizationChoice : IComparable<ChrCustomizationChoice>
{
	public uint ChrCustomizationOptionID;

	public uint ChrCustomizationChoiceID;

	public ChrCustomizationChoice(uint optionId, uint chocieId)
	{
		this.ChrCustomizationOptionID = optionId;
		this.ChrCustomizationChoiceID = chocieId;
	}

	public void WriteCreate(WorldPacket data)
	{
		data.WriteUInt32(this.ChrCustomizationOptionID);
		data.WriteUInt32(this.ChrCustomizationChoiceID);
	}

	public void WriteUpdate(WorldPacket data)
	{
		data.WriteUInt32(this.ChrCustomizationOptionID);
		data.WriteUInt32(this.ChrCustomizationChoiceID);
	}

	public int CompareTo(ChrCustomizationChoice other)
	{
		return this.ChrCustomizationOptionID.CompareTo(other.ChrCustomizationOptionID);
	}
}
