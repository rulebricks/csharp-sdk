using global::System.Text.Json;
using RulebricksApi.Contexts;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class ContextsClient : IContextsClient
{
    private readonly RawClient _client;

    internal ContextsClient(RawClient client)
    {
        _client = client;
        Objects = new RulebricksApi.Contexts.ObjectsClient(_client);
        Relationships = new RelationshipsClient(_client);
    }

    public RulebricksApi.Contexts.IObjectsClient Objects { get; }

    public IRelationshipsClient Relationships { get; }

    private async Task<WithRawResponse<ContextInstanceState>> GetAsyncCore(
        GetContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new RulebricksApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("include_relations", request.IncludeRelations)
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
                    Path = string.Format(
                        "contexts/{0}/{1}",
                        ValueConvert.ToPathParameterString(request.Slug),
                        ValueConvert.ToPathParameterString(request.Instance)
                    ),
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
                var responseData = JsonUtils.Deserialize<ContextInstanceState>(responseBody)!;
                return new WithRawResponse<ContextInstanceState>()
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

    private async Task<WithRawResponse<SubmitContextDataResponse>> SubmitAsyncCore(
        SubmitContextsRequest request,
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
                    Path = string.Format(
                        "contexts/{0}/{1}",
                        ValueConvert.ToPathParameterString(request.Slug),
                        ValueConvert.ToPathParameterString(request.Instance)
                    ),
                    Body = request.Body,
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
                var responseData = JsonUtils.Deserialize<SubmitContextDataResponse>(responseBody)!;
                return new WithRawResponse<SubmitContextDataResponse>()
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

    private async Task<WithRawResponse<DeleteContextInstanceResponse>> DeleteAsyncCore(
        DeleteContextsRequest request,
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
                    Path = string.Format(
                        "contexts/{0}/{1}",
                        ValueConvert.ToPathParameterString(request.Slug),
                        ValueConvert.ToPathParameterString(request.Instance)
                    ),
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
                var responseData = JsonUtils.Deserialize<DeleteContextInstanceResponse>(
                    responseBody
                )!;
                return new WithRawResponse<DeleteContextInstanceResponse>()
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

    private async Task<WithRawResponse<ContextInstanceHistory>> GetHistoryAsyncCore(
        GetHistoryContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new RulebricksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("field", request.Field)
            .Add("limit", request.Limit)
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
                    Path = string.Format(
                        "contexts/{0}/{1}/history",
                        ValueConvert.ToPathParameterString(request.Slug),
                        ValueConvert.ToPathParameterString(request.Instance)
                    ),
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
                var responseData = JsonUtils.Deserialize<ContextInstanceHistory>(responseBody)!;
                return new WithRawResponse<ContextInstanceHistory>()
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

    private async Task<WithRawResponse<ContextInstancePendingResponse>> GetPendingAsyncCore(
        GetPendingContextsRequest request,
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
                    Path = string.Format(
                        "contexts/{0}/{1}/pending",
                        ValueConvert.ToPathParameterString(request.Slug),
                        ValueConvert.ToPathParameterString(request.Instance)
                    ),
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
                var responseData = JsonUtils.Deserialize<ContextInstancePendingResponse>(
                    responseBody
                )!;
                return new WithRawResponse<ContextInstancePendingResponse>()
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

    private async Task<WithRawResponse<CascadeContextResponse>> CascadeAsyncCore(
        CascadeContextsRequest request,
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
                    Path = string.Format(
                        "contexts/{0}/{1}/cascade",
                        ValueConvert.ToPathParameterString(request.Slug),
                        ValueConvert.ToPathParameterString(request.Instance)
                    ),
                    Body = request.Body,
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
                var responseData = JsonUtils.Deserialize<CascadeContextResponse>(responseBody)!;
                return new WithRawResponse<CascadeContextResponse>()
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

    private async Task<WithRawResponse<ContextBatchResponse>> BulkIngestAsyncCore(
        BulkIngestContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new RulebricksApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("include", request.Include)
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "contexts/batch/{0}",
                        ValueConvert.ToPathParameterString(request.Slug)
                    ),
                    Body = request.Body,
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<ContextBatchResponse>(responseBody)!;
                return new WithRawResponse<ContextBatchResponse>()
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
                    case 402:
                        throw new PaymentRequiredError(JsonUtils.Deserialize<Error>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<Error>(responseBody));
                    case 413:
                        throw new ContentTooLargeError(JsonUtils.Deserialize<Error>(responseBody));
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
    /// Retrieve the current state of a context instance.
    /// </summary>
    /// <example><code>
    /// await client.Contexts.GetAsync(
    ///     new GetContextsRequest { Slug = "customer", Instance = "cust-12345" }
    /// );
    /// </code></example>
    public WithRawResponseTask<ContextInstanceState> GetAsync(
        GetContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ContextInstanceState>(
            GetAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Submit data to a context instance, creating it if it doesn't exist. May trigger bound rule/flow evaluations.
    /// </summary>
    /// <example><code>
    /// await client.Contexts.SubmitAsync(
    ///     new SubmitContextsRequest
    ///     {
    ///         Slug = "customer",
    ///         Instance = "cust-12345",
    ///         Body = new Dictionary&lt;string, object?&gt;()
    ///         {
    ///             { "email", "customer@example.com" },
    ///             { "age", 30 },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<SubmitContextDataResponse> SubmitAsync(
        SubmitContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmitContextDataResponse>(
            SubmitAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete a specific context instance and its history.
    /// </summary>
    /// <example><code>
    /// await client.Contexts.DeleteAsync(
    ///     new DeleteContextsRequest { Slug = "customer", Instance = "cust-12345" }
    /// );
    /// </code></example>
    public WithRawResponseTask<DeleteContextInstanceResponse> DeleteAsync(
        DeleteContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DeleteContextInstanceResponse>(
            DeleteAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieve the change history for a context instance.
    /// </summary>
    /// <example><code>
    /// await client.Contexts.GetHistoryAsync(
    ///     new GetHistoryContextsRequest { Slug = "customer", Instance = "cust-12345" }
    /// );
    /// </code></example>
    public WithRawResponseTask<ContextInstanceHistory> GetHistoryAsync(
        GetHistoryContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ContextInstanceHistory>(
            GetHistoryAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Get list of rules/flows that need to be evaluated for this instance.
    /// </summary>
    /// <example><code>
    /// await client.Contexts.GetPendingAsync(
    ///     new GetPendingContextsRequest { Slug = "customer", Instance = "cust-12345" }
    /// );
    /// </code></example>
    public WithRawResponseTask<ContextInstancePendingResponse> GetPendingAsync(
        GetPendingContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ContextInstancePendingResponse>(
            GetPendingAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Re-evaluate registered pending rule and flow executions for this instance after their fact or relationship dependencies may have become available. This does not run every bound asset.
    /// </summary>
    /// <example><code>
    /// await client.Contexts.CascadeAsync(
    ///     new CascadeContextsRequest
    ///     {
    ///         Slug = "customer",
    ///         Instance = "cust-12345",
    ///         Body = new Dictionary&lt;string, object?&gt;() { },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CascadeContextResponse> CascadeAsync(
        CascadeContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CascadeContextResponse>(
            CascadeAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Submit an array of records to any context in one synchronous call. Records merge into their context instances (matched by the context's identity fact), bound rules and flows whose inputs became satisfied execute, and the response returns the resolved state of every touched instance. Retries are always safe: merges are idempotent and executions are deduplicated by input hash. Fact history is recorded for tracked facts exactly as on individual writes. Clients chunk large datasets across requests.
    /// </summary>
    /// <example><code>
    /// await client.Contexts.BulkIngestAsync(
    ///     new BulkIngestContextsRequest
    ///     {
    ///         Slug = "loan-application",
    ///         Body = new List&lt;Dictionary&lt;string, object?&gt;&gt;()
    ///         {
    ///             new Dictionary&lt;string, object?&gt;() { { "loan_id", "APP-1" }, { "amount", 12000 } },
    ///             new Dictionary&lt;string, object?&gt;() { { "loan_id", "APP-2" }, { "amount", 7300 } },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<ContextBatchResponse> BulkIngestAsync(
        BulkIngestContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ContextBatchResponse>(
            BulkIngestAsyncCore(request, options, cancellationToken)
        );
    }
}
