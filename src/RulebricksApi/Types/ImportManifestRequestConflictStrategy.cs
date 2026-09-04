using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(ImportManifestRequestConflictStrategy.ImportManifestRequestConflictStrategySerializer)
)]
[Serializable]
public readonly record struct ImportManifestRequestConflictStrategy : IStringEnum
{
    public static readonly ImportManifestRequestConflictStrategy Override = new(Values.Override);

    public static readonly ImportManifestRequestConflictStrategy Preserve = new(Values.Preserve);

    public static readonly ImportManifestRequestConflictStrategy Block = new(Values.Block);

    public ImportManifestRequestConflictStrategy(string value)
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
    public static ImportManifestRequestConflictStrategy FromCustom(string value)
    {
        return new ImportManifestRequestConflictStrategy(value);
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

    public static bool operator ==(ImportManifestRequestConflictStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ImportManifestRequestConflictStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ImportManifestRequestConflictStrategy value) =>
        value.Value;

    public static explicit operator ImportManifestRequestConflictStrategy(string value) =>
        new(value);

    internal class ImportManifestRequestConflictStrategySerializer
        : JsonConverter<ImportManifestRequestConflictStrategy>
    {
        public override ImportManifestRequestConflictStrategy Read(
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
            return new ImportManifestRequestConflictStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ImportManifestRequestConflictStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ImportManifestRequestConflictStrategy ReadAsPropertyName(
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
            return new ImportManifestRequestConflictStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ImportManifestRequestConflictStrategy value,
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
        public const string Override = "override";

        public const string Preserve = "preserve";

        public const string Block = "block";
    }
}
