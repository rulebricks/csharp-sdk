using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using RulebricksApi.Forge.Types;

namespace RulebricksApi.Forge
{
    public class DynamicValue
    {
        public string Id { get; }
        public string Name { get; }
        public DynamicValueType ValueType { get; }
        private readonly string _rbType = "globalValue";

        public DynamicValue(string id, string name, DynamicValueType valueType)
        {
            Id = id;
            Name = name;
            ValueType = valueType;
        }

        public Dictionary<string, object> ToDict()
        {
            return new Dictionary<string, object>
            {
                { "id", Id },
                { "$rb", _rbType },
                { "name", Name }
            };
        }

        public static Type GetExpectedType(DynamicValueType valueType)
        {
            var typeMapping = new Dictionary<DynamicValueType, Type>
            {
                { DynamicValueType.String, typeof(string) },
                { DynamicValueType.Number, typeof(double) },
                { DynamicValueType.Boolean, typeof(bool) },
                { DynamicValueType.Date, typeof(DateTime) },
                { DynamicValueType.List, typeof(List<object>) },
                { DynamicValueType.Object, typeof(Dictionary<string, object>) }
            };
            return typeMapping[valueType];
        }

        public override string ToString()
        {
            return $"<{Name.ToUpper()}>";
        }
    }

    public static class DynamicValues
    {
        private static RulebricksApiClient _workspace;
        private static readonly Dictionary<string, DynamicValue> _cache = new();

        public static void Configure(RulebricksApiClient client)
        {
            _workspace = client;
            _cache.Clear();
        }

        public static async Task<DynamicValue> Get(string name)
        {
            if (_workspace == null)
            {
                throw new InvalidOperationException("DynamicValues not configured. Call Configure() first.");
            }

            if (_cache.TryGetValue(name, out var cachedValue))
            {
                return cachedValue;
            }

            var values = await _workspace.Values.ListDynamicValuesAsync(new ListDynamicValuesRequest { Name = name });
            var value = values.FirstOrDefault(v => v.Name == name);

            if (value == null)
            {
                throw new DynamicValueNotFoundError($"Dynamic value '{name}' not found");
            }

            var dynamicValue = new DynamicValue(
                value.Id,
                value.Name,
                value.Type.Value.ToDynamicValueType()
            );

            _cache[name] = dynamicValue;
            return dynamicValue;
        }

        public static async Task Set(Dictionary<string, object> dynamicValues)
        {
            if (_workspace == null)
            {
                throw new InvalidOperationException("DynamicValues not configured. Call Configure() first.");
            }

            var request = dynamicValues.ToDictionary(
                kvp => kvp.Key,
                kvp => OneOf.OneOf<string, double, bool, IEnumerable<object>>.FromT0(kvp.Value.ToString())
            );

            await _workspace.Values.UpdateAsync(request);
            _cache.Clear();
        }

        public static void ClearCache()
        {
            _cache.Clear();
        }
    }
}
