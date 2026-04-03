namespace HermesProxy.World.Server.Packets;

internal class MountSpecial : ClientPacket
{
	public int[] SpellVisualKitIDs;

	public int SequenceVariation;

	public MountSpecial(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.SpellVisualKitIDs = new int[base._worldPacket.ReadUInt32()];
		if (ModernVersion.AddedInVersion(9, 2, 0, 1, 14, 2, 2, 5, 3))
		{
			this.SequenceVariation = base._worldPacket.ReadInt32();
		}
		for (int i = 0; i < this.SpellVisualKitIDs.Length; i++)
		{
			this.SpellVisualKitIDs[i] = base._worldPacket.ReadInt32();
		}
	}
}
