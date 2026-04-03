namespace HermesProxy.World.Server.Packets;

public class MailReturnToSender : ClientPacket
{
	public uint MailID;

	public WowGuid128 SenderGUID;

	public MailReturnToSender(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.MailID = base._worldPacket.ReadUInt32();
		this.SenderGUID = base._worldPacket.ReadPackedGuid128();
	}
}
