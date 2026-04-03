using System.IO;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server;

public class AccountDataManager
{
	public AccountData[] Data;

	private string _accountName;

	private string _realmName;

	public AccountDataManager(string accountName, string realmName)
	{
		this._accountName = accountName;
		this._realmName = realmName.Trim();
	}

	public static bool IsGlobalDataType(uint type)
	{
		switch ((AccountDataType)type)
		{
		case AccountDataType.GlobalConfigCache:
		case AccountDataType.GlobalBindingsCache:
		case AccountDataType.GlobalMacrosCache:
		case AccountDataType.GlobalTTSCache:
		case AccountDataType.GlobalFlaggedCache:
			return true;
		default:
			return false;
		}
	}

	public string GetAccountDataDirectory()
	{
		string path = Path.GetFullPath(Path.Combine("AccountData", this._accountName, this._realmName));
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		return path;
	}

	public string GetFullFileName(WowGuid128 guid, uint type)
	{
		string file = ((!AccountDataManager.IsGlobalDataType(type)) ? $"data-{type}-{guid.GetLowValue()}-{guid.GetHighValue()}.bin" : $"data-{type}.bin");
		string path = this.GetAccountDataDirectory();
		return Path.Combine(path, file);
	}

	public void LoadAllData(WowGuid128 guid)
	{
		this.Data = new AccountData[ModernVersion.GetAccountDataCount()];
		for (uint i = 0u; i < ModernVersion.GetAccountDataCount(); i++)
		{
			this.Data[i] = this.LoadData(guid, i);
		}
	}

	public AccountData LoadData(WowGuid128 guid, uint type)
	{
		AccountData data = null;
		string fileName = this.GetFullFileName(guid, type);
		if (File.Exists(fileName))
		{
			using (File.OpenRead(this.GetFullFileName(guid, type)))
			{
				using BinaryReader reader = new BinaryReader(File.OpenRead(this.GetFullFileName(guid, type)));
				data = new AccountData();
				ulong guidLow = reader.ReadUInt64();
				ulong guidHigh = reader.ReadUInt64();
				data.Guid = new WowGuid128(guidHigh, guidLow);
				if (!AccountDataManager.IsGlobalDataType(type))
				{
				}
				data.Timestamp = reader.ReadInt64();
				data.Type = reader.ReadUInt32();
				data.UncompressedSize = reader.ReadUInt32();
				int compressedSize = reader.ReadInt32();
				data.CompressedData = reader.ReadBytes(compressedSize);
			}
		}
		return data;
	}

	public void SaveData(WowGuid128 guid, long timestamp, uint type, uint uncompressedSize, byte[] compressedData)
	{
		if (compressedData == null)
		{
			return;
		}
		if (this.Data[type] == null)
		{
			this.Data[type] = new AccountData();
		}
		this.Data[type].Guid = guid;
		this.Data[type].Timestamp = timestamp;
		this.Data[type].Type = type;
		this.Data[type].UncompressedSize = uncompressedSize;
		this.Data[type].CompressedData = compressedData;
		using BinaryWriter writer = new BinaryWriter(File.Open(this.GetFullFileName(guid, type), FileMode.Create));
		writer.Write(guid.GetLowValue());
		writer.Write(guid.GetHighValue());
		writer.Write(timestamp);
		writer.Write(type);
		writer.Write(uncompressedSize);
		writer.Write(compressedData.Length);
		writer.Write(compressedData);
	}

	public byte[] LoadCUFProfiles()
	{
		string fileName = Path.Combine(this.GetAccountDataDirectory(), "cuf.bin");
		if (File.Exists(fileName))
		{
			using (FileStream file = File.OpenRead(fileName))
			{
				using (new BinaryReader(file))
				{
					return File.ReadAllBytes(fileName);
				}
			}
		}
		return new byte[4];
	}

	public void SaveCUFProfiles(byte[] data)
	{
		string fileName = Path.Combine(this.GetAccountDataDirectory(), "cuf.bin");
		using BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create));
		writer.Write(data);
	}
}
