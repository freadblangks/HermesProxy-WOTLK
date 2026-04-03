using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class GenerateRandomCharacterNameRequest : ClientPacket
{
	public Race Race;

	public Gender Sex;

	public GenerateRandomCharacterNameRequest(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.Race = (Race)base._worldPacket.ReadUInt8();
		this.Sex = (Gender)base._worldPacket.ReadUInt8();
	}
}
