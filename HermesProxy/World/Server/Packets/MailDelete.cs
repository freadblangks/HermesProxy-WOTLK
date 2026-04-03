namespace HermesProxy.World.Server.Packets;

public class MailDelete : ClientPacket
{
	public uint MailID;

	public int DeleteReason;

	public MailDelete(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.MailID = base._worldPacket.ReadUInt32();
		this.DeleteReason = base._worldPacket.ReadInt32();
	}
}
