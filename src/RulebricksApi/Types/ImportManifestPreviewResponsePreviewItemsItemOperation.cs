using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(ImportManifestPreviewResponsePreviewItemsItemOperation.ImportManifestPreviewResponsePreviewItemsItemOperationSerializer)
)]
[Serializable]
public readonly record struct ImportManifestPreviewResponsePreviewItemsItemOperation : IStringEnum
{
    public static readonly ImportManifestPreviewResponsePreviewItemsItemOperation Create = new(
        Values.Create
    );

    public static readonly ImportManifestPreviewResponsePreviewItemsItemOperation Replace = new(
        Values.Replace
    );

    public static readonly ImportManifestPreviewResponsePreviewItemsItemOperation Reuse = new(
        Values.Reuse
    );

    public static readonly ImportManifestPreviewResponsePreviewItemsItemOperation Omit = new(
        Values.Omit
    );

    public static readonly ImportManifestPreviewResponsePreviewItemsItemOperation Reject = new(
        Values.Reject
    );

    public static readonly ImportManifestPreviewResponsePreviewItemsItemOperation Blocked = new(
        Values.Blocked
    );

    public ImportManifestPreviewResponsePreviewItemsItemOperation(string value)
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
    public static ImportManifestPreviewResponsePreviewItemsItemOperation FromCustom(string value)
    {
        return new ImportManifestPreviewResponsePreviewItemsItemOperation(value);
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
        ImportManifestPreviewResponsePreviewItemsItemOperation value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ImportManifestPreviewResponsePreviewItemsItemOperation value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ImportManifestPreviewResponsePreviewItemsItemOperation value
    ) => value.Value;

    public static explicit operator ImportManifestPreviewResponsePreviewItemsItemOperation(
        string value
    ) => new(value);

    internal class ImportManifestPreviewResponsePreviewItemsItemOperationSerializer
        : JsonConverter<ImportManifestPreviewResponsePreviewItemsItemOperation>
    {
        public override ImportManifestPreviewResponsePreviewItemsItemOperation Read(
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
            return new ImportManifestPreviewResponsePreviewItemsItemOperation(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ImportManifestPreviewResponsePreviewItemsItemOperation value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ImportManifestPreviewResponsePreviewItemsItemOperation ReadAsPropertyName(
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
            return new ImportManifestPreviewResponsePreviewItemsItemOperation(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ImportManifestPreviewResponsePreviewItemsItemOperation value,
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
        public const string Create = "create";

        public const string Replace = "replace";

        public const string Reuse = "reuse";

        public const string Omit = "omit";

        public const string Reject = "reject";

        public const string Blocked = "blocked";
    }
}
