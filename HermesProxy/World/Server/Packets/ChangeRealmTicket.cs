using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

internal class ChangeRealmTicket : ClientPacket
{
	public uint Token;

	public Array<byte> Secret = new Array<byte>(32);

	public ChangeRealmTicket(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Token = base._worldPacket.ReadUInt32();
		for (int i = 0; i < this.Secret.GetLimit(); i++)
		{
			this.Secret[i] = base._worldPacket.ReadUInt8();
		}
	}
}
