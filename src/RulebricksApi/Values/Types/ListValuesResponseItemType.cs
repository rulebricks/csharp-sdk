using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RulebricksApi;
using RulebricksApi.Core;

#nullable enable

namespace RulebricksApi;

[JsonConverter(typeof(StringEnumSerializer<ListValuesResponseItemType>))]
public enum ListValuesResponseItemType
{
    [EnumMember(Value = "string")]
    String,

    [EnumMember(Value = "number")]
    Number,

    [EnumMember(Value = "boolean")]
    Boolean,

    [EnumMember(Value = "list")]
    List
}
