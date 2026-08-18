using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(QueryDecisionsRequestOrder.QueryDecisionsRequestOrderSerializer))]
[Serializable]
public readonly record struct QueryDecisionsRequestOrder : IStringEnum
{
    public static readonly QueryDecisionsRequestOrder Asc = new(Values.Asc);

    public static readonly QueryDecisionsRequestOrder Desc = new(Values.Desc);

    public QueryDecisionsRequestOrder(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static QueryDecisionsRequestOrder FromCustom(string value)
    {
        return new QueryDecisionsRequestOrder(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(QueryDecisionsRequestOrder value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(QueryDecisionsRequestOrder value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(QueryDecisionsRequestOrder value) => value.Value;

    public static explicit operator QueryDecisionsRequestOrder(string value) => new(value);

    internal class QueryDecisionsRequestOrderSerializer : JsonConverter<QueryDecisionsRequestOrder>
    {
        public override QueryDecisionsRequestOrder Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new QueryDecisionsRequestOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            QueryDecisionsRequestOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override QueryDecisionsRequestOrder ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new QueryDecisionsRequestOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            QueryDecisionsRequestOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Asc = "asc";

        public const string Desc = "desc";
    }
}
