using RulebricksApi;

namespace RulebricksApi.Tests;

public partial interface IRulesClient
{
    /// <summary>
    /// Retrieves a list of tests associated with the rule identified by the slug.
    /// </summary>
    WithRawResponseTask<IEnumerable<RulebricksApi.Test>> ListAsync(
        ListRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a new test to the test suite of a rule identified by the slug.
    /// </summary>
    WithRawResponseTask<RulebricksApi.Test> CreateAsync(
        CreateRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a test from the test suite of a rule identified by the slug.
    /// </summary>
    WithRawResponseTask<RulebricksApi.Test> DeleteAsync(
        DeleteRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
