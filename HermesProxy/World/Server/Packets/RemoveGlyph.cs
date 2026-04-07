namespace HermesProxy.World.Server.Packets;

public class RemoveGlyph : ClientPacket
{
	public byte GlyphSlot;

	public RemoveGlyph(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.GlyphSlot = base._worldPacket.ReadUInt8();
	}
}
