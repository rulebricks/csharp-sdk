using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(ImportManifestPreviewResponsePreviewItemsItemType.ImportManifestPreviewResponsePreviewItemsItemTypeSerializer)
)]
[Serializable]
public readonly record struct ImportManifestPreviewResponsePreviewItemsItemType : IStringEnum
{
    public static readonly ImportManifestPreviewResponsePreviewItemsItemType Context = new(
        Values.Context
    );

    public static readonly ImportManifestPreviewResponsePreviewItemsItemType Relationship = new(
        Values.Relationship
    );

    public static readonly ImportManifestPreviewResponsePreviewItemsItemType Value = new(
        Values.Value
    );

    public static readonly ImportManifestPreviewResponsePreviewItemsItemType Rule = new(
        Values.Rule
    );

    public static readonly ImportManifestPreviewResponsePreviewItemsItemType Flow = new(
        Values.Flow
    );

    public ImportManifestPreviewResponsePreviewItemsItemType(string value)
    {
        Value_ = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    string IStringEnum.Value => Value_;

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value_ { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static ImportManifestPreviewResponsePreviewItemsItemType FromCustom(string value)
    {
        return new ImportManifestPreviewResponsePreviewItemsItemType(value);
    }

    public bool Equals(string? other)
    {
        return Value_.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value_;
    }

    public static bool operator ==(
        ImportManifestPreviewResponsePreviewItemsItemType value1,
        string value2
    ) => value1.Value_.Equals(value2);

    public static bool operator !=(
        ImportManifestPreviewResponsePreviewItemsItemType value1,
        string value2
    ) => !value1.Value_.Equals(value2);

    public static explicit operator string(
        ImportManifestPreviewResponsePreviewItemsItemType value
    ) => value.Value_;

    public static explicit operator ImportManifestPreviewResponsePreviewItemsItemType(
        string value
    ) => new(value);

    internal class ImportManifestPreviewResponsePreviewItemsItemTypeSerializer
        : JsonConverter<ImportManifestPreviewResponsePreviewItemsItemType>
    {
        public override ImportManifestPreviewResponsePreviewItemsItemType Read(
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
            return new ImportManifestPreviewResponsePreviewItemsItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ImportManifestPreviewResponsePreviewItemsItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value_);
        }

        public override ImportManifestPreviewResponsePreviewItemsItemType ReadAsPropertyName(
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
            return new ImportManifestPreviewResponsePreviewItemsItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ImportManifestPreviewResponsePreviewItemsItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value_);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Context = "context";

        public const string Relationship = "relationship";

        public const string Value = "value";

        public const string Rule = "rule";

        public const string Flow = "flow";
    }
}
