namespace HermesProxy.World.Enums;

public enum ContainerField
{
	CONTAINER_ALIGN_PAD = 0,
	CONTAINER_END = 1,
	CONTAINER_FIELD_NUM_SLOTS = 2,
	[UpdateField(UpdateFieldType.Guid)]
	CONTAINER_FIELD_SLOT_1 = 3
}
