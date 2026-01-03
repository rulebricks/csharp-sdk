using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<CascadeResultStatus>))]
[Serializable]
public readonly record struct CascadeResultStatus : IStringEnum
{
    public static readonly CascadeResultStatus Solved = new(Values.Solved);

    public static readonly CascadeResultStatus Error = new(Values.Error);

    public CascadeResultStatus(string value)
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
    public static CascadeResultStatus FromCustom(string value)
    {
        return new CascadeResultStatus(value);
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

    public static bool operator ==(CascadeResultStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CascadeResultStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CascadeResultStatus value) => value.Value;

    public static explicit operator CascadeResultStatus(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Solved = "solved";

        public const string Error = "error";
    }
}
