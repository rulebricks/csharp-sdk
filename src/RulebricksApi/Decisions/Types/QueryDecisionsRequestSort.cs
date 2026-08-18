using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(QueryDecisionsRequestSort.QueryDecisionsRequestSortSerializer))]
[Serializable]
public readonly record struct QueryDecisionsRequestSort : IStringEnum
{
    public static readonly QueryDecisionsRequestSort Time = new(Values.Time);

    public static readonly QueryDecisionsRequestSort Name = new(Values.Name);

    public static readonly QueryDecisionsRequestSort Status = new(Values.Status);

    public static readonly QueryDecisionsRequestSort Type = new(Values.Type);

    public QueryDecisionsRequestSort(string value)
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
    public static QueryDecisionsRequestSort FromCustom(string value)
    {
        return new QueryDecisionsRequestSort(value);
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

    public static bool operator ==(QueryDecisionsRequestSort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(QueryDecisionsRequestSort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(QueryDecisionsRequestSort value) => value.Value;

    public static explicit operator QueryDecisionsRequestSort(string value) => new(value);

    internal class QueryDecisionsRequestSortSerializer : JsonConverter<QueryDecisionsRequestSort>
    {
        public override QueryDecisionsRequestSort Read(
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
            return new QueryDecisionsRequestSort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            QueryDecisionsRequestSort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override QueryDecisionsRequestSort ReadAsPropertyName(
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
            return new QueryDecisionsRequestSort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            QueryDecisionsRequestSort value,
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
        public const string Time = "time";

        public const string Name = "name";

        public const string Status = "status";

        public const string Type = "type";
    }
}
