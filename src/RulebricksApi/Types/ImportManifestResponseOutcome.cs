using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(ImportManifestResponseOutcome.ImportManifestResponseOutcomeSerializer))]
[Serializable]
public readonly record struct ImportManifestResponseOutcome : IStringEnum
{
    public static readonly ImportManifestResponseOutcome Complete = new(Values.Complete);

    public static readonly ImportManifestResponseOutcome Partial = new(Values.Partial);

    public static readonly ImportManifestResponseOutcome Rejected = new(Values.Rejected);

    public ImportManifestResponseOutcome(string value)
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
    public static ImportManifestResponseOutcome FromCustom(string value)
    {
        return new ImportManifestResponseOutcome(value);
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

    public static bool operator ==(ImportManifestResponseOutcome value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ImportManifestResponseOutcome value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ImportManifestResponseOutcome value) => value.Value;

    public static explicit operator ImportManifestResponseOutcome(string value) => new(value);

    internal class ImportManifestResponseOutcomeSerializer
        : JsonConverter<ImportManifestResponseOutcome>
    {
        public override ImportManifestResponseOutcome Read(
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
            return new ImportManifestResponseOutcome(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ImportManifestResponseOutcome value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ImportManifestResponseOutcome ReadAsPropertyName(
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
            return new ImportManifestResponseOutcome(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ImportManifestResponseOutcome value,
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
        public const string Complete = "complete";

        public const string Partial = "partial";

        public const string Rejected = "rejected";
    }
}
