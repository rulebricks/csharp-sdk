using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

[JsonConverter(typeof(UpsertFolderRequestType.UpsertFolderRequestTypeSerializer))]
[Serializable]
public readonly record struct UpsertFolderRequestType : IStringEnum
{
    public static readonly UpsertFolderRequestType Rule = new(Values.Rule);

    public static readonly UpsertFolderRequestType Flow = new(Values.Flow);

    public static readonly UpsertFolderRequestType Context = new(Values.Context);

    public UpsertFolderRequestType(string value)
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
    public static UpsertFolderRequestType FromCustom(string value)
    {
        return new UpsertFolderRequestType(value);
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

    public static bool operator ==(UpsertFolderRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpsertFolderRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpsertFolderRequestType value) => value.Value;

    public static explicit operator UpsertFolderRequestType(string value) => new(value);

    internal class UpsertFolderRequestTypeSerializer : JsonConverter<UpsertFolderRequestType>
    {
        public override UpsertFolderRequestType Read(
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
            return new UpsertFolderRequestType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpsertFolderRequestType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpsertFolderRequestType ReadAsPropertyName(
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
            return new UpsertFolderRequestType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpsertFolderRequestType value,
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
        public const string Rule = "rule";

        public const string Flow = "flow";

        public const string Context = "context";
    }
}
