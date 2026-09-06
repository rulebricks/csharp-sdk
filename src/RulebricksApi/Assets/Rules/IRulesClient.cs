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
    WithRawResponseTask<RuleExport> PullAsync(
        PullRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or update a rule. If `id` is provided, the matching rule is partially updated (all other fields optional). If `id` is omitted, a new rule is created (`id` and `slug` are auto-generated; all other fields required).
    /// </summary>
    WithRawResponseTask<RuleExport> PushAsync(
        ImportRuleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List rules in the organization, scoped to the API key holder's user groups. Combine folder, labels, user_group, id, slug, name, and search filters. When version is supplied, the filters must match exactly one accessible rule: multiple matches return 400 and no matches return 404. Version accepts a published version number, release environment slug, or latest, using the same publication and access checks as execution. A missing version or release returns 404. The response remains an array; schemas and condition count come from the selected version, while descriptive workspace metadata stays current. Without version, published rules use their published schemas and unpublished rules use their drafts.
    /// </summary>
    WithRawResponseTask<IEnumerable<RuleDetail>> ListAsync(
        ListRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
