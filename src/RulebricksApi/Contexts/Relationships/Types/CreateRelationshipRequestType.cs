using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Contexts;

[JsonConverter(typeof(StringEnumSerializer<CreateRelationshipRequestType>))]
[Serializable]
public readonly record struct CreateRelationshipRequestType : IStringEnum
{
    public static readonly CreateRelationshipRequestType OneToOne = new(Values.OneToOne);

    public static readonly CreateRelationshipRequestType OneToMany = new(Values.OneToMany);

    public static readonly CreateRelationshipRequestType ManyToOne = new(Values.ManyToOne);

    public CreateRelationshipRequestType(string value)
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
    public static CreateRelationshipRequestType FromCustom(string value)
    {
        return new CreateRelationshipRequestType(value);
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

    public static bool operator ==(CreateRelationshipRequestType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateRelationshipRequestType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateRelationshipRequestType value) => value.Value;

    public static explicit operator CreateRelationshipRequestType(string value) => new(value);

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
