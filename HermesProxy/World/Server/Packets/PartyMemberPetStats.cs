using System;
using System.Collections.Generic;

namespace HermesProxy.World.Server.Packets;

public class PartyMemberPetStats
{
	public WowGuid128 NewPetGuid;

	public string NewPetName;

	public uint? DisplayID;

	public uint? MaxHealth;

	public uint? Health;

	public List<PartyMemberAuraStates> Auras;

	public void WritePartial(WorldPacket data)
	{
		data.WriteBit(this.NewPetGuid != null);
		data.WriteBit(this.NewPetName != null);
		data.WriteBit(this.DisplayID.HasValue);
		data.WriteBit(this.MaxHealth.HasValue);
		data.WriteBit(this.Health.HasValue);
		data.WriteBit(this.Auras != null);
		data.FlushBits();
		if (this.NewPetName != null)
		{
			data.WriteBits(this.NewPetName.GetByteCount(), 8);
			data.WriteString(this.NewPetName);
		}
		if (this.NewPetGuid != null)
		{
			data.WritePackedGuid128(this.NewPetGuid);
		}
		if (this.DisplayID.HasValue)
		{
			data.WriteUInt32(this.DisplayID.Value);
		}
		if (this.MaxHealth.HasValue)
		{
			data.WriteUInt32(this.MaxHealth.Value);
		}
		if (this.Health.HasValue)
		{
			data.WriteUInt32(this.Health.Value);
		}
		if (this.Auras == null)
		{
			return;
		}
		data.WriteInt32(this.Auras.Count);
		foreach (PartyMemberAuraStates aura in this.Auras)
		{
			aura.Write(data);
		}
	}

	public void WriteFull(WorldPacket data)
	{
		if (this.NewPetGuid == null)
		{
			this.NewPetGuid = WowGuid128.Empty;
		}
		if (this.NewPetName == null)
		{
			this.NewPetName = "";
		}
		if (!this.DisplayID.HasValue)
		{
			this.DisplayID = 0u;
		}
		if (!this.MaxHealth.HasValue)
		{
			this.MaxHealth = 0u;
		}
		if (!this.Health.HasValue)
		{
			this.Health = 0u;
		}
		if (this.Auras == null)
		{
			this.Auras = new List<PartyMemberAuraStates>();
		}
		data.WritePackedGuid128(this.NewPetGuid);
		data.WriteUInt32(this.DisplayID.Value);
		data.WriteUInt32(this.Health.Value);
		data.WriteUInt32(this.MaxHealth.Value);
		data.WriteInt32(this.Auras.Count);
		this.Auras.ForEach(delegate(PartyMemberAuraStates p)
		{
			p.Write(data);
		});
		data.WriteBits(this.NewPetName.GetByteCount(), 8);
		data.FlushBits();
		data.WriteString(this.NewPetName);
	}
}
