using Framework.IO;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Objects;

public class DynamicUpdateMask : UpdateMask
{
	public uint DynamicFieldChangeType;

	public int? ValueCount;

	public DynamicUpdateMask(uint valuesCount)
		: base(valuesCount)
	{
	}

	public void EncodeDynamicFieldChangeType(DynamicFieldChangeType changeType, UpdateTypeModern updateType)
	{
		this.DynamicFieldChangeType = (uint)(base._blockCount | ((uint)(changeType & HermesProxy.World.Objects.DynamicFieldChangeType.ValueAndSizeChanged) * ((int)(3 - updateType) / 3)));
	}

	public override void AppendToPacket(ByteBuffer data)
	{
		data.WriteUInt16((ushort)this.DynamicFieldChangeType);
		if (this.ValueCount.HasValue)
		{
			data.WriteInt32(this.ValueCount.Value);
		}
		byte[] maskArray = new byte[base._blockCount << 2];
		base._mask.CopyTo(maskArray, 0);
		data.WriteBytes(maskArray);
	}
}
