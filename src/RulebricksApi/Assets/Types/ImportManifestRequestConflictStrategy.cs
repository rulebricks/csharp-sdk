using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<ImportManifestRequestConflictStrategy>))]
[Serializable]
public readonly record struct ImportManifestRequestConflictStrategy : IStringEnum
{
    public static readonly ImportManifestRequestConflictStrategy Update = new(Values.Update);

    public static readonly ImportManifestRequestConflictStrategy Skip = new(Values.Skip);

    public static readonly ImportManifestRequestConflictStrategy Error = new(Values.Error);

    public ImportManifestRequestConflictStrategy(string value)
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
    public static ImportManifestRequestConflictStrategy FromCustom(string value)
    {
        return new ImportManifestRequestConflictStrategy(value);
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

    public static bool operator ==(ImportManifestRequestConflictStrategy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ImportManifestRequestConflictStrategy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ImportManifestRequestConflictStrategy value) =>
        value.Value;

    public static explicit operator ImportManifestRequestConflictStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Update = "update";

        public const string Skip = "skip";

        public const string Error = "error";
    }
}
