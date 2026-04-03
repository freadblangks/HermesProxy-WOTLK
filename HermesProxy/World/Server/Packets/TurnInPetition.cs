namespace HermesProxy.World.Server.Packets;

public class TurnInPetition : ClientPacket
{
	public WowGuid128 Item;

	public uint BackgroundColor;

	public uint EmblemStyle;

	public uint EmblemColor;

	public uint BorderStyle;

	public uint BorderColor;

	public TurnInPetition(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Item = base._worldPacket.ReadPackedGuid128();
		if (base._worldPacket.CanRead())
		{
			this.BackgroundColor = base._worldPacket.ReadUInt32();
			this.EmblemStyle = base._worldPacket.ReadUInt32();
			this.EmblemColor = base._worldPacket.ReadUInt32();
			this.BorderStyle = base._worldPacket.ReadUInt32();
			this.BorderColor = base._worldPacket.ReadUInt32();
		}
	}
}
