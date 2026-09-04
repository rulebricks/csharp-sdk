using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(RunTestsResponseResultsItemPolicy.RunTestsResponseResultsItemPolicySerializer)
)]
[Serializable]
public readonly record struct RunTestsResponseResultsItemPolicy : IStringEnum
{
    public static readonly RunTestsResponseResultsItemPolicy Contains = new(Values.Contains);

    public static readonly RunTestsResponseResultsItemPolicy Matches = new(Values.Matches);

    public static readonly RunTestsResponseResultsItemPolicy Excludes = new(Values.Excludes);

    public RunTestsResponseResultsItemPolicy(string value)
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
    public static RunTestsResponseResultsItemPolicy FromCustom(string value)
    {
        return new RunTestsResponseResultsItemPolicy(value);
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

    public static bool operator ==(RunTestsResponseResultsItemPolicy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RunTestsResponseResultsItemPolicy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RunTestsResponseResultsItemPolicy value) => value.Value;

    public static explicit operator RunTestsResponseResultsItemPolicy(string value) => new(value);

    internal class RunTestsResponseResultsItemPolicySerializer
        : JsonConverter<RunTestsResponseResultsItemPolicy>
    {
        public override RunTestsResponseResultsItemPolicy Read(
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
            return new RunTestsResponseResultsItemPolicy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RunTestsResponseResultsItemPolicy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RunTestsResponseResultsItemPolicy ReadAsPropertyName(
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
            return new RunTestsResponseResultsItemPolicy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RunTestsResponseResultsItemPolicy value,
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
        public const string Contains = "contains";

        public const string Matches = "matches";

        public const string Excludes = "excludes";
    }
}
