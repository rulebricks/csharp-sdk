using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(RulebricksFlowNodeOutputsItemType.RulebricksFlowNodeOutputsItemTypeSerializer)
)]
[Serializable]
public readonly record struct RulebricksFlowNodeOutputsItemType : IStringEnum
{
    public static readonly RulebricksFlowNodeOutputsItemType String = new(Values.String);

    public static readonly RulebricksFlowNodeOutputsItemType Number = new(Values.Number);

    public static readonly RulebricksFlowNodeOutputsItemType Boolean = new(Values.Boolean);

    public static readonly RulebricksFlowNodeOutputsItemType List = new(Values.List);

    public static readonly RulebricksFlowNodeOutputsItemType Object = new(Values.Object);

    public static readonly RulebricksFlowNodeOutputsItemType Date = new(Values.Date);

    public static readonly RulebricksFlowNodeOutputsItemType Any = new(Values.Any);

    public RulebricksFlowNodeOutputsItemType(string value)
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
    public static RulebricksFlowNodeOutputsItemType FromCustom(string value)
    {
        return new RulebricksFlowNodeOutputsItemType(value);
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

    public static bool operator ==(RulebricksFlowNodeOutputsItemType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RulebricksFlowNodeOutputsItemType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RulebricksFlowNodeOutputsItemType value) => value.Value;

    public static explicit operator RulebricksFlowNodeOutputsItemType(string value) => new(value);

    internal class RulebricksFlowNodeOutputsItemTypeSerializer
        : JsonConverter<RulebricksFlowNodeOutputsItemType>
    {
        public override RulebricksFlowNodeOutputsItemType Read(
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
            return new RulebricksFlowNodeOutputsItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RulebricksFlowNodeOutputsItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RulebricksFlowNodeOutputsItemType ReadAsPropertyName(
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
            return new RulebricksFlowNodeOutputsItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RulebricksFlowNodeOutputsItemType value,
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
