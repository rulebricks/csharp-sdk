using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<ContextBaseOnSchemaMismatch>))]
[Serializable]
public readonly record struct ContextBaseOnSchemaMismatch : IStringEnum
{
    public static readonly ContextBaseOnSchemaMismatch Ignore = new(Values.Ignore);

    public static readonly ContextBaseOnSchemaMismatch Reject = new(Values.Reject);

    public ContextBaseOnSchemaMismatch(string value)
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
    public static ContextBaseOnSchemaMismatch FromCustom(string value)
    {
        return new ContextBaseOnSchemaMismatch(value);
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

    public static bool operator ==(ContextBaseOnSchemaMismatch value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContextBaseOnSchemaMismatch value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContextBaseOnSchemaMismatch value) => value.Value;

    public static explicit operator ContextBaseOnSchemaMismatch(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Ignore = "ignore";

        public const string Reject = "reject";
    }
}
