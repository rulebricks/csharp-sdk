using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(ContextDerivedFieldType.ContextDerivedFieldTypeSerializer))]
[Serializable]
public readonly record struct ContextDerivedFieldType : IStringEnum
{
    public static readonly ContextDerivedFieldType String = new(Values.String);

    public static readonly ContextDerivedFieldType Number = new(Values.Number);

    public static readonly ContextDerivedFieldType Boolean = new(Values.Boolean);

    public static readonly ContextDerivedFieldType List = new(Values.List);

    public static readonly ContextDerivedFieldType Date = new(Values.Date);

    public ContextDerivedFieldType(string value)
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
    public static ContextDerivedFieldType FromCustom(string value)
    {
        return new ContextDerivedFieldType(value);
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

    public static bool operator ==(ContextDerivedFieldType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContextDerivedFieldType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContextDerivedFieldType value) => value.Value;

    public static explicit operator ContextDerivedFieldType(string value) => new(value);

    internal class ContextDerivedFieldTypeSerializer : JsonConverter<ContextDerivedFieldType>
    {
        public override ContextDerivedFieldType Read(
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
            return new ContextDerivedFieldType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContextDerivedFieldType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ContextDerivedFieldType ReadAsPropertyName(
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
            return new ContextDerivedFieldType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContextDerivedFieldType value,
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

        public const string Date = "date";
    }
}
