using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<ContextInstanceStateStatus>))]
[Serializable]
public readonly record struct ContextInstanceStateStatus : IStringEnum
{
    public static readonly ContextInstanceStateStatus Complete = new(Values.Complete);

    public static readonly ContextInstanceStateStatus Pending = new(Values.Pending);

    public ContextInstanceStateStatus(string value)
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
    public static ContextInstanceStateStatus FromCustom(string value)
    {
        return new ContextInstanceStateStatus(value);
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

    public static bool operator ==(ContextInstanceStateStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContextInstanceStateStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContextInstanceStateStatus value) => value.Value;

    public static explicit operator ContextInstanceStateStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Complete = "complete";

        public const string Pending = "pending";
    }
}
