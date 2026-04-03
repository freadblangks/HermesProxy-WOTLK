using System;
using Framework;
using HermesProxy.World.Enums;

namespace HermesProxy.World;

public abstract class ClientPacket : IDisposable
{
	protected WorldPacket _worldPacket;

	protected ClientPacket(WorldPacket worldPacket)
	{
		this._worldPacket = worldPacket;
	}

	public abstract void Read();

	public void Dispose()
	{
		this._worldPacket.Dispose();
	}

	public uint GetOpcode()
	{
		return this._worldPacket.GetOpcode();
	}

	public Opcode GetUniversalOpcode()
	{
		return ModernVersion.GetUniversalOpcode(this.GetOpcode());
	}

	public void LogPacket(ref SniffFile sniffFile)
	{
		if (Settings.PacketsLog)
		{
			if (sniffFile == null)
			{
				sniffFile = new SniffFile("modern", (ushort)Settings.ClientBuild);
				sniffFile.WriteHeader();
			}
			sniffFile.WritePacket(this.GetOpcode(), isFromClient: true, this._worldPacket.GetData());
		}
	}
}
