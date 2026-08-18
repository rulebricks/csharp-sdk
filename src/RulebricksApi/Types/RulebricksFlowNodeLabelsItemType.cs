using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(RulebricksFlowNodeLabelsItemType.RulebricksFlowNodeLabelsItemTypeSerializer))]
[Serializable]
public readonly record struct RulebricksFlowNodeLabelsItemType : IStringEnum
{
    public static readonly RulebricksFlowNodeLabelsItemType String = new(Values.String);

    public static readonly RulebricksFlowNodeLabelsItemType Number = new(Values.Number);

    public static readonly RulebricksFlowNodeLabelsItemType Boolean = new(Values.Boolean);

    public static readonly RulebricksFlowNodeLabelsItemType List = new(Values.List);

    public static readonly RulebricksFlowNodeLabelsItemType Object = new(Values.Object);

    public static readonly RulebricksFlowNodeLabelsItemType Date = new(Values.Date);

    public static readonly RulebricksFlowNodeLabelsItemType Any = new(Values.Any);

    public RulebricksFlowNodeLabelsItemType(string value)
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
    public static RulebricksFlowNodeLabelsItemType FromCustom(string value)
    {
        return new RulebricksFlowNodeLabelsItemType(value);
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

    public static bool operator ==(RulebricksFlowNodeLabelsItemType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RulebricksFlowNodeLabelsItemType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RulebricksFlowNodeLabelsItemType value) => value.Value;

    public static explicit operator RulebricksFlowNodeLabelsItemType(string value) => new(value);

    internal class RulebricksFlowNodeLabelsItemTypeSerializer
        : JsonConverter<RulebricksFlowNodeLabelsItemType>
    {
        public override RulebricksFlowNodeLabelsItemType Read(
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
            return new RulebricksFlowNodeLabelsItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RulebricksFlowNodeLabelsItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RulebricksFlowNodeLabelsItemType ReadAsPropertyName(
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
            return new RulebricksFlowNodeLabelsItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RulebricksFlowNodeLabelsItemType value,
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
