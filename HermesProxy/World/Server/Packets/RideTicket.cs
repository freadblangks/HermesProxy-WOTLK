namespace HermesProxy.World.Server.Packets;

public class RideTicket
{
	public WowGuid128 RequesterGuid = WowGuid128.Empty;

	public uint Id;

	public RideType Type;

	public long Time;

	public void Read(WorldPacket data)
	{
		this.RequesterGuid = data.ReadPackedGuid128();
		this.Id = data.ReadUInt32();
		this.Type = (RideType)data.ReadUInt32();
		this.Time = data.ReadInt64();
	}

	public void Write(WorldPacket data)
	{
		data.WritePackedGuid128(this.RequesterGuid);
		data.WriteUInt32(this.Id);
		data.WriteUInt32((uint)this.Type);
		data.WriteInt64(this.Time);
	}
}
