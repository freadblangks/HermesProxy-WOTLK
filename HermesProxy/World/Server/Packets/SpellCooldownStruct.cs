namespace HermesProxy.World.Server.Packets;

public class SpellCooldownStruct
{
	public uint SpellID;

	public uint ForcedCooldown;

	public float ModRate = 1f;

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.SpellID);
		data.WriteUInt32(this.ForcedCooldown);
		data.WriteFloat(this.ModRate);
	}
}
