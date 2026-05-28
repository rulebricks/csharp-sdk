using RulebricksApi;

namespace RulebricksApi.Assets;

public partial interface IRulesClient
{
    /// <summary>
    /// Delete a specific rule by its ID.
    /// </summary>
    WithRawResponseTask<SuccessMessage> DeleteAsync(
        DeleteRuleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a specific rule by its ID. This response preserves the raw rule document casing (for example, `requestSchema`, `sampleRequest`, and `createdAt`) so it can round-trip through `/admin/rules/import` and `.rbm` workflows.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> PullAsync(
        PullRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or update a rule. If `id` is provided, the matching rule is partially updated (all other fields optional). If `id` is omitted, a new rule is created (`id` and `slug` are auto-generated; all other fields required).
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> PushAsync(
        ImportRuleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all rules in the organization. Results are scoped to the API key holder's user groups. Optionally filter by folder name or ID, or by user group name or ID when the API key has access to that group.
    /// </summary>
    WithRawResponseTask<IEnumerable<RuleDetail>> ListAsync(
        ListRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
