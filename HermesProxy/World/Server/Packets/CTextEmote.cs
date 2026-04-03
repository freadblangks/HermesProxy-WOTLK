namespace HermesProxy.World.Server.Packets;

public class CTextEmote : ClientPacket
{
	public WowGuid128 Target;

	public int EmoteID;

	public int SoundIndex;

	public int SequenceVariation;

	public uint[] SpellVisualKitIDs;

	public CTextEmote(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Target = base._worldPacket.ReadPackedGuid128();
		this.EmoteID = base._worldPacket.ReadInt32();
		this.SoundIndex = base._worldPacket.ReadInt32();
		if (ModernVersion.AddedInVersion(9, 0, 5, 1, 14, 0, 2, 5, 1))
		{
			this.SpellVisualKitIDs = new uint[base._worldPacket.ReadUInt32()];
			if (ModernVersion.AddedInVersion(9, 2, 0, 1, 14, 2, 2, 5, 3))
			{
				this.SequenceVariation = base._worldPacket.ReadInt32();
			}
			for (int i = 0; i < this.SpellVisualKitIDs.Length; i++)
			{
				this.SpellVisualKitIDs[i] = base._worldPacket.ReadUInt32();
			}
		}
	}
}
