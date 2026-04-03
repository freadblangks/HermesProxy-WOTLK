using System.Collections.Generic;
using HermesProxy.World.Objects;

namespace HermesProxy.World.Server.Packets;

public class SpellCastRequest
{
	public WowGuid128 CastID;

	public uint SpellID;

	public uint SpellXSpellVisualID;

	public uint SendCastFlags;

	public SpellTargetData Target = new SpellTargetData();

	public MissileTrajectoryRequest MissileTrajectory;

	public WowGuid128 MoverGUID;

	public MovementInfo MoveUpdate;

	public List<SpellWeight> Weight = new List<SpellWeight>();

	public Array<SpellOptionalReagent> OptionalReagents = new Array<SpellOptionalReagent>(3);

	public Array<SpellExtraCurrencyCost> OptionalCurrencies = new Array<SpellExtraCurrencyCost>(5);

	public WowGuid128 CraftingNPC;

	public uint[] Misc = new uint[2];

	public void Read(WorldPacket data)
	{
		this.CastID = data.ReadPackedGuid128();
		this.Misc[0] = data.ReadUInt32();
		this.Misc[1] = data.ReadUInt32();
		this.SpellID = data.ReadUInt32();
		this.SpellXSpellVisualID = data.ReadUInt32();
		this.MissileTrajectory.Read(data);
		this.CraftingNPC = data.ReadPackedGuid128();
		uint optionalReagents = data.ReadUInt32();
		uint optionalCurrencies = data.ReadUInt32();
		for (int i = 0; i < optionalReagents; i++)
		{
			this.OptionalReagents[i].Read(data);
		}
		for (int j = 0; j < optionalCurrencies; j++)
		{
			this.OptionalCurrencies[j].Read(data);
		}
		this.SendCastFlags = data.ReadBits<uint>(5);
		if (data.HasBit())
		{
			this.MoveUpdate = new MovementInfo();
		}
		uint weightCount = data.ReadBits<uint>(2);
		this.Target.Read(data);
		if (this.MoveUpdate != null)
		{
			this.MoverGUID = data.ReadPackedGuid128();
			this.MoveUpdate.ReadMovementInfoModern(data);
		}
		SpellWeight weight = default(SpellWeight);
		for (int k = 0; k < weightCount; k++)
		{
			data.ResetBitPos();
			weight.Type = data.ReadBits<uint>(2);
			weight.ID = data.ReadInt32();
			weight.Quantity = data.ReadUInt32();
			this.Weight.Add(weight);
		}
	}
}
