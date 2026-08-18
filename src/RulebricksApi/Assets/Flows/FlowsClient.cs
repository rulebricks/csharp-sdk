using global::System.Text.Json;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

public partial class FlowsClient : IFlowsClient
{
    private readonly RawClient _client;

    internal FlowsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<IEnumerable<FlowDetail>>> ListAsyncCore(
        ListFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new RulebricksApi.Core.QueryStringBuilder.Builder(capacity: 3)
            .Add("folder", request.Folder)
            .Add("user_group", request.UserGroup)
            .Add("name", request.Name)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
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
                    Path = "admin/flows/list",
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<IEnumerable<FlowDetail>>(responseBody)!;
                return new WithRawResponse<IEnumerable<FlowDetail>>()
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

    private async Task<WithRawResponse<FlowImportResponse>> PushAsyncCore(
        ImportFlowRequest request,
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
                    Path = "admin/flows/import",
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
                var responseData = JsonUtils.Deserialize<FlowImportResponse>(responseBody)!;
                return new WithRawResponse<FlowImportResponse>()
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

    private async Task<WithRawResponse<FlowImportPayload>> PullAsyncCore(
        PullFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new RulebricksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("id", request.Id)
            .Add("slug", request.Slug)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
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
                    Path = "admin/flows/export",
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<FlowImportPayload>(responseBody)!;
                return new WithRawResponse<FlowImportPayload>()
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
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<Error>(responseBody));
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

    private async Task<WithRawResponse<SuccessMessage>> DeleteAsyncCore(
        DeleteFlowRequest request,
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
                    Method = HttpMethod.Delete,
                    Path = "admin/flows/delete",
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
                var responseData = JsonUtils.Deserialize<SuccessMessage>(responseBody)!;
                return new WithRawResponse<SuccessMessage>()
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
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<Error>(responseBody));
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
    /// List all flows in the organization. Results are scoped to the API key holder's user groups. Optionally filter by folder name or ID, by user group name or ID when the API key has access to that group, or by name.
    /// </summary>
    /// <example><code>
    /// await client.Assets.Flows.ListAsync(new RulebricksApi.Assets.ListFlowsRequest());
    /// </code></example>
    public WithRawResponseTask<IEnumerable<FlowDetail>> ListAsync(
        ListFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<FlowDetail>>(
            ListAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Create or update a flow from the Rulebricks Flow Schema (a list of `nodes` and `connections`). The server expands the Rulebricks Flow Schema definition into the full flow graph - laying it out, wiring property/control handles, resolving referenced published rules, and backfilling node defaults - so the result both renders in the editor and executes via `/flows/{slug}` without any manual editing. If `id` is provided the matching flow is updated; otherwise a new flow is created (`id`/`slug` auto-generated). Flows auto-publish unless `_publish` is set to `false`.
    /// </summary>
    /// <example><code>
    /// await client.Assets.Flows.PushAsync(
    ///     new ImportFlowRequest
    ///     {
    ///         Flow = new FlowImportPayload
    ///         {
    ///             Name = "Underwriting Flow",
    ///             Publish = true,
    ///             Nodes = new List&lt;RulebricksFlowNode&gt;()
    ///             {
    ///                 new RulebricksFlowNode
    ///                 {
    ///                     Ref = "input",
    ///                     Type = RulebricksFlowNodeType.Origin,
    ///                     Rule = "customer-eligibility",
    ///                 },
    ///                 new RulebricksFlowNode
    ///                 {
    ///                     Ref = "gate",
    ///                     Type = RulebricksFlowNodeType.ContinueIf,
    ///                     Condition = new RulebricksFlowNodeCondition
    ///                     {
    ///                         Property = "approved",
    ///                         Operator = "equals",
    ///                         Args = new List&lt;object&gt;() { true },
    ///                     },
    ///                 },
    ///                 new RulebricksFlowNode
    ///                 {
    ///                     Ref = "enrich",
    ///                     Type = RulebricksFlowNodeType.Code,
    ///                     Code = "outputs.tier = inputs.score &gt; 700 ? 'A' : 'B'",
    ///                     Outputs = new List&lt;RulebricksFlowNodeOutputsItem&gt;()
    ///                     {
    ///                         new RulebricksFlowNodeOutputsItem
    ///                         {
    ///                             Key = "tier",
    ///                             Type = RulebricksFlowNodeOutputsItemType.String,
    ///                         },
    ///                     },
    ///                 },
    ///                 new RulebricksFlowNode
    ///                 {
    ///                     Ref = "out",
    ///                     Type = RulebricksFlowNodeType.Result,
    ///                     Key = "data",
    ///                 },
    ///             },
    ///             Connections = new List&lt;RulebricksFlowConnection&gt;()
    ///             {
    ///                 new RulebricksFlowConnection
    ///                 {
    ///                     From = "input",
    ///                     Output = "approved",
    ///                     To = "gate",
    ///                 },
    ///                 new RulebricksFlowConnection
    ///                 {
    ///                     From = "input",
    ///                     Output = "score",
    ///                     To = "enrich",
    ///                     Input = "score",
    ///                 },
    ///                 new RulebricksFlowConnection
    ///                 {
    ///                     From = "gate",
    ///                     To = "out",
    ///                     Control = true,
    ///                 },
    ///                 new RulebricksFlowConnection
    ///                 {
    ///                     From = "enrich",
    ///                     Output = "tier",
    ///                     To = "out",
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<FlowImportResponse> PushAsync(
        ImportFlowRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<FlowImportResponse>(
            PushAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Export a flow into the Rulebricks Flow Schema (nodes + connections), the same shape accepted by `/admin/flows/import`. Works for flows built entirely by hand in the editor, so they can be round-tripped or version-controlled. This is distinct from the top-level `/admin/export`, which produces `.rbm` manifests.
    /// </summary>
    /// <example><code>
    /// await client.Assets.Flows.PullAsync(new PullFlowsRequest());
    /// </code></example>
    public WithRawResponseTask<FlowImportPayload> PullAsync(
        PullFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<FlowImportPayload>(
            PullAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete a specific flow by its ID.
    /// </summary>
    /// <example><code>
    /// await client.Assets.Flows.DeleteAsync(
    ///     new DeleteFlowRequest { Id = "3855f8da-2654-4df9-8903-8f797cbfe8ec" }
    /// );
    /// </code></example>
    public WithRawResponseTask<SuccessMessage> DeleteAsync(
        DeleteFlowRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SuccessMessage>(
            DeleteAsyncCore(request, options, cancellationToken)
        );
    }
}
