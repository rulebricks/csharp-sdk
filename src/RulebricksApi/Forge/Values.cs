using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RulebricksApi.Forge.Types;

namespace RulebricksApi.Forge
{
    public class DynamicValue
    {
        public string Id { get; }
        public string Name { get; }
        public DynamicValueType ValueType { get; }

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
                { "name", Name },
                { "type", new Dictionary<string, string> { { "value", ValueType.ToString().ToLower() } } }
            };
        }

        public override string ToString()
        {
            return $"DynamicValue(id={Id}, name={Name}, type={ValueType})";
        }
    }

    public static class DynamicValues
    {
        private static RulebricksApiClient _workspace;
        private static readonly Dictionary<string, DynamicValue> _cache = new Dictionary<string, DynamicValue>();

        public static void Configure(RulebricksApiClient client)
        {
            _workspace = client;
            _cache.Clear();
        }

        public static async Task<DynamicValue> Get(string name)
        {
            if (_workspace == null)
            {
                throw new InvalidOperationException("Workspace not configured. Call Configure() first.");
            }

            if (_cache.TryGetValue(name, out var cachedValue))
            {
                return cachedValue;
            }

            var values = await _workspace.Values.ListDynamicValues();
            var value = values.Find(v => v.Name == name);

            if (value == null)
            {
                throw new DynamicValueNotFoundException($"Dynamic value '{name}' not found");
            }

            var dynamicValue = new DynamicValue(
                value.Id,
                value.Name,
                Enum.Parse<DynamicValueType>(value.Type.Value, true)
            );

            _cache[name] = dynamicValue;
            return dynamicValue;
        }

        public static async Task Set(Dictionary<string, object> dynamicValues)
        {
            if (_workspace == null)
            {
                throw new InvalidOperationException("Workspace not configured. Call Configure() first.");
            }

            await _workspace.Values.Update(new { request = dynamicValues });
            _cache.Clear();
        }

        public static void ClearCache()
        {
            _cache.Clear();
        }
    }
}
