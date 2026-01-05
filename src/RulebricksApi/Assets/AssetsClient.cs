using System.Text.Json;
using OneOf;
using RulebricksApi.Assets;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class AssetsClient
{
    private RawClient _client;

    internal AssetsClient(RawClient client)
    {
        _client = client;
        Rules = new RulebricksApi.Assets.RulesClient(_client);
        Flows = new RulebricksApi.Assets.FlowsClient(_client);
        Folders = new FoldersClient(_client);
    }

    public RulebricksApi.Assets.RulesClient Rules { get; }

    public RulebricksApi.Assets.FlowsClient Flows { get; }

    public FoldersClient Folders { get; }

    /// <summary>
    /// Get the rule execution usage of your organization.
    /// </summary>
    /// <example><code>
    /// await client.Assets.GetUsageAsync();
    /// </code></example>
    public async Task<UsageStatistics> GetUsageAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "admin/usage",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<UsageStatistics>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new RulebricksApiException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new RulebricksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Import rules, flows, contexts, and values from an Rulebricks manifest file (*.rbm).
    /// </summary>
    /// <example><code>
    /// await client.Assets.ImportRbmAsync(
    ///     new ImportManifestRequest
    ///     {
    ///         Manifest = new ImportManifestRequestManifest
    ///         {
    ///             Version = "1.0",
    ///             Rules = new List&lt;Dictionary&lt;string, object?&gt;&gt;()
    ///             {
    ///                 new Dictionary&lt;string, object?&gt;()
    ///                 {
    ///                     { "name", "Pricing Rule" },
    ///                     { "slug", "pricing-rule" },
    ///                 },
    ///             },
    ///             Flows = new List&lt;Dictionary&lt;string, object?&gt;&gt;()
    ///             {
    ///                 new Dictionary&lt;string, object?&gt;()
    ///                 {
    ///                     { "name", "Onboarding Flow" },
    ///                     { "slug", "onboarding-flow" },
    ///                 },
    ///             },
    ///             Entities = new List&lt;Dictionary&lt;string, object?&gt;&gt;()
    ///             {
    ///                 new Dictionary&lt;string, object?&gt;()
    ///                 {
    ///                     { "name", "Customer" },
    ///                     { "slug", "customer" },
    ///                 },
    ///             },
    ///             Values = new List&lt;Dictionary&lt;string, object?&gt;&gt;()
    ///             {
    ///                 new Dictionary&lt;string, object?&gt;() { { "name", "tax_rate" }, { "value", 0.08 } },
    ///             },
    ///         },
    ///         ConflictStrategy = ImportManifestRequestConflictStrategy.Update,
    ///     }
    /// );
    /// </code></example>
    public async Task<ImportManifestResponse> ImportRbmAsync(
        ImportManifestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "admin/import",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ImportManifestResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new RulebricksApiException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new RulebricksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Export selected rules, flows, contexts, and values to an Rulebricks manifest file (*.rbm).
    /// </summary>
    /// <example><code>
    /// await client.Assets.ExportRbmAsync(
    ///     new ExportManifestRequest
    ///     {
    ///         RootType = ExportManifestRequestRootType.Rule,
    ///         RootIds = new List&lt;string&gt;() { "pricing-rule", "eligibility-check" },
    ///         IncludeDownstream = false,
    ///     }
    /// );
    /// </code></example>
    public async Task<OneOf<ExportManifestResponse, ExportManifestPreviewResponse>> ExportRbmAsync(
        ExportManifestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "admin/export",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<
                    OneOf<ExportManifestResponse, ExportManifestPreviewResponse>
                >(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new RulebricksApiException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new RulebricksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
