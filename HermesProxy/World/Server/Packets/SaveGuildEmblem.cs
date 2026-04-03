namespace HermesProxy.World.Server.Packets;

public class SaveGuildEmblem : ClientPacket
{
	public WowGuid128 DesignerGUID;

	public uint EmblemStyle;

	public uint EmblemColor;

	public uint BorderStyle;

	public uint BorderColor;

	public uint BackgroundColor;

	public SaveGuildEmblem(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.DesignerGUID = base._worldPacket.ReadPackedGuid128();
		this.EmblemStyle = base._worldPacket.ReadUInt32();
		this.EmblemColor = base._worldPacket.ReadUInt32();
		this.BorderStyle = base._worldPacket.ReadUInt32();
		this.BorderColor = base._worldPacket.ReadUInt32();
		this.BackgroundColor = base._worldPacket.ReadUInt32();
	}
}
