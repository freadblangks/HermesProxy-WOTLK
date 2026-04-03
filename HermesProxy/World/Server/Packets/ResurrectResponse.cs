namespace HermesProxy.World.Server.Packets;

public class ResurrectResponse : ClientPacket
{
	public WowGuid128 CasterGUID;

	public uint Response;

	public ResurrectResponse(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.CasterGUID = base._worldPacket.ReadPackedGuid128();
		this.Response = base._worldPacket.ReadUInt32();
	}
}
