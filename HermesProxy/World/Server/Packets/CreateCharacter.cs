using HermesProxy.World.Enums;

namespace HermesProxy.World.Server.Packets;

public class CreateCharacter : ClientPacket
{
	public CharacterCreateInfo CreateInfo;

	public CreateCharacter(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.CreateInfo = new CharacterCreateInfo();
		uint nameLength = base._worldPacket.ReadBits<uint>(6);
		bool hasTemplateSet = base._worldPacket.HasBit();
		this.CreateInfo.IsTrialBoost = base._worldPacket.HasBit();
		this.CreateInfo.UseNPE = base._worldPacket.HasBit();
		this.CreateInfo.RaceId = (Race)base._worldPacket.ReadUInt8();
		this.CreateInfo.ClassId = (Class)base._worldPacket.ReadUInt8();
		this.CreateInfo.Sex = (Gender)base._worldPacket.ReadUInt8();
		uint customizationCount = base._worldPacket.ReadUInt32();
		this.CreateInfo.Name = base._worldPacket.ReadString(nameLength);
		if (hasTemplateSet)
		{
			this.CreateInfo.TemplateSet = base._worldPacket.ReadUInt32();
		}
		for (int i = 0; i < customizationCount; i++)
		{
			this.CreateInfo.Customizations[i] = new ChrCustomizationChoice(base._worldPacket.ReadUInt32(), base._worldPacket.ReadUInt32());
		}
		this.CreateInfo.Customizations.Sort();
	}
}
