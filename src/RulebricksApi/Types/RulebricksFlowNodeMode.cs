using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(RulebricksFlowNodeMode.RulebricksFlowNodeModeSerializer))]
[Serializable]
public readonly record struct RulebricksFlowNodeMode : IStringEnum
{
    public static readonly RulebricksFlowNodeMode Fields = new(Values.Fields);

    public static readonly RulebricksFlowNodeMode Items = new(Values.Items);

    public RulebricksFlowNodeMode(string value)
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
    public static RulebricksFlowNodeMode FromCustom(string value)
    {
        return new RulebricksFlowNodeMode(value);
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

    public static bool operator ==(RulebricksFlowNodeMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RulebricksFlowNodeMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RulebricksFlowNodeMode value) => value.Value;

    public static explicit operator RulebricksFlowNodeMode(string value) => new(value);

    internal class RulebricksFlowNodeModeSerializer : JsonConverter<RulebricksFlowNodeMode>
    {
        public override RulebricksFlowNodeMode Read(
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
            return new RulebricksFlowNodeMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RulebricksFlowNodeMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RulebricksFlowNodeMode ReadAsPropertyName(
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
            return new RulebricksFlowNodeMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RulebricksFlowNodeMode value,
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
        public const string Fields = "fields";

        public const string Items = "items";
    }
}
