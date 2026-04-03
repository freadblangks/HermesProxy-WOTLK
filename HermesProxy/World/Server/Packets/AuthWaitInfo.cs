namespace HermesProxy.World.Server.Packets;

public class AuthWaitInfo
{
	public uint WaitCount;

	public uint WaitTime;

	public bool HasFCM;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.WaitCount);
		data.WriteUInt32(this.WaitTime);
		data.WriteBit(this.HasFCM);
		data.FlushBits();
	}
}
