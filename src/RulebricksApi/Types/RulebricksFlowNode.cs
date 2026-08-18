using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// A single node in a Rulebricks Flow. `ref` is a flow-local id used only to wire `connections`; `type` selects the node kind. All other properties are that node type's config and unknown keys are preserved. Rule/origin request and response keys are defined by the referenced rule and validated server-side, so connection `output`/`input` keys are accepted as free-form strings.
///
/// Node types:
/// - **Flow Input** - `type: origin` (aliases: `input`, `flow_input`). Input: no data input. requires a published rule.
///   - Config: `rule`, `version`, `name`
///   - Example: `{"ref":"origin","type":"origin","rule":"customer-eligibility"}`
/// - **Rule** - `type: rule`. Input: per-key input (each connection sets `input`). requires a published rule; gateable by Continue If.
///   - Config: `rule`, `version`, `name`
///   - Example: `{"ref":"rule","type":"rule","rule":"risk-score","version":"2"}`
/// - **Run Flow** - `type: flow` (aliases: `subflow`, `run_flow`). Input: per-key input (each connection sets `input`). gateable by Continue If.
///   - Config: `flow`, `version`, `name`, `outputs`, `useCache`, `cacheExpiration`, `cacheKey`
///   - Example: `{"ref":"flow","type":"flow","flow":"credit-check","version":"2","outputs":[{"key":"data.approved","type":"boolean"}]}`
/// - **Continue If** - `type: ifelse` (aliases: `continue_if`, `continueif`). Input: single input (key derived from the source output). emits control edges; gateable by Continue If.
///   - Config: `condition`
///   - Example: `{"ref":"continue_if","type":"continue_if","condition":{"operator":"greater than","args":[700]}}`
/// - **For Each Item** - `type: foreach` (aliases: `for_each`, `foreachitem`). Input: single input (key forced to `list`). gateable by Continue If.
///   - Config: `name`, `outputs`
///   - Example: `{"ref":"for_each","type":"for_each","outputs":[{"key":"amount","type":"number"}]}`
/// - **Combine Items** - `type: aggregate` (aliases: `combine_items`, `combineitems`). Input: single input (key derived from the source output). gateable by Continue If.
///   - Config: `mode`, `aggregations`, `filters`
///   - Example: `{"ref":"combine_items","type":"combine_items","mode":"fields","aggregations":{"amount":{"operator":"sum"}}}`
/// - **Result Object** - `type: result` (aliases: `result_object`). Input: single input (key derived from the source output). terminal; gateable by Continue If.
///   - Config: `key`, `immediateExit`, `keyMappings`, `customExitData`
///   - Example: `{"ref":"result","type":"result","key":"data"}`
/// - **Run Code** - `type: code` (aliases: `run_code`). Input: single input (key derived from the source output). gateable by Continue If.
///   - Config: `name`, `code`, `prompt`, `outputs`
///   - Example: `{"ref":"code","type":"code","name":"Score Tier Script","code":"outputs.tier = inputs.score &gt; 700 ? 'A' : 'B'","outputs":[{"key":"tier","type":"string"}]}`
/// - **API Request** - `type: api` (aliases: `api_request`). Input: single input (key derived from the source output). gateable by Continue If.
///   - Config: `url`, `method`, `headers`, `body`, `useCache`, `cacheExpiration`, `jsonPaths`, `extractPaths`, `outputs`
///   - Example: `{"ref":"api","type":"api","url":"https://api.example.com/lookup","method":"POST","headers":{"Authorization":"Bearer &lt;token&gt;"},"body":{"id":1},"outputs":[{"key":"ok","type":"boolean"}]}`
/// - **Database Query** - `type: db` (aliases: `database_query`). Input: single input (key derived from the source output). gateable by Continue If.
///   - Config: `connectionString`, `query`, `useCache`, `cacheExpiration`, `outputs`
///   - Example: `{"ref":"db","type":"db","connectionString":"postgres://user:pass@host:5432/db","query":"SELECT score FROM customers WHERE id = $1","outputs":[{"key":"score","type":"number"}]}`
/// - **SOAP Request** - `type: soap` (aliases: `soap_request`). Input: single input (key derived from the source output). gateable by Continue If.
///   - Config: `wsdlUrl`, `outputs`
///   - Example: `{"ref":"soap","type":"soap","wsdlUrl":"https://example.com/service?wsdl","outputs":[{"key":"result","type":"object"}]}`
/// - **AI Inference** - `type: ai` (aliases: `ai_inference`). Input: single input (key derived from the source output). gateable by Continue If.
///   - Config: `model`, `labels`
///   - Example: `{"ref":"ai","type":"ai","labels":[{"name":"Sentiment","type":"string","description":"Overall sentiment"}]}`
/// - **Lookup Table** - `type: lookup` (aliases: `lookup_table`). Input: single input (key forced to `lookup`). gateable by Continue If.
///   - Config: `table`, `keyType`, `valueType`, `defaultValue`
///   - Example: `{"ref":"lookup","type":"lookup","table":[{"key":"gold","value":0.2},{"key":"silver","value":0.1}],"keyType":"string","valueType":"number","defaultValue":0}`
/// - **Vault** - `type: vault`. Input: no data input.
///   - Config: `provider`, `credentials`, `secrets`
///   - Example: `{"ref":"vault","type":"vault","secrets":[{"name":"STRIPE_API_KEY"}]}`
/// - **Context Operation** - `type: entity` (aliases: `context_operation`). Input: per-key input (each connection sets `input`). gateable by Continue If.
///   - Config: `operation`, `entitySlug`, `identityFieldKey`, `selectedUpdateFields`, `updateValues`, `includeRelations`, `outputs`
///   - Example: `{"ref":"entity","type":"entity","operation":"read","entitySlug":"customer"}`
/// - **Send Notification** - `type: notification` (aliases: `send_notification`). Input: single input (key derived from the source output). terminal; gateable by Continue If.
///   - Config: `channels`, `titleTemplate`, `messageTemplate`
///   - Example: `{"ref":"notification","type":"notification","channels":{"email":{"enabled":true,"addresses":["alerts@example.com"]}},"titleTemplate":"Flow alert","messageTemplate":"A flow reached the notification step."}`
/// </summary>
[Serializable]
public record RulebricksFlowNode : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Unique, flow-local id used to reference this node in `connections`.
    /// </summary>
    [JsonPropertyName("ref")]
    public required string Ref { get; set; }

    /// <summary>
    /// Node type (a canonical key or a friendly alias).
    /// </summary>
    [JsonPropertyName("type")]
    public required RulebricksFlowNodeType Type { get; set; }

    /// <summary>
    /// Config for node types: origin, rule. A published rule slug, optionally `slug/version`.
    /// </summary>
    [JsonPropertyName("rule")]
    public string? Rule { get; set; }

    /// <summary>
    /// Config for node types: origin, rule, flow. Published version to pin (e.g. "3"). Optional for rule/origin nodes (omit to use the latest published version); REQUIRED for flow nodes, which cannot target "latest".
    /// </summary>
    [JsonPropertyName("version")]
    public object? Version { get; set; }

    /// <summary>
    /// Config for node types: origin, rule, flow, foreach, code. Optional human-readable display name for the step (code nodes show it as the script title on the node).
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Config for node type: flow. A published flow slug to invoke as a subflow, optionally `slug/version`. A pinned numeric version is REQUIRED (here or via `version`), and the target flow must not (transitively) invoke this flow.
    /// </summary>
    [JsonPropertyName("flow")]
    public string? Flow { get; set; }

    /// <summary>
    /// Config for node types: flow, foreach, code, api, db, soap, entity. Declared output handles - declare every output you wire to a downstream node.
    /// </summary>
    [JsonPropertyName("outputs")]
    public IEnumerable<RulebricksFlowNodeOutputsItem>? Outputs { get; set; }

    /// <summary>
    /// Config for node types: flow, api, db.
    /// </summary>
    [JsonPropertyName("useCache")]
    public bool? UseCache { get; set; }

    /// <summary>
    /// Config for node types: flow, api, db.
    /// </summary>
    [JsonPropertyName("cacheExpiration")]
    public double? CacheExpiration { get; set; }

    /// <summary>
    /// Config for node type: flow.
    /// </summary>
    [JsonPropertyName("cacheKey")]
    public string? CacheKey { get; set; }

    /// <summary>
    /// Config for node type: ifelse. Continue If gating condition; evaluated against the single wired input.
    /// </summary>
    [JsonPropertyName("condition")]
    public RulebricksFlowNodeCondition? Condition { get; set; }

    /// <summary>
    /// Config for node type: aggregate.
    /// </summary>
    [JsonPropertyName("mode")]
    public RulebricksFlowNodeMode? Mode { get; set; }

    /// <summary>
    /// Config for node type: aggregate.
    /// </summary>
    [JsonPropertyName("aggregations")]
    public Dictionary<string, RulebricksFlowNodeAggregationsValue>? Aggregations { get; set; }

    /// <summary>
    /// Config for node type: aggregate.
    /// </summary>
    [JsonPropertyName("filters")]
    public IEnumerable<object>? Filters { get; set; }

    /// <summary>
    /// Config for node type: result.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// Config for node type: result.
    /// </summary>
    [JsonPropertyName("immediateExit")]
    public bool? ImmediateExit { get; set; }

    /// <summary>
    /// Config for node type: result.
    /// </summary>
    [JsonPropertyName("keyMappings")]
    public Dictionary<string, string>? KeyMappings { get; set; }

    /// <summary>
    /// Config for node type: result.
    /// </summary>
    [JsonPropertyName("customExitData")]
    public string? CustomExitData { get; set; }

    /// <summary>
    /// Config for node type: code. JavaScript that reads `inputs.&lt;key&gt;` and assigns to `outputs.&lt;key&gt;`.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// Config for node type: code.
    /// </summary>
    [JsonPropertyName("prompt")]
    public string? Prompt { get; set; }

    /// <summary>
    /// Config for node type: api.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Config for node type: api.
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

    /// <summary>
    /// Config for node type: api.
    /// </summary>
    [JsonPropertyName("headers")]
    public object? Headers { get; set; }

    /// <summary>
    /// Config for node type: api.
    /// </summary>
    [JsonPropertyName("body")]
    public object? Body { get; set; }

    /// <summary>
    /// Config for node type: api.
    /// </summary>
    [JsonPropertyName("jsonPaths")]
    public object? JsonPaths { get; set; }

    /// <summary>
    /// Config for node type: api.
    /// </summary>
    [JsonPropertyName("extractPaths")]
    public bool? ExtractPaths { get; set; }

    /// <summary>
    /// Config for node type: db.
    /// </summary>
    [JsonPropertyName("connectionString")]
    public string? ConnectionString { get; set; }

    /// <summary>
    /// Config for node type: db.
    /// </summary>
    [JsonPropertyName("query")]
    public string? Query { get; set; }

    /// <summary>
    /// Config for node type: soap.
    /// </summary>
    [JsonPropertyName("wsdlUrl")]
    public string? WsdlUrl { get; set; }

    /// <summary>
    /// Config for node type: ai.
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    /// <summary>
    /// Config for node type: ai.
    /// </summary>
    [JsonPropertyName("labels")]
    public IEnumerable<RulebricksFlowNodeLabelsItem>? Labels { get; set; }

    /// <summary>
    /// Config for node type: lookup.
    /// </summary>
    [JsonPropertyName("table")]
    public IEnumerable<RulebricksFlowNodeTableItem>? Table { get; set; }

    /// <summary>
    /// Config for node type: lookup.
    /// </summary>
    [JsonPropertyName("keyType")]
    public string? KeyType { get; set; }

    /// <summary>
    /// Config for node type: lookup.
    /// </summary>
    [JsonPropertyName("valueType")]
    public string? ValueType { get; set; }

    /// <summary>
    /// Config for node type: lookup.
    /// </summary>
    [JsonPropertyName("defaultValue")]
    public object? DefaultValue { get; set; }

    /// <summary>
    /// Config for node type: vault.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// Config for node type: vault.
    /// </summary>
    [JsonPropertyName("credentials")]
    public Dictionary<string, object?>? Credentials { get; set; }

    /// <summary>
    /// Config for node type: vault.
    /// </summary>
    [JsonPropertyName("secrets")]
    public IEnumerable<RulebricksFlowNodeSecretsItem>? Secrets { get; set; }

    /// <summary>
    /// Config for node type: entity.
    /// </summary>
    [JsonPropertyName("operation")]
    public RulebricksFlowNodeOperation? Operation { get; set; }

    /// <summary>
    /// Config for node type: entity.
    /// </summary>
    [JsonPropertyName("entitySlug")]
    public string? EntitySlug { get; set; }

    /// <summary>
    /// Config for node type: entity.
    /// </summary>
    [JsonPropertyName("identityFieldKey")]
    public string? IdentityFieldKey { get; set; }

    /// <summary>
    /// Config for node type: entity.
    /// </summary>
    [JsonPropertyName("selectedUpdateFields")]
    public Dictionary<string, bool>? SelectedUpdateFields { get; set; }

    /// <summary>
    /// Config for node type: entity.
    /// </summary>
    [JsonPropertyName("updateValues")]
    public Dictionary<string, object?>? UpdateValues { get; set; }

    /// <summary>
    /// Config for node type: entity.
    /// </summary>
    [JsonPropertyName("includeRelations")]
    public Dictionary<string, bool>? IncludeRelations { get; set; }

    /// <summary>
    /// Config for node type: notification.
    /// </summary>
    [JsonPropertyName("channels")]
    public Dictionary<string, object?>? Channels { get; set; }

    /// <summary>
    /// Config for node type: notification.
    /// </summary>
    [JsonPropertyName("titleTemplate")]
    public string? TitleTemplate { get; set; }

    /// <summary>
    /// Config for node type: notification.
    /// </summary>
    [JsonPropertyName("messageTemplate")]
    public string? MessageTemplate { get; set; }

    /// <summary>
    /// Optional escape hatch: properties merged verbatim onto the expanded node.data for advanced or forward-compatible fields.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
