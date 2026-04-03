using Framework.GameMath;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

internal class PlayObjectSound : ServerPacket
{
	public uint SoundEntryID;

	public WowGuid128 SourceObjectGUID;

	public WowGuid128 TargetObjectGUID;

	public Vector3 Position = default(Vector3);

	public int BroadcastTextID;

	public PlayObjectSound()
		: base(Opcode.SMSG_PLAY_OBJECT_SOUND)
	{
	}

	public override void Write()
	{
		base._worldPacket.WriteUInt32(this.SoundEntryID);
		base._worldPacket.WritePackedGuid128(this.SourceObjectGUID);
		base._worldPacket.WritePackedGuid128(this.TargetObjectGUID);
		base._worldPacket.WriteVector3(this.Position);
		if (ModernVersion.AddedInVersion(9, 0, 1, 1, 14, 0, 2, 5, 1))
		{
			base._worldPacket.WriteInt32(this.BroadcastTextID);
		}
	}
}
