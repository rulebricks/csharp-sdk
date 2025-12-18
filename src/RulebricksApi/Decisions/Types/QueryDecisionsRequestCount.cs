using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<QueryDecisionsRequestCount>))]
[Serializable]
public readonly record struct QueryDecisionsRequestCount : IStringEnum
{
    public static readonly QueryDecisionsRequestCount True = new(Values.True);

    public static readonly QueryDecisionsRequestCount False = new(Values.False);

    public QueryDecisionsRequestCount(string value)
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
    public static QueryDecisionsRequestCount FromCustom(string value)
    {
        return new QueryDecisionsRequestCount(value);
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

    public static bool operator ==(QueryDecisionsRequestCount value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(QueryDecisionsRequestCount value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(QueryDecisionsRequestCount value) => value.Value;

    public static explicit operator QueryDecisionsRequestCount(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string True = "true";

        public const string False = "false";
    }
}
