using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(ImportManifestPreviewResponsePreviewPolicy.ImportManifestPreviewResponsePreviewPolicySerializer)
)]
[Serializable]
public readonly record struct ImportManifestPreviewResponsePreviewPolicy : IStringEnum
{
    public static readonly ImportManifestPreviewResponsePreviewPolicy Override = new(
        Values.Override
    );

    public static readonly ImportManifestPreviewResponsePreviewPolicy Preserve = new(
        Values.Preserve
    );

    public static readonly ImportManifestPreviewResponsePreviewPolicy Block = new(Values.Block);

    public ImportManifestPreviewResponsePreviewPolicy(string value)
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
    public static ImportManifestPreviewResponsePreviewPolicy FromCustom(string value)
    {
        return new ImportManifestPreviewResponsePreviewPolicy(value);
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
        ImportManifestPreviewResponsePreviewPolicy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ImportManifestPreviewResponsePreviewPolicy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ImportManifestPreviewResponsePreviewPolicy value) =>
        value.Value;

    public static explicit operator ImportManifestPreviewResponsePreviewPolicy(string value) =>
        new(value);

    internal class ImportManifestPreviewResponsePreviewPolicySerializer
        : JsonConverter<ImportManifestPreviewResponsePreviewPolicy>
    {
        public override ImportManifestPreviewResponsePreviewPolicy Read(
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
            return new ImportManifestPreviewResponsePreviewPolicy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ImportManifestPreviewResponsePreviewPolicy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ImportManifestPreviewResponsePreviewPolicy ReadAsPropertyName(
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
            return new ImportManifestPreviewResponsePreviewPolicy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ImportManifestPreviewResponsePreviewPolicy value,
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
