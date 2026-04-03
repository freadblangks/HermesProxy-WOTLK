namespace HermesProxy.World.Server.Packets;

internal class UnlearnSkill : ClientPacket
{
	public uint SkillLine;

	public UnlearnSkill(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.SkillLine = base._worldPacket.ReadUInt32();
	}
}
