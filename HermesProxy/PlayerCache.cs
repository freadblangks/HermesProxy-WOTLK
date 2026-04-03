using HermesProxy.World.Enums;

namespace HermesProxy;

public class PlayerCache
{
	public string? Name;

	public Race RaceId = Race.None;

	public Class ClassId = Class.None;

	public Gender SexId = Gender.None;

	public byte Level = 0;
}
