using System;
using System.IO;
using System.Threading;

namespace HermesProxy.World;

public class SniffFile
{
	private BinaryWriter _fileWriter;

	private ushort _gameVersion;

	private Mutex _mutex = new Mutex();

	public SniffFile(string fileName, ushort build)
	{
		string dir = "PacketsLog";
		if (!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}
		string file = fileName + "_" + build + "_" + Time.UnixTime + ".pkt";
		string path = Path.Combine(dir, file);
		this._fileWriter = new BinaryWriter(File.Open(path, FileMode.Create));
		this._gameVersion = build;
	}

	public void WriteHeader()
	{
		this._fileWriter.Write('P');
		this._fileWriter.Write('K');
		this._fileWriter.Write('T');
		ushort sniffVersion = 513;
		this._fileWriter.Write(sniffVersion);
		this._fileWriter.Write(this._gameVersion);
		for (int i = 0; i < 40; i++)
		{
			byte zero = 0;
			this._fileWriter.Write(zero);
		}
	}

	public void WritePacket(uint opcode, bool isFromClient, byte[] data)
	{
		this._mutex.WaitOne();
		byte direction = (byte)((!isFromClient) ? byte.MaxValue : 0);
		this._fileWriter.Write(direction);
		uint unixtime = (uint)Time.UnixTime;
		this._fileWriter.Write(unixtime);
		this._fileWriter.Write(Environment.TickCount);
		if (isFromClient)
		{
			uint packetSize = (uint)(data.Length - 2 + 4);
			this._fileWriter.Write(packetSize);
			this._fileWriter.Write(opcode);
			for (int i = 2; i < data.Length; i++)
			{
				this._fileWriter.Write(data[i]);
			}
		}
		else
		{
			uint packetSize2 = (uint)(data.Length + 2);
			this._fileWriter.Write(packetSize2);
			ushort opcode2 = (ushort)opcode;
			this._fileWriter.Write(opcode2);
			this._fileWriter.Write(data);
		}
		this._mutex.ReleaseMutex();
	}

	public void CloseFile()
	{
		this._fileWriter.Close();
	}
}
