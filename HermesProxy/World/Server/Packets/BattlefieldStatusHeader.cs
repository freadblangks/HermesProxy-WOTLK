using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class BattlefieldStatusHeader
{
	public RideTicket Ticket = new RideTicket();

	public List<uint> BattlefieldListIDs = new List<uint>();

	public byte Unk254;

	public byte RangeMin;

	public byte RangeMax = 70;

	public byte ArenaTeamSize;

	public uint InstanceID;

	public bool IsArena;

	public bool TournamentRules;

	public void Write(WorldPacket data)
	{
		this.Ticket.Write(data);
		if (ModernVersion.AddedInClassicVersion(1, 14, 3, 2, 5, 4))
		{
			data.WriteUInt8(this.Unk254);
		}
		data.WriteInt32(this.BattlefieldListIDs.Count);
		data.WriteUInt8(this.RangeMin);
		data.WriteUInt8(this.RangeMax);
		data.WriteUInt8(this.ArenaTeamSize);
		data.WriteUInt32(this.InstanceID);
		foreach (uint battlefieldListID in this.BattlefieldListIDs)
		{
			ulong bgId = battlefieldListID;
			ulong queueID = bgId | 0x1F10000000000000L;
			data.WriteUInt64(queueID);
		}
		data.WriteBit(this.IsArena);
		data.WriteBit(this.TournamentRules);
		data.FlushBits();
	}
}
