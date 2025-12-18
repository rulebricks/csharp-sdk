using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<UserInviteRequestRole>))]
[Serializable]
public readonly record struct UserInviteRequestRole : IStringEnum
{
    public static readonly UserInviteRequestRole Admin = new(Values.Admin);

    public static readonly UserInviteRequestRole Editor = new(Values.Editor);

    public static readonly UserInviteRequestRole Developer = new(Values.Developer);

    public static readonly UserInviteRequestRole CustomRole = new(Values.CustomRole);

    public UserInviteRequestRole(string value)
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
    public static UserInviteRequestRole FromCustom(string value)
    {
        return new UserInviteRequestRole(value);
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

    public static bool operator ==(UserInviteRequestRole value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UserInviteRequestRole value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UserInviteRequestRole value) => value.Value;

    public static explicit operator UserInviteRequestRole(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Admin = "admin";

        public const string Editor = "editor";

        public const string Developer = "developer";

        public const string CustomRole = "custom-role";
    }
}
