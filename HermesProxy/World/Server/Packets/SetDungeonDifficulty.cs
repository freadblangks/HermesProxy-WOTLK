namespace HermesProxy.World.Server.Packets;

public class SetDungeonDifficulty : ClientPacket
{
	public uint DifficultyID;

	public SetDungeonDifficulty(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.DifficultyID = base._worldPacket.ReadUInt32();
	}
}
