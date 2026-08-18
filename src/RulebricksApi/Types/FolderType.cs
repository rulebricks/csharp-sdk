using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(FolderType.FolderTypeSerializer))]
[Serializable]
public readonly record struct FolderType : IStringEnum
{
    public static readonly FolderType Rule = new(Values.Rule);

    public static readonly FolderType Flow = new(Values.Flow);

    public static readonly FolderType Context = new(Values.Context);

    public FolderType(string value)
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
    public static FolderType FromCustom(string value)
    {
        return new FolderType(value);
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

    public static bool operator ==(FolderType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(FolderType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FolderType value) => value.Value;

    public static explicit operator FolderType(string value) => new(value);

    internal class FolderTypeSerializer : JsonConverter<FolderType>
    {
        public override FolderType Read(
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
            return new FolderType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FolderType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FolderType ReadAsPropertyName(
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
            return new FolderType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FolderType value,
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
