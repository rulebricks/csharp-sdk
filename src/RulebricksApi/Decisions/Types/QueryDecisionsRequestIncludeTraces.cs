using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(QueryDecisionsRequestIncludeTraces.QueryDecisionsRequestIncludeTracesSerializer)
)]
[Serializable]
public readonly record struct QueryDecisionsRequestIncludeTraces : IStringEnum
{
    public static readonly QueryDecisionsRequestIncludeTraces True = new(Values.True);

    public static readonly QueryDecisionsRequestIncludeTraces False = new(Values.False);

    public QueryDecisionsRequestIncludeTraces(string value)
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
    public static QueryDecisionsRequestIncludeTraces FromCustom(string value)
    {
        return new QueryDecisionsRequestIncludeTraces(value);
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

    public static bool operator ==(QueryDecisionsRequestIncludeTraces value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(QueryDecisionsRequestIncludeTraces value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(QueryDecisionsRequestIncludeTraces value) => value.Value;

    public static explicit operator QueryDecisionsRequestIncludeTraces(string value) => new(value);

    internal class QueryDecisionsRequestIncludeTracesSerializer
        : JsonConverter<QueryDecisionsRequestIncludeTraces>
    {
        public override QueryDecisionsRequestIncludeTraces Read(
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
            return new QueryDecisionsRequestIncludeTraces(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            QueryDecisionsRequestIncludeTraces value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override QueryDecisionsRequestIncludeTraces ReadAsPropertyName(
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
            return new QueryDecisionsRequestIncludeTraces(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            QueryDecisionsRequestIncludeTraces value,
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
