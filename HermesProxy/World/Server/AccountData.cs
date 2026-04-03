namespace HermesProxy.World.Server;

public class AccountData
{
	public WowGuid128 Guid;

	public long Timestamp;

	public uint Type;

	public uint UncompressedSize;

	public byte[] CompressedData;
}
