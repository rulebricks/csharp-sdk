using RulebricksApi.Forge.Types;

namespace RulebricksApi
{
    public static class DynamicValueTypeExtensions
    {
        public static DynamicValueType ToDynamicValueType(this ListDynamicValuesResponseItemType type)
        {
            return type switch
            {
                ListDynamicValuesResponseItemType.String => DynamicValueType.String,
                ListDynamicValuesResponseItemType.Number => DynamicValueType.Number,
                ListDynamicValuesResponseItemType.Boolean => DynamicValueType.Boolean,
                ListDynamicValuesResponseItemType.Date => DynamicValueType.Date,
                ListDynamicValuesResponseItemType.List => DynamicValueType.List,
                ListDynamicValuesResponseItemType.Object => DynamicValueType.Object,
                _ => throw new System.ArgumentException($"Unknown type: {type}")
            };
        }
    }
}
