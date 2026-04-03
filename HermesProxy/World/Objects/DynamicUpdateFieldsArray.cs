using System;
using Framework.IO;
using HermesProxy.World.Enums;

namespace HermesProxy.World.Objects;

public class DynamicUpdateFieldsArray
{
	private uint ValuesCount;

	private UpdateTypeModern m_updateType;

	private UpdateMask m_updateMask;

	private ByteBuffer m_fieldBuffer;

	public DynamicUpdateFieldsArray(uint size, UpdateTypeModern updateType)
	{
		this.ValuesCount = size;
		this.m_updateType = updateType;
		this.m_updateMask = new UpdateMask(size);
		this.m_fieldBuffer = new ByteBuffer();
	}

	public void WriteToPacket(ByteBuffer buffer)
	{
		this.m_updateMask.AppendToPacket(buffer);
		buffer.WriteBytes(this.m_fieldBuffer);
	}

	public void SetUpdateField(int index, uint[] values, DynamicFieldChangeType changeType)
	{
		ByteBuffer valueBuffer = new ByteBuffer();
		this.m_updateMask.SetBit(index);
		DynamicUpdateMask arrayMask = new DynamicUpdateMask((uint)values.Length);
		arrayMask.EncodeDynamicFieldChangeType(changeType, this.m_updateType);
		if (this.m_updateType == UpdateTypeModern.Values && changeType == DynamicFieldChangeType.ValueAndSizeChanged)
		{
			arrayMask.ValueCount = values.Length;
			arrayMask.SetCount(values.Length);
		}
		for (int v = 0; v < values.Length; v++)
		{
			arrayMask.SetBit(v);
			valueBuffer.WriteUInt32(values[v]);
		}
		arrayMask.AppendToPacket(this.m_fieldBuffer);
		this.m_fieldBuffer.WriteBytes(valueBuffer);
	}

	public void SetUpdateField<T>(object index, T value, DynamicFieldChangeType changeType) where T : new()
	{
		if (value is int intValue)
		{
			uint[] values = new uint[1];
			UpdateValues union = new UpdateValues
			{
				SignedValue = intValue
			};
			values[0] = union.UnsignedValue;
			this.SetUpdateField((int)index, values, changeType);
			return;
		}
		if (value is uint uintValue)
		{
			this.SetUpdateField(values: new uint[1] { uintValue }, index: (int)index, changeType: changeType);
			return;
		}
		if (value is float floatValue)
		{
			uint[] values2 = new uint[1];
			UpdateValues union2 = new UpdateValues
			{
				FloatValue = floatValue
			};
			values2[0] = union2.UnsignedValue;
			this.SetUpdateField((int)index, values2, changeType);
			return;
		}
		if (value is ulong ulongValue)
		{
			this.SetUpdateField(values: new uint[2]
			{
				MathFunctions.Pair64_LoPart(ulongValue),
				MathFunctions.Pair64_HiPart(ulongValue)
			}, index: (int)index, changeType: changeType);
			return;
		}
		if (!(value is WowGuid128 guid))
		{
			throw new Exception("Unhandled type " + typeof(T).ToString() + " in SetUpdateField!");
		}
		this.SetUpdateField(values: new uint[4]
		{
			MathFunctions.Pair64_LoPart(guid.GetLowValue()),
			MathFunctions.Pair64_HiPart(guid.GetLowValue()),
			MathFunctions.Pair64_LoPart(guid.GetHighValue()),
			MathFunctions.Pair64_HiPart(guid.GetHighValue())
		}, index: (int)index, changeType: changeType);
	}
}
