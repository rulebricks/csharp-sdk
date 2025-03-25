using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(EnumSerializer<SchemaFieldType>))]
public enum SchemaFieldType
{
    [EnumMember(Value = "string")]
    String,

    [EnumMember(Value = "number")]
    Number,

    [EnumMember(Value = "boolean")]
    Boolean,

    [EnumMember(Value = "object")]
    Object,

    [EnumMember(Value = "array")]
    Array,
}
