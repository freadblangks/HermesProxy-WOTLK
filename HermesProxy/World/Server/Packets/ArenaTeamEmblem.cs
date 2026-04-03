using System;

namespace HermesProxy.World.Server.Packets;

public class ArenaTeamEmblem
{
	public uint TeamId;

	public uint TeamSize;

	public uint BackgroundColor;

	public uint EmblemStyle;

	public uint EmblemColor;

	public uint BorderStyle;

	public uint BorderColor;

	public string TeamName;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.TeamId);
		data.WriteUInt32(this.TeamSize);
		data.WriteUInt32(this.BackgroundColor);
		data.WriteUInt32(this.EmblemStyle);
		data.WriteUInt32(this.EmblemColor);
		data.WriteUInt32(this.BorderStyle);
		data.WriteUInt32(this.BorderColor);
		data.WriteBits(this.TeamName.GetByteCount(), 7);
		data.FlushBits();
		data.WriteString(this.TeamName);
	}
}
