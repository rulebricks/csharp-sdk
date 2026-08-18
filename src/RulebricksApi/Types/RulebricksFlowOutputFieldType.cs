using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(RulebricksFlowOutputFieldType.RulebricksFlowOutputFieldTypeSerializer))]
[Serializable]
public readonly record struct RulebricksFlowOutputFieldType : IStringEnum
{
    public static readonly RulebricksFlowOutputFieldType String = new(Values.String);

    public static readonly RulebricksFlowOutputFieldType Number = new(Values.Number);

    public static readonly RulebricksFlowOutputFieldType Boolean = new(Values.Boolean);

    public static readonly RulebricksFlowOutputFieldType List = new(Values.List);

    public static readonly RulebricksFlowOutputFieldType Object = new(Values.Object);

    public static readonly RulebricksFlowOutputFieldType Date = new(Values.Date);

    public static readonly RulebricksFlowOutputFieldType Any = new(Values.Any);

    public RulebricksFlowOutputFieldType(string value)
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
    public static RulebricksFlowOutputFieldType FromCustom(string value)
    {
        return new RulebricksFlowOutputFieldType(value);
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

    public static bool operator ==(RulebricksFlowOutputFieldType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RulebricksFlowOutputFieldType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RulebricksFlowOutputFieldType value) => value.Value;

    public static explicit operator RulebricksFlowOutputFieldType(string value) => new(value);

    internal class RulebricksFlowOutputFieldTypeSerializer
        : JsonConverter<RulebricksFlowOutputFieldType>
    {
        public override RulebricksFlowOutputFieldType Read(
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
            return new RulebricksFlowOutputFieldType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RulebricksFlowOutputFieldType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RulebricksFlowOutputFieldType ReadAsPropertyName(
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
            return new RulebricksFlowOutputFieldType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RulebricksFlowOutputFieldType value,
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

        public const string List = "list";

        public const string Object = "object";

        public const string Date = "date";

        public const string Any = "any";
    }
}
