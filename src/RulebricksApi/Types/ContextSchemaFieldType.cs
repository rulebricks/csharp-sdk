using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<ContextSchemaFieldType>))]
[Serializable]
public readonly record struct ContextSchemaFieldType : IStringEnum
{
    public static readonly ContextSchemaFieldType String = new(Values.String);

    public static readonly ContextSchemaFieldType Number = new(Values.Number);

    public static readonly ContextSchemaFieldType Boolean = new(Values.Boolean);

    public static readonly ContextSchemaFieldType Date = new(Values.Date);

    public static readonly ContextSchemaFieldType List = new(Values.List);

    public static readonly ContextSchemaFieldType Function = new(Values.Function);

    public ContextSchemaFieldType(string value)
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
    public static ContextSchemaFieldType FromCustom(string value)
    {
        return new ContextSchemaFieldType(value);
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

    public static bool operator ==(ContextSchemaFieldType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContextSchemaFieldType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContextSchemaFieldType value) => value.Value;

    public static explicit operator ContextSchemaFieldType(string value) => new(value);

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

        public const string Function = "function";
    }
}
