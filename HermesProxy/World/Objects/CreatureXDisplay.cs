namespace HermesProxy.World.Objects;

public class CreatureXDisplay
{
	public uint CreatureDisplayID;

	public float Scale = 1f;

	public float Probability = 1f;

	public CreatureXDisplay(uint creatureDisplayID, float displayScale, float probability)
	{
		this.CreatureDisplayID = creatureDisplayID;
		this.Scale = displayScale;
		this.Probability = probability;
	}
}
