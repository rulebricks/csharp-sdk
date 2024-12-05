using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RulebricksApi;
using RulebricksApi.Core;

#nullable enable

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<InviteRequestRole>))]
public enum InviteRequestRole
{
    [EnumMember(Value = "editor")]
    Editor,

    [EnumMember(Value = "developer")]
    Developer
}
