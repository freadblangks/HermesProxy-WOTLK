namespace HermesProxy.World.Enums;

public enum ObjectField
{
	[UpdateField(UpdateFieldType.Guid)]
	OBJECT_FIELD_GUID = 0,
	[UpdateField(UpdateFieldType.Uint)]
	OBJECT_FIELD_TYPE = 1,
	[UpdateField(UpdateFieldType.Uint)]
	OBJECT_FIELD_ENTRY = 2,
	[UpdateField(UpdateFieldType.Float)]
	OBJECT_FIELD_SCALE_X = 3,
	OBJECT_FIELD_PADDING = 4,
	OBJECT_DYNAMIC_FLAGS = 5,
	OBJECT_END = 6,
	OBJECT_FIELD_DATA = 7
}
