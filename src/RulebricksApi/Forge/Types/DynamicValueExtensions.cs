using System;

namespace RulebricksApi.Forge.Types
{
    public static class DynamicValueExtensions
    {
        public static Type GetExpectedType(this DynamicValueType valueType)
        {
            return valueType switch
            {
                DynamicValueType.String => typeof(string),
                DynamicValueType.Number => typeof(double),
                DynamicValueType.Boolean => typeof(bool),
                DynamicValueType.Date => typeof(DateTime),
                DynamicValueType.List => typeof(System.Collections.Generic.List<object>),
                DynamicValueType.Object => typeof(object),
                _ => throw new ArgumentException($"Unknown value type: {valueType}")
            };
        }
    }
}
