namespace HermesProxy.World.Server.Packets;

public class CastSpell : ClientPacket
{
	public SpellCastRequest Cast;

	public CastSpell(WorldPacket packet)
		: base(packet)
	{
		this.Cast = new SpellCastRequest();
	}

	public override void Read()
	{
		this.Cast.Read(base._worldPacket);
	}
}
