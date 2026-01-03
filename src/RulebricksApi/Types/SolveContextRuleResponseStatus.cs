using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<SolveContextRuleResponseStatus>))]
[Serializable]
public readonly record struct SolveContextRuleResponseStatus : IStringEnum
{
    public static readonly SolveContextRuleResponseStatus Solved = new(Values.Solved);

    public static readonly SolveContextRuleResponseStatus Error = new(Values.Error);

    public SolveContextRuleResponseStatus(string value)
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
    public static SolveContextRuleResponseStatus FromCustom(string value)
    {
        return new SolveContextRuleResponseStatus(value);
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

    public static bool operator ==(SolveContextRuleResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SolveContextRuleResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SolveContextRuleResponseStatus value) => value.Value;

    public static explicit operator SolveContextRuleResponseStatus(string value) => new(value);

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
