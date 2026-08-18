using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(RulebricksFlowNodeType.RulebricksFlowNodeTypeSerializer))]
[Serializable]
public readonly record struct RulebricksFlowNodeType : IStringEnum
{
    public static readonly RulebricksFlowNodeType Origin = new(Values.Origin);

    public static readonly RulebricksFlowNodeType Input = new(Values.Input);

    public static readonly RulebricksFlowNodeType FlowInput = new(Values.FlowInput);

    public static readonly RulebricksFlowNodeType Rule = new(Values.Rule);

    public static readonly RulebricksFlowNodeType Flow = new(Values.Flow);

    public static readonly RulebricksFlowNodeType Subflow = new(Values.Subflow);

    public static readonly RulebricksFlowNodeType RunFlow = new(Values.RunFlow);

    public static readonly RulebricksFlowNodeType Ifelse = new(Values.Ifelse);

    public static readonly RulebricksFlowNodeType ContinueIf = new(Values.ContinueIf);

    public static readonly RulebricksFlowNodeType Continueif = new(Values.Continueif);

    public static readonly RulebricksFlowNodeType Foreach = new(Values.Foreach);

    public static readonly RulebricksFlowNodeType ForEach = new(Values.ForEach);

    public static readonly RulebricksFlowNodeType Foreachitem = new(Values.Foreachitem);

    public static readonly RulebricksFlowNodeType Aggregate = new(Values.Aggregate);

    public static readonly RulebricksFlowNodeType CombineItems = new(Values.CombineItems);

    public static readonly RulebricksFlowNodeType Combineitems = new(Values.Combineitems);

    public static readonly RulebricksFlowNodeType Result = new(Values.Result);

    public static readonly RulebricksFlowNodeType ResultObject = new(Values.ResultObject);

    public static readonly RulebricksFlowNodeType Code = new(Values.Code);

    public static readonly RulebricksFlowNodeType RunCode = new(Values.RunCode);

    public static readonly RulebricksFlowNodeType Api = new(Values.Api);

    public static readonly RulebricksFlowNodeType ApiRequest = new(Values.ApiRequest);

    public static readonly RulebricksFlowNodeType Db = new(Values.Db);

    public static readonly RulebricksFlowNodeType DatabaseQuery = new(Values.DatabaseQuery);

    public static readonly RulebricksFlowNodeType Soap = new(Values.Soap);

    public static readonly RulebricksFlowNodeType SoapRequest = new(Values.SoapRequest);

    public static readonly RulebricksFlowNodeType Ai = new(Values.Ai);

    public static readonly RulebricksFlowNodeType AiInference = new(Values.AiInference);

    public static readonly RulebricksFlowNodeType Lookup = new(Values.Lookup);

    public static readonly RulebricksFlowNodeType LookupTable = new(Values.LookupTable);

    public static readonly RulebricksFlowNodeType Vault = new(Values.Vault);

    public static readonly RulebricksFlowNodeType Entity = new(Values.Entity);

    public static readonly RulebricksFlowNodeType ContextOperation = new(Values.ContextOperation);

    public static readonly RulebricksFlowNodeType Notification = new(Values.Notification);

    public static readonly RulebricksFlowNodeType SendNotification = new(Values.SendNotification);

    public RulebricksFlowNodeType(string value)
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
    public static RulebricksFlowNodeType FromCustom(string value)
    {
        return new RulebricksFlowNodeType(value);
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

    public static bool operator ==(RulebricksFlowNodeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RulebricksFlowNodeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RulebricksFlowNodeType value) => value.Value;

    public static explicit operator RulebricksFlowNodeType(string value) => new(value);

    internal class RulebricksFlowNodeTypeSerializer : JsonConverter<RulebricksFlowNodeType>
    {
        public override RulebricksFlowNodeType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new RulebricksFlowNodeType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RulebricksFlowNodeType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RulebricksFlowNodeType ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new RulebricksFlowNodeType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RulebricksFlowNodeType value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Origin = "origin";

        public const string Input = "input";

        public const string FlowInput = "flow_input";

        public const string Rule = "rule";

        public const string Flow = "flow";

        public const string Subflow = "subflow";

        public const string RunFlow = "run_flow";

        public const string Ifelse = "ifelse";

        public const string ContinueIf = "continue_if";

        public const string Continueif = "continueif";

        public const string Foreach = "foreach";

        public const string ForEach = "for_each";

        public const string Foreachitem = "foreachitem";

        public const string Aggregate = "aggregate";

        public const string CombineItems = "combine_items";

        public const string Combineitems = "combineitems";

        public const string Result = "result";

        public const string ResultObject = "result_object";

        public const string Code = "code";

        public const string RunCode = "run_code";

        public const string Api = "api";

        public const string ApiRequest = "api_request";

        public const string Db = "db";

        public const string DatabaseQuery = "database_query";

        public const string Soap = "soap";

        public const string SoapRequest = "soap_request";

        public const string Ai = "ai";

        public const string AiInference = "ai_inference";

        public const string Lookup = "lookup";

        public const string LookupTable = "lookup_table";

        public const string Vault = "vault";

        public const string Entity = "entity";

        public const string ContextOperation = "context_operation";

        public const string Notification = "notification";

        public const string SendNotification = "send_notification";
    }
}
