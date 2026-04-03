namespace HermesProxy.World.Enums;

internal enum PartyResultVanilla : uint
{
	Ok = 0u,
	BadPlayerName = 1u,
	TargetNotInGroup = 2u,
	GroupFull = 3u,
	AlreadyInGroup = 4u,
	NotInGroup = 5u,
	NotLeader = 6u,
	PlayerWrongFaction = 7u,
	IgnoringYou = 8u
}
