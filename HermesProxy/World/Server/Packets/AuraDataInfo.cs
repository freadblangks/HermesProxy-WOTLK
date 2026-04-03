using System.Collections.Generic;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class AuraDataInfo
{
	public WowGuid128 CastID;

	public uint SpellID;

	public uint SpellXSpellVisualID;

	public AuraFlagsModern Flags;

	public uint ActiveFlags;

	public ushort CastLevel = 1;

	public byte Applications = 1;

	public int ContentTuningID;

	private ContentTuningParams ContentTuning;

	public WowGuid128 CastUnit;

	public int? Duration;

	public int? Remaining;

	private float? TimeMod;

	public List<float> Points = new List<float>();

	public List<float> EstimatedPoints = new List<float>();

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.CastID);
		data.WriteUInt32(this.SpellID);
		data.WriteUInt32(this.SpellXSpellVisualID);
		data.WriteUInt16((ushort)this.Flags);
		data.WriteUInt32(this.ActiveFlags);
		data.WriteUInt16(this.CastLevel);
		data.WriteUInt8(this.Applications);
		data.WriteInt32(this.ContentTuningID);
		data.WriteBit(this.CastUnit != null);
		data.WriteBit(this.Duration.HasValue);
		data.WriteBit(this.Remaining.HasValue);
		data.WriteBit(this.TimeMod.HasValue);
		data.WriteBits(this.Points.Count, 6);
		data.WriteBits(this.EstimatedPoints.Count, 6);
		data.WriteBit(this.ContentTuning != null);
		if (this.ContentTuning != null)
		{
			this.ContentTuning.Write(data);
		}
		if (this.CastUnit != null)
		{
			data.WritePackedGuid128(this.CastUnit);
		}
		if (this.Duration.HasValue)
		{
			data.WriteInt32(this.Duration.Value);
		}
		if (this.Remaining.HasValue)
		{
			data.WriteInt32(this.Remaining.Value);
		}
		if (this.TimeMod.HasValue)
		{
			data.WriteFloat(this.TimeMod.Value);
		}
		foreach (float point in this.Points)
		{
			data.WriteFloat(point);
		}
		foreach (float point2 in this.EstimatedPoints)
		{
			data.WriteFloat(point2);
		}
	}
}
