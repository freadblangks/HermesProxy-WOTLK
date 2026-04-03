namespace HermesProxy.World.Server.Packets;

public class PlayerLogin : ClientPacket
{
	public WowGuid128 Guid;

	public float FarClip;

	public bool UnkBit;

	public PlayerLogin(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Guid = base._worldPacket.ReadPackedGuid128();
		this.FarClip = base._worldPacket.ReadFloat();
		try
		{
			this.UnkBit = base._worldPacket.HasBit();
		}
		catch
		{
			this.UnkBit = false;
		}
	}
}
