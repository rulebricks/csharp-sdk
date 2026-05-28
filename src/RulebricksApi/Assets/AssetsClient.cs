using global::System.Text.Json;
using OneOf;
using RulebricksApi.Assets;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class AssetsClient : IAssetsClient
{
    private readonly RawClient _client;

    internal AssetsClient(RawClient client)
    {
        _client = client;
        Rules = new RulebricksApi.Assets.RulesClient(_client);
        Flows = new RulebricksApi.Assets.FlowsClient(_client);
        Folders = new FoldersClient(_client);
    }

    public RulebricksApi.Assets.IRulesClient Rules { get; }

    public RulebricksApi.Assets.IFlowsClient Flows { get; }

    public IFoldersClient Folders { get; }

    private async Task<WithRawResponse<UsageStatistics>> GetUsageAsyncCore(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new RulebricksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "admin/usage",
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<UsageStatistics>(responseBody)!;
                return new WithRawResponse<UsageStatistics>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new RulebricksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new RulebricksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<ImportManifestResponse>> ImportRbmAsyncCore(
        ImportManifestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new RulebricksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "admin/import",
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<ImportManifestResponse>(responseBody)!;
                return new WithRawResponse<ImportManifestResponse>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new RulebricksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<Error>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<Error>(responseBody));
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

    private async Task<
        WithRawResponse<OneOf<ExportManifestResponse, ExportManifestPreviewResponse>>
    > ExportRbmAsyncCore(
        ExportManifestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new RulebricksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "admin/export",
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<
                    OneOf<ExportManifestResponse, ExportManifestPreviewResponse>
                >(responseBody)!;
                return new WithRawResponse<
                    OneOf<ExportManifestResponse, ExportManifestPreviewResponse>
                >()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new RulebricksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<Error>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<Error>(responseBody));
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
    /// Get the rule execution usage of your organization.
    /// </summary>
    /// <example><code>
    /// await client.Assets.GetUsageAsync();
    /// </code></example>
    public WithRawResponseTask<UsageStatistics> GetUsageAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UsageStatistics>(
            GetUsageAsyncCore(options, cancellationToken)
        );
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
    public WithRawResponseTask<ImportManifestResponse> ImportRbmAsync(
        ImportManifestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ImportManifestResponse>(
            ImportRbmAsyncCore(request, options, cancellationToken)
        );
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
    public WithRawResponseTask<
        OneOf<ExportManifestResponse, ExportManifestPreviewResponse>
    > ExportRbmAsync(
        ExportManifestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<
            OneOf<ExportManifestResponse, ExportManifestPreviewResponse>
        >(ExportRbmAsyncCore(request, options, cancellationToken));
    }
}
