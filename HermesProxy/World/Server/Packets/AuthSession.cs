using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

internal class AuthSession : ClientPacket
{
	public uint RegionID;

	public uint BattlegroupID;

	public uint RealmID;

	public Array<byte> LocalChallenge = new Array<byte>(16);

	public byte[] Digest = new byte[24];

	public ulong DosResponse;

	public string RealmJoinTicket;

	public bool UseIPv6;

	public AuthSession(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.DosResponse = base._worldPacket.ReadUInt64();
		this.RegionID = base._worldPacket.ReadUInt32();
		this.BattlegroupID = base._worldPacket.ReadUInt32();
		this.RealmID = base._worldPacket.ReadUInt32();
		for (int i = 0; i < this.LocalChallenge.GetLimit(); i++)
		{
			this.LocalChallenge[i] = base._worldPacket.ReadUInt8();
		}
		this.Digest = base._worldPacket.ReadBytes(24u);
		this.UseIPv6 = base._worldPacket.HasBit();
		uint realmJoinTicketSize = base._worldPacket.ReadUInt32();
		if (realmJoinTicketSize != 0)
		{
			this.RealmJoinTicket = base._worldPacket.ReadString(realmJoinTicketSize);
		}
	}
}
