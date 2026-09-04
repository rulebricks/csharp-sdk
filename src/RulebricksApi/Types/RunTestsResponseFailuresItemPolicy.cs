using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(RunTestsResponseFailuresItemPolicy.RunTestsResponseFailuresItemPolicySerializer)
)]
[Serializable]
public readonly record struct RunTestsResponseFailuresItemPolicy : IStringEnum
{
    public static readonly RunTestsResponseFailuresItemPolicy Contains = new(Values.Contains);

    public static readonly RunTestsResponseFailuresItemPolicy Matches = new(Values.Matches);

    public static readonly RunTestsResponseFailuresItemPolicy Excludes = new(Values.Excludes);

    public RunTestsResponseFailuresItemPolicy(string value)
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
    public static RunTestsResponseFailuresItemPolicy FromCustom(string value)
    {
        return new RunTestsResponseFailuresItemPolicy(value);
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

    public static bool operator ==(RunTestsResponseFailuresItemPolicy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RunTestsResponseFailuresItemPolicy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RunTestsResponseFailuresItemPolicy value) => value.Value;

    public static explicit operator RunTestsResponseFailuresItemPolicy(string value) => new(value);

    internal class RunTestsResponseFailuresItemPolicySerializer
        : JsonConverter<RunTestsResponseFailuresItemPolicy>
    {
        public override RunTestsResponseFailuresItemPolicy Read(
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
            return new RunTestsResponseFailuresItemPolicy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RunTestsResponseFailuresItemPolicy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RunTestsResponseFailuresItemPolicy ReadAsPropertyName(
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
            return new RunTestsResponseFailuresItemPolicy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RunTestsResponseFailuresItemPolicy value,
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
