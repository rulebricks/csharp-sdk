using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<SubmitContextDataResponseStatus>))]
[Serializable]
public readonly record struct SubmitContextDataResponseStatus : IStringEnum
{
    public static readonly SubmitContextDataResponseStatus Complete = new(Values.Complete);

    public static readonly SubmitContextDataResponseStatus Pending = new(Values.Pending);

    public SubmitContextDataResponseStatus(string value)
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
    public static SubmitContextDataResponseStatus FromCustom(string value)
    {
        return new SubmitContextDataResponseStatus(value);
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

    public static bool operator ==(SubmitContextDataResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmitContextDataResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmitContextDataResponseStatus value) => value.Value;

    public static explicit operator SubmitContextDataResponseStatus(string value) => new(value);

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
