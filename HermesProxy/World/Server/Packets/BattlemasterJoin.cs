namespace HermesProxy.World.Server.Packets;

internal class BattlemasterJoin : ClientPacket
{
	public uint BattlefieldListId;

	public byte Roles;

	public int[] BlacklistMap = new int[2];

	public WowGuid128 BattlemasterGuid;

	public int Verification;

	public int BattlefieldInstanceID;

	public bool JoinAsGroup;

	public BattlemasterJoin(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		long queueId = base._worldPacket.ReadInt64();
		this.BattlefieldListId = (uint)(queueId & -2238289014803136513L);
		this.Roles = base._worldPacket.ReadUInt8();
		this.BlacklistMap[0] = base._worldPacket.ReadInt32();
		this.BlacklistMap[1] = base._worldPacket.ReadInt32();
		this.BattlemasterGuid = base._worldPacket.ReadPackedGuid128();
		this.Verification = base._worldPacket.ReadInt32();
		this.BattlefieldInstanceID = base._worldPacket.ReadInt32();
		this.JoinAsGroup = base._worldPacket.HasBit();
	}
}
