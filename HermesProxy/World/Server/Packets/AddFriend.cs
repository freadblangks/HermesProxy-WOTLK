namespace HermesProxy.World.Server.Packets;

public class AddFriend : ClientPacket
{
	public string Note;

	public string Name;

	public AddFriend(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint nameLength = base._worldPacket.ReadBits<uint>(9);
		uint noteslength = base._worldPacket.ReadBits<uint>(10);
		this.Name = base._worldPacket.ReadString(nameLength);
		this.Note = base._worldPacket.ReadString(noteslength);
	}
}
