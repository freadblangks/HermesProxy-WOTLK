namespace HermesProxy.World.Server.Packets;

internal class AuthContinuedSession : ClientPacket
{
	public ulong DosResponse;

	public ulong Key;

	public byte[] LocalChallenge = new byte[16];

	public byte[] Digest = new byte[24];

	public AuthContinuedSession(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.DosResponse = base._worldPacket.ReadUInt64();
		this.Key = base._worldPacket.ReadUInt64();
		this.LocalChallenge = base._worldPacket.ReadBytes(16u);
		this.Digest = base._worldPacket.ReadBytes(24u);
	}
}
