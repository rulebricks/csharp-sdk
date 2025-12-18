using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<SchemaFieldType>))]
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
