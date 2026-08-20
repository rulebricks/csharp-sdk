using global::System.Text.Json;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class ValuesClient : IValuesClient
{
    private readonly RawClient _client;

    internal ValuesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<OneOf<IEnumerable<DynamicValue>, DynamicValuePage>>
    > ListAsyncCore(
        ListValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new RulebricksApi.Core.QueryStringBuilder.Builder(capacity: 8)
            .Add("name", request.Name)
            .Add("prefix", request.Prefix)
            .Add("type", request.Type)
            .Add("limit", request.Limit)
            .Add("cursor", request.Cursor)
            .Add("user_group", request.UserGroup)
            .Add("include", request.Include)
            .Add("resolve", request.Resolve)
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
                    Path = "values",
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
                var responseData = JsonUtils.Deserialize<
                    OneOf<IEnumerable<DynamicValue>, DynamicValuePage>
                >(responseBody)!;
                return new WithRawResponse<OneOf<IEnumerable<DynamicValue>, DynamicValuePage>>()
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
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<Error>(responseBody));
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

    private async Task<
        WithRawResponse<OneOf<IEnumerable<DynamicValue>, UpdateValuesSummaryResponse>>
    > UpdateAsyncCore(
        UpdateValuesRequest request,
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
                    Path = "values",
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
                    OneOf<IEnumerable<DynamicValue>, UpdateValuesSummaryResponse>
                >(responseBody)!;
                return new WithRawResponse<
                    OneOf<IEnumerable<DynamicValue>, UpdateValuesSummaryResponse>
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
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<Error>(responseBody));
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<WithRawResponse<DeleteValueResponse>> DeleteAsyncCore(
        DeleteValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new RulebricksApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("id", request.Id)
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
                    Method = HttpMethod.Delete,
                    Path = "values",
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
                var responseData = JsonUtils.Deserialize<DeleteValueResponse>(responseBody)!;
                return new WithRawResponse<DeleteValueResponse>()
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
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<Error>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<Error>(responseBody));
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<object>(responseBody));
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

    private async Task<WithRawResponse<SyncValuesResponse>> SyncAsyncCore(
        SyncValuesRequest request,
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
                    Path = "values/sync",
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
                var responseData = JsonUtils.Deserialize<SyncValuesResponse>(responseBody)!;
                return new WithRawResponse<SyncValuesResponse>()
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
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<Error>(responseBody));
                    case 409:
                        throw new ConflictError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<Error>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
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
    /// Retrieve vocabulary values for the authenticated user. Results are scoped to the API key holder's user groups. Optionally filter by user group name or ID when the API key has access to that group. Use the 'include' parameter to control whether usage information is returned. Small workspaces may omit pagination to receive the full catalog as an array (legacy behavior); workspaces above the catalog threshold must paginate with 'limit'/'cursor', which returns { data, next_cursor, total? } ordered by name. The 'prefix' and 'type' filters narrow results to a collection or value type.
    /// </summary>
    /// <example><code>
    /// await client.Values.ListAsync(new ListValuesRequest { Include = "usage" });
    /// </code></example>
    public WithRawResponseTask<OneOf<IEnumerable<DynamicValue>, DynamicValuePage>> ListAsync(
        ListValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<OneOf<IEnumerable<DynamicValue>, DynamicValuePage>>(
            ListAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Update existing vocabulary values or add new ones for the authenticated user. Supports both flat and nested object structures.
    /// </summary>
    /// <example><code>
    /// await client.Values.UpdateAsync(
    ///     new UpdateValuesRequest
    ///     {
    ///         Values = new Dictionary&lt;string, object?&gt;()
    ///         {
    ///             { "Favorite Color", "blue" },
    ///             { "Age", 30 },
    ///             { "Is Student", false },
    ///             {
    ///                 "Hobbies",
    ///                 new List&lt;object?&gt;() { "reading", "cycling" }
    ///             },
    ///         },
    ///         UserGroups = new List&lt;string&gt;() { "marketing", "developers" },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<
        OneOf<IEnumerable<DynamicValue>, UpdateValuesSummaryResponse>
    > UpdateAsync(
        UpdateValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<
            OneOf<IEnumerable<DynamicValue>, UpdateValuesSummaryResponse>
        >(UpdateAsyncCore(request, options, cancellationToken));
    }

    /// <summary>
    /// Delete a specific vocabulary value for the authenticated user by its ID. Deletion is blocked while the value is referenced by any rule or flow. Values whose entire payload references the deleted value are deleted with it (cascade), and list values referencing it lose the referencing items; both effects are reported in the response.
    /// </summary>
    /// <example><code>
    /// await client.Values.DeleteAsync(new DeleteValuesRequest { Id = "id" });
    /// </code></example>
    public WithRawResponseTask<DeleteValueResponse> DeleteAsync(
        DeleteValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DeleteValueResponse>(
            DeleteAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Declaratively makes a collection exactly equal to the payload. Values in the payload are upserted (Existing values keep their IDs), and values under the collection that are absent from the payload are archived by default. The `sync` endpoint supports uploading a particularly large amount of values (100k+) in chunks, using the `sync_id` parameter to track the run.
    /// </summary>
    /// <example><code>
    /// await client.Values.SyncAsync(
    ///     new SyncValuesRequest
    ///     {
    ///         Collection = "Medical Codes",
    ///         Values = new Dictionary&lt;string, object?&gt;()
    ///         {
    ///             { "A123", "A123" },
    ///             { "B456", "B456" },
    ///             { "C789", "C789" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<SyncValuesResponse> SyncAsync(
        SyncValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SyncValuesResponse>(
            SyncAsyncCore(request, options, cancellationToken)
        );
    }
}
