namespace HermesProxy.World.Server.Packets;

public class GetAccountCharacterListRequest : ClientPacket
{
	public uint Token = 0u;

	public GetAccountCharacterListRequest(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Token = base._worldPacket.ReadUInt32();
	}
}
