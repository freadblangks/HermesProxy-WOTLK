using Framework.Constants;

namespace HermesProxy.Auth;

public class RealmInfo
{
	public uint ID;

	public RealmType Type;

	public byte IsLocked;

	public RealmFlags Flags;

	public string Name;

	public string Address;

	public ushort Port;

	public float Population;

	public byte CharacterCount;

	public byte Timezone;

	public byte VersionMajor;

	public byte VersionMinor;

	public byte VersonBugfix;

	public ushort Build;

	public override string ToString()
	{
		return $"{this.ID,-5} {this.Type,-5} {this.IsLocked,-8} {this.Flags,-10} {this.Name,-15} {this.Address,-15} {this.Port,-10} {this.Build,-10}";
	}
}
