using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(RuleImportSchemaFieldType.RuleImportSchemaFieldTypeSerializer))]
[Serializable]
public readonly record struct RuleImportSchemaFieldType : IStringEnum
{
    public static readonly RuleImportSchemaFieldType String = new(Values.String);

    public static readonly RuleImportSchemaFieldType Number = new(Values.Number);

    public static readonly RuleImportSchemaFieldType Boolean = new(Values.Boolean);

    public static readonly RuleImportSchemaFieldType Date = new(Values.Date);

    public static readonly RuleImportSchemaFieldType List = new(Values.List);

    public static readonly RuleImportSchemaFieldType Object = new(Values.Object);

    public static readonly RuleImportSchemaFieldType Function = new(Values.Function);

    public RuleImportSchemaFieldType(string value)
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
    public static RuleImportSchemaFieldType FromCustom(string value)
    {
        return new RuleImportSchemaFieldType(value);
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

    public static bool operator ==(RuleImportSchemaFieldType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RuleImportSchemaFieldType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RuleImportSchemaFieldType value) => value.Value;

    public static explicit operator RuleImportSchemaFieldType(string value) => new(value);

    internal class RuleImportSchemaFieldTypeSerializer : JsonConverter<RuleImportSchemaFieldType>
    {
        public override RuleImportSchemaFieldType Read(
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
            return new RuleImportSchemaFieldType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RuleImportSchemaFieldType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RuleImportSchemaFieldType ReadAsPropertyName(
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
            return new RuleImportSchemaFieldType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RuleImportSchemaFieldType value,
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

        public const string Date = "date";

        public const string List = "list";

        public const string Object = "object";

        public const string Function = "function";
    }
}
