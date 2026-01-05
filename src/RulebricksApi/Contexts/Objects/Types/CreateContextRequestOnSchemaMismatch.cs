using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Contexts;

[JsonConverter(typeof(StringEnumSerializer<CreateContextRequestOnSchemaMismatch>))]
[Serializable]
public readonly record struct CreateContextRequestOnSchemaMismatch : IStringEnum
{
    public static readonly CreateContextRequestOnSchemaMismatch Ignore = new(Values.Ignore);

    public static readonly CreateContextRequestOnSchemaMismatch Reject = new(Values.Reject);

    public CreateContextRequestOnSchemaMismatch(string value)
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
    public static CreateContextRequestOnSchemaMismatch FromCustom(string value)
    {
        return new CreateContextRequestOnSchemaMismatch(value);
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

    public static bool operator ==(CreateContextRequestOnSchemaMismatch value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateContextRequestOnSchemaMismatch value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateContextRequestOnSchemaMismatch value) =>
        value.Value;

    public static explicit operator CreateContextRequestOnSchemaMismatch(string value) =>
        new(value);

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
