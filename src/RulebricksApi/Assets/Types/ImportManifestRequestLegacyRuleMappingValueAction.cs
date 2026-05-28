using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(ImportManifestRequestLegacyRuleMappingValueAction.ImportManifestRequestLegacyRuleMappingValueActionSerializer)
)]
[Serializable]
public readonly record struct ImportManifestRequestLegacyRuleMappingValueAction : IStringEnum
{
    public static readonly ImportManifestRequestLegacyRuleMappingValueAction Reuse = new(
        Values.Reuse
    );

    public static readonly ImportManifestRequestLegacyRuleMappingValueAction Create = new(
        Values.Create
    );

    public ImportManifestRequestLegacyRuleMappingValueAction(string value)
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
    public static ImportManifestRequestLegacyRuleMappingValueAction FromCustom(string value)
    {
        return new ImportManifestRequestLegacyRuleMappingValueAction(value);
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

    public static bool operator ==(
        ImportManifestRequestLegacyRuleMappingValueAction value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ImportManifestRequestLegacyRuleMappingValueAction value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ImportManifestRequestLegacyRuleMappingValueAction value
    ) => value.Value;

    public static explicit operator ImportManifestRequestLegacyRuleMappingValueAction(
        string value
    ) => new(value);

    internal class ImportManifestRequestLegacyRuleMappingValueActionSerializer
        : JsonConverter<ImportManifestRequestLegacyRuleMappingValueAction>
    {
        public override ImportManifestRequestLegacyRuleMappingValueAction Read(
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
            return new ImportManifestRequestLegacyRuleMappingValueAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ImportManifestRequestLegacyRuleMappingValueAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ImportManifestRequestLegacyRuleMappingValueAction ReadAsPropertyName(
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
            return new ImportManifestRequestLegacyRuleMappingValueAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ImportManifestRequestLegacyRuleMappingValueAction value,
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
        public const string Reuse = "reuse";

        public const string Create = "create";
    }
}
