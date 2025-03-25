using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(EnumSerializer<UserInviteRequestRole>))]
public enum UserInviteRequestRole
{
    [EnumMember(Value = "admin")]
    Admin,

    [EnumMember(Value = "editor")]
    Editor,

    [EnumMember(Value = "developer")]
    Developer,

    [EnumMember(Value = "custom-role")]
    CustomRole,
}
