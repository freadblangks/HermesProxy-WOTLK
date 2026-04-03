namespace HermesProxy.World.Enums;

public enum TalentLearnResult
{
	LearnOk = 0,
	FailedUnknown = 1,
	FailedNotEnoughTalentsInPrimaryTree = 2,
	FailedNoPrimaryTreeSelected = 3,
	FailedCantDoThatRightNow = 4,
	FailedAffectingCombat = 5,
	FailedCantRemoveTalent = 6,
	FailedCantDoThatChallengeModeActive = 7,
	FailedRestArea = 8
}
