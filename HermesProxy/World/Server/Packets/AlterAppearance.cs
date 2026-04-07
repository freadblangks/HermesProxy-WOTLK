using System.Collections.Generic;
using HermesProxy.World.Enums;
using HermesProxy.World.Objects;

namespace HermesProxy.World.Server.Packets;

public class AlterAppearance : ClientPacket
{
	public Array<ChrCustomizationChoice> Customizations = new Array<ChrCustomizationChoice>(50);
	public byte NewSex;
	public int CustomizedRace;
	public int CustomizedChrModelID;

	public AlterAppearance(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		uint customizationCount = base._worldPacket.ReadUInt32();
		this.NewSex = base._worldPacket.ReadUInt8();
		this.CustomizedRace = base._worldPacket.ReadInt32();
		this.CustomizedChrModelID = base._worldPacket.ReadInt32();
		for (uint i = 0; i < customizationCount; i++)
		{
			this.Customizations[(int)i] = new ChrCustomizationChoice(base._worldPacket.ReadUInt32(), base._worldPacket.ReadUInt32());
		}
		this.Customizations.Sort();
	}
}
