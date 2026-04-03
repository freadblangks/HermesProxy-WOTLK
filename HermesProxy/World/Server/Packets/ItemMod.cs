using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class ItemMod
{
	public uint Value;

	public ItemModifier Type;

	public ItemMod()
	{
		this.Type = ItemModifier.Max;
	}

	public ItemMod(uint value, ItemModifier type)
	{
		this.Value = value;
		this.Type = type;
	}

	public void Read(WorldPacket data)
	{
		this.Value = data.ReadUInt32();
		this.Type = (ItemModifier)data.ReadUInt8();
	}

	public void Write(WorldPacket data)
	{
		data.WriteUInt32(this.Value);
		data.WriteUInt8((byte)this.Type);
	}
}
