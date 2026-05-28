using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(QueryDecisionsRequestCount.QueryDecisionsRequestCountSerializer))]
[Serializable]
public readonly record struct QueryDecisionsRequestCount : IStringEnum
{
    public static readonly QueryDecisionsRequestCount True = new(Values.True);

    public static readonly QueryDecisionsRequestCount False = new(Values.False);

    public QueryDecisionsRequestCount(string value)
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
    public static QueryDecisionsRequestCount FromCustom(string value)
    {
        return new QueryDecisionsRequestCount(value);
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

    public static bool operator ==(QueryDecisionsRequestCount value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(QueryDecisionsRequestCount value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(QueryDecisionsRequestCount value) => value.Value;

    public static explicit operator QueryDecisionsRequestCount(string value) => new(value);

    internal class QueryDecisionsRequestCountSerializer : JsonConverter<QueryDecisionsRequestCount>
    {
        public override QueryDecisionsRequestCount Read(
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
            return new QueryDecisionsRequestCount(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            QueryDecisionsRequestCount value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override QueryDecisionsRequestCount ReadAsPropertyName(
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
            return new QueryDecisionsRequestCount(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            QueryDecisionsRequestCount value,
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
        public const string True = "true";

        public const string False = "false";
    }
}
