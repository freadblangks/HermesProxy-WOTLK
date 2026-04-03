using System;
using System.Collections.Generic;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class PlayerModelDisplayInfo
{
	public WowGuid128 GUID;

	public List<InspectItemData> Items = new List<InspectItemData>();

	public string Name;

	public uint SpecializationID;

	public Gender SexId;

	public Race RaceId;

	public Class ClassId;

	public List<ChrCustomizationChoice> Customizations = new List<ChrCustomizationChoice>();

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.GUID);
		data.WriteUInt32(this.SpecializationID);
		data.WriteInt32(this.Items.Count);
		data.WriteBits(this.Name.GetByteCount(), 6);
		data.WriteUInt8((byte)this.SexId);
		data.WriteUInt8((byte)this.RaceId);
		data.WriteUInt8((byte)this.ClassId);
		data.WriteInt32(this.Customizations.Count);
		data.WriteString(this.Name);
		foreach (ChrCustomizationChoice customization in this.Customizations)
		{
			data.WriteUInt32(customization.ChrCustomizationOptionID);
			data.WriteUInt32(customization.ChrCustomizationChoiceID);
		}
		foreach (InspectItemData item in this.Items)
		{
			item.Write(data);
		}
	}
}
