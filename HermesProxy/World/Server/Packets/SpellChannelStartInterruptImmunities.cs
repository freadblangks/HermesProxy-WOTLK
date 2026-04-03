namespace HermesProxy.World.Server.Packets;

public class SpellChannelStartInterruptImmunities
{
	public int SchoolImmunities;

	public int Immunities;

	public void Write(WorldPacket data)
	{
		data.WriteInt32(this.SchoolImmunities);
		data.WriteInt32(this.Immunities);
	}
}
