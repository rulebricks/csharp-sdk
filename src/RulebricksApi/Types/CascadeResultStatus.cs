using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(CascadeResultStatus.CascadeResultStatusSerializer))]
[Serializable]
public readonly record struct CascadeResultStatus : IStringEnum
{
    public static readonly CascadeResultStatus Solved = new(Values.Solved);

    public static readonly CascadeResultStatus Error = new(Values.Error);

    public static readonly CascadeResultStatus Pending = new(Values.Pending);

    public static readonly CascadeResultStatus SkippedAlreadyRun = new(Values.SkippedAlreadyRun);

    public CascadeResultStatus(string value)
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
    public static CascadeResultStatus FromCustom(string value)
    {
        return new CascadeResultStatus(value);
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

    public static bool operator ==(CascadeResultStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CascadeResultStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CascadeResultStatus value) => value.Value;

    public static explicit operator CascadeResultStatus(string value) => new(value);

    internal class CascadeResultStatusSerializer : JsonConverter<CascadeResultStatus>
    {
        public override CascadeResultStatus Read(
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
            return new CascadeResultStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CascadeResultStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CascadeResultStatus ReadAsPropertyName(
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
            return new CascadeResultStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CascadeResultStatus value,
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
        public const string Solved = "solved";

        public const string Error = "error";

        public const string Pending = "pending";

        public const string SkippedAlreadyRun = "skipped_already_run";
    }
}
