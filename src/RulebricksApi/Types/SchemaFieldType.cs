using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(SchemaFieldType.SchemaFieldTypeSerializer))]
[Serializable]
public readonly record struct SchemaFieldType : IStringEnum
{
    public static readonly SchemaFieldType String = new(Values.String);

    public static readonly SchemaFieldType Number = new(Values.Number);

    public static readonly SchemaFieldType Boolean = new(Values.Boolean);

    public static readonly SchemaFieldType Object = new(Values.Object);

    public static readonly SchemaFieldType Array = new(Values.Array);

    public SchemaFieldType(string value)
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
    public static SchemaFieldType FromCustom(string value)
    {
        return new SchemaFieldType(value);
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

    public static bool operator ==(SchemaFieldType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SchemaFieldType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SchemaFieldType value) => value.Value;

    public static explicit operator SchemaFieldType(string value) => new(value);

    internal class SchemaFieldTypeSerializer : JsonConverter<SchemaFieldType>
    {
        public override SchemaFieldType Read(
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
            return new SchemaFieldType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SchemaFieldType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SchemaFieldType ReadAsPropertyName(
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
            return new SchemaFieldType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SchemaFieldType value,
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
        public const string String = "string";

        public const string Number = "number";

        public const string Boolean = "boolean";

        public const string Object = "object";

        public const string Array = "array";
    }
}
