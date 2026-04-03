using System.Collections;
using Framework.IO;

namespace HermesProxy.World.Objects;

public class UpdateMask
{
	private uint _fieldCount;

	protected uint _blockCount;

	protected BitArray _mask;

	public UpdateMask(uint valuesCount = 0u)
	{
		this._fieldCount = valuesCount;
		this._blockCount = (valuesCount + 32 - 1) / 32;
		this._mask = new BitArray((int)valuesCount, defaultValue: false);
	}

	public void SetCount(int valuesCount)
	{
		this._fieldCount = (uint)valuesCount;
		this._blockCount = (uint)(valuesCount + 32 - 1) / 32u;
		this._mask = new BitArray(valuesCount, defaultValue: false);
	}

	public uint GetCount()
	{
		return this._fieldCount;
	}

	public virtual void AppendToPacket(ByteBuffer data)
	{
		data.WriteUInt8((byte)this._blockCount);
		byte[] maskArray = new byte[this._blockCount << 2];
		this._mask.CopyTo(maskArray, 0);
		data.WriteBytes(maskArray);
	}

	public bool GetBit(int index)
	{
		return this._mask.Get(index);
	}

	public void SetBit(int index)
	{
		this._mask.Set(index, value: true);
	}

	private void UnsetBit(int index)
	{
		this._mask.Set(index, value: false);
	}

	public void Clear()
	{
		this._mask.SetAll(value: false);
	}
}
