using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class PlaySound : ServerPacket
{
	public uint SoundEntryID;

	public WowGuid128 SourceObjectGuid;

	public int BroadcastTextId;

	public PlaySound()
		: base(Opcode.SMSG_PLAY_SOUND)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteUInt32(this.SoundEntryID);
		base._worldPacket.WritePackedGuid128(this.SourceObjectGuid);
		if (ModernVersion.AddedInVersion(9, 0, 1, 1, 14, 0, 2, 5, 1))
		{
			base._worldPacket.WriteInt32(this.BroadcastTextId);
		}
	}
}
