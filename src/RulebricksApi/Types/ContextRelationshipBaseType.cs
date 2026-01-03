using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<ContextRelationshipBaseType>))]
[Serializable]
public readonly record struct ContextRelationshipBaseType : IStringEnum
{
    public static readonly ContextRelationshipBaseType OneToOne = new(Values.OneToOne);

    public static readonly ContextRelationshipBaseType OneToMany = new(Values.OneToMany);

    public static readonly ContextRelationshipBaseType ManyToOne = new(Values.ManyToOne);

    public ContextRelationshipBaseType(string value)
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
    public static ContextRelationshipBaseType FromCustom(string value)
    {
        return new ContextRelationshipBaseType(value);
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

    public static bool operator ==(ContextRelationshipBaseType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContextRelationshipBaseType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContextRelationshipBaseType value) => value.Value;

    public static explicit operator ContextRelationshipBaseType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string OneToOne = "one-to-one";

        public const string OneToMany = "one-to-many";

        public const string ManyToOne = "many-to-one";
    }
}
