namespace HermesProxy.World.Server.Packets;

public class AddOnInfo
{
	public string Name;

	public string Version;

	public bool Loaded;

	public bool Disabled;

	public void Read(WorldPacket data)
	{
		data.ResetBitPos();
		uint nameLength = data.ReadBits<uint>(10);
		uint versionLength = data.ReadBits<uint>(10);
		this.Loaded = data.HasBit();
		this.Disabled = data.HasBit();
		if (nameLength > 1)
		{
			this.Name = data.ReadString(nameLength - 1);
			data.ReadUInt8();
		}
		if (versionLength > 1)
		{
			this.Version = data.ReadString(versionLength - 1);
			data.ReadUInt8();
		}
	}
}
