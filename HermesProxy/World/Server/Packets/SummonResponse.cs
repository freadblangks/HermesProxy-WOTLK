namespace HermesProxy.World.Server.Packets;

internal class SummonResponse : ClientPacket
{
	public WowGuid128 SummonerGUID;

	public bool Accept;

	public SummonResponse(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.SummonerGUID = base._worldPacket.ReadPackedGuid128();
		this.Accept = base._worldPacket.HasBit();
	}
}
