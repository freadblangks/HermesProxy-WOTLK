using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class TaskProgress
{
	public uint TaskID;

	public uint FailureTime;

	public uint Flags;

	public uint Unk;

	public List<ushort> Progress = new List<ushort>();

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.TaskID);
		data.WriteUInt32(this.FailureTime);
		data.WriteUInt32(this.Flags);
		data.WriteUInt32(this.Unk);
		data.WriteInt32(this.Progress.Count);
		foreach (ushort progress in this.Progress)
		{
			data.WriteUInt16(progress);
		}
	}
}
