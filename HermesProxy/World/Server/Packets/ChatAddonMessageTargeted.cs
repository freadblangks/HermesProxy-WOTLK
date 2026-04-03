namespace HermesProxy.World.Server.Packets;

internal class ChatAddonMessageTargeted : ClientPacket
{
	public ChatAddonMessageParams Params = new ChatAddonMessageParams();

	public WowGuid128 ChannelGuid;

	public string Target;

	public ChatAddonMessageTargeted(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint targetLen = base._worldPacket.ReadBits<uint>(9);
		this.Params.Read(base._worldPacket);
		this.ChannelGuid = base._worldPacket.ReadPackedGuid128();
		this.Target = base._worldPacket.ReadString(targetLen);
	}
}
