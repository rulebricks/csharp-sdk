using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(ValueReferenceRb.ValueReferenceRbSerializer))]
[Serializable]
public readonly record struct ValueReferenceRb : IStringEnum
{
    public static readonly ValueReferenceRb GlobalValue = new(Values.GlobalValue);

    public ValueReferenceRb(string value)
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
    public static ValueReferenceRb FromCustom(string value)
    {
        return new ValueReferenceRb(value);
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

    public static bool operator ==(ValueReferenceRb value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ValueReferenceRb value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ValueReferenceRb value) => value.Value;

    public static explicit operator ValueReferenceRb(string value) => new(value);

    internal class ValueReferenceRbSerializer : JsonConverter<ValueReferenceRb>
    {
        public override ValueReferenceRb Read(
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
            return new ValueReferenceRb(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ValueReferenceRb value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ValueReferenceRb ReadAsPropertyName(
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
            return new ValueReferenceRb(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ValueReferenceRb value,
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
        public const string GlobalValue = "globalValue";
    }
}
