using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<ContextInstancePendingEvaluationType>))]
[Serializable]
public readonly record struct ContextInstancePendingEvaluationType : IStringEnum
{
    public static readonly ContextInstancePendingEvaluationType Rule = new(Values.Rule);

    public static readonly ContextInstancePendingEvaluationType Flow = new(Values.Flow);

    public ContextInstancePendingEvaluationType(string value)
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
    public static ContextInstancePendingEvaluationType FromCustom(string value)
    {
        return new ContextInstancePendingEvaluationType(value);
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

    public static bool operator ==(ContextInstancePendingEvaluationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContextInstancePendingEvaluationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContextInstancePendingEvaluationType value) =>
        value.Value;

    public static explicit operator ContextInstancePendingEvaluationType(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Rule = "rule";

        public const string Flow = "flow";
    }
}
