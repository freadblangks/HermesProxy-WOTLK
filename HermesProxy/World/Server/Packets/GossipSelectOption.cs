namespace HermesProxy.World.Server.Packets;

public class GossipSelectOption : ClientPacket
{
	public WowGuid128 GossipUnit;

	public uint GossipIndex;

	public uint GossipID;

	public string PromotionCode;

	public GossipSelectOption(WorldPacket packet)
		: base(packet)
	{
	}

	public override void Read()
	{
		this.GossipUnit = base._worldPacket.ReadPackedGuid128();
		this.GossipID = base._worldPacket.ReadUInt32();
		this.GossipIndex = base._worldPacket.ReadUInt32();
		uint length = base._worldPacket.ReadBits<uint>(8);
		this.PromotionCode = base._worldPacket.ReadString(length);
	}
}
