using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using RulebricksApi.Forge.Types;
using RulebricksApi.Values.Types;

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
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
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
        private static RulebricksApiClient? _workspace;
        private static readonly Dictionary<string, DynamicValue> _cache = new();

        public static void Configure(RulebricksApiClient client)
        {
            _workspace = client ?? throw new ArgumentNullException(nameof(client));
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
                value.Type?.ToDynamicValueType() ?? throw new InvalidOperationException($"Dynamic value '{name}' has no type")
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

            var request = new Dictionary<string, UpdateRequestValue>();
            foreach (var kvp in dynamicValues)
            {
                var value = new UpdateRequestValue();
                switch (kvp.Value)
                {
                    case string s:
                        value.StringValue = s;
                        break;
                    case double d:
                        value.NumberValue = d;
                        break;
                    case bool b:
                        value.BooleanValue = b;
                        break;
                    case IEnumerable<object> list:
                        value.ListValue = list;
                        break;
                    default:
                        value.StringValue = kvp.Value?.ToString() ?? string.Empty;
                        break;
                }
                request[kvp.Key] = value;
            }

            await _workspace.Values.UpdateAsync(new UpdateRequest { Values = request });
            _cache.Clear();
        }

        public static void ClearCache()
        {
            _cache.Clear();
        }
    }
}
