namespace HermesProxy.World.Server.Packets;

internal class PetRename : ClientPacket
{
	public PetRenameData RenameData;

	public PetRename(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.RenameData.PetGUID = base._worldPacket.ReadPackedGuid128();
		this.RenameData.PetNumber = base._worldPacket.ReadInt32();
		uint nameLen = base._worldPacket.ReadBits<uint>(8);
		this.RenameData.HasDeclinedNames = base._worldPacket.HasBit();
		if (this.RenameData.HasDeclinedNames)
		{
			this.RenameData.DeclinedNames = new DeclinedName();
			uint[] count = new uint[5];
			for (int i = 0; i < 5; i++)
			{
				count[i] = base._worldPacket.ReadBits<uint>(7);
			}
			for (int j = 0; j < 5; j++)
			{
				this.RenameData.DeclinedNames.name[j] = base._worldPacket.ReadString(count[j]);
			}
		}
		this.RenameData.NewName = base._worldPacket.ReadString(nameLen);
	}
}
