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
                ListDynamicValuesResponseItemType.List => DynamicValueType.List,
                _ => DynamicValueType.String // Default to string for unknown types
            };
        }
    }
}
