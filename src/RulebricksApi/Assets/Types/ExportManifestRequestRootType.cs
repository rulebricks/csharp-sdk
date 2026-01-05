using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<ExportManifestRequestRootType>))]
[Serializable]
public readonly record struct ExportManifestRequestRootType : IStringEnum
{
    public static readonly ExportManifestRequestRootType Rule = new(Values.Rule);

    public static readonly ExportManifestRequestRootType Flow = new(Values.Flow);

    public static readonly ExportManifestRequestRootType Context = new(Values.Context);

    public static readonly ExportManifestRequestRootType Value = new(Values.Value);

    public ExportManifestRequestRootType(string value)
    {
        Value_ = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    string IStringEnum.Value => Value_;

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value_ { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static ExportManifestRequestRootType FromCustom(string value)
    {
        return new ExportManifestRequestRootType(value);
    }

    public bool Equals(string? other)
    {
        return Value_.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value_;
    }

    public static bool operator ==(ExportManifestRequestRootType value1, string value2) =>
        value1.Value_.Equals(value2);

    public static bool operator !=(ExportManifestRequestRootType value1, string value2) =>
        !value1.Value_.Equals(value2);

    public static explicit operator string(ExportManifestRequestRootType value) => value.Value_;

    public static explicit operator ExportManifestRequestRootType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Rule = "rule";

        public const string Flow = "flow";

        public const string Context = "context";

        public const string Value = "value";
    }
}
