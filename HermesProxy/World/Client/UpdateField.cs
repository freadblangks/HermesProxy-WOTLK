using System;
using System.Runtime.InteropServices;

namespace HermesProxy.World.Client;

[StructLayout(LayoutKind.Explicit)]
public struct UpdateField
{
	[FieldOffset(0)]
	public readonly uint UInt32Value;

	[FieldOffset(0)]
	public readonly int Int32Value;

	[FieldOffset(0)]
	public readonly float FloatValue;

	public UpdateField(uint val)
	{
		this = default(UpdateField);
		this.UInt32Value = val;
	}

	public UpdateField(int val)
	{
		this = default(UpdateField);
		this.Int32Value = val;
	}

	public UpdateField(float val)
	{
		this = default(UpdateField);
		this.FloatValue = val;
	}

	public override bool Equals(object obj)
	{
		if (obj is UpdateField)
		{
			return this.Equals((UpdateField)obj);
		}
		return false;
	}

	public bool Equals(UpdateField other)
	{
		if (this.UInt32Value == other.UInt32Value)
		{
			return true;
		}
		if (Math.Abs(this.FloatValue - other.FloatValue) < float.Epsilon)
		{
			return true;
		}
		return false;
	}

	public static bool operator ==(UpdateField first, UpdateField other)
	{
		return first.Equals(other);
	}

	public static bool operator !=(UpdateField first, UpdateField other)
	{
		return !(first == other);
	}

	public override int GetHashCode()
	{
		return this.UInt32Value.GetHashCode();
	}
}
