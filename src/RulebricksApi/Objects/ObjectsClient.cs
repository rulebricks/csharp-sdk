using global::System.Text.Json;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class ObjectsClient : IObjectsClient
{
    private readonly RawClient _client;

    internal ObjectsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<IEnumerable<WorkspaceObject>>> ListAsyncCore(
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
                    Path = "objects",
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
                var responseData = JsonUtils.Deserialize<IEnumerable<WorkspaceObject>>(
                    responseBody
                )!;
                return new WithRawResponse<IEnumerable<WorkspaceObject>>()
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
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<Error>(responseBody));
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

    private async Task<WithRawResponse<UpsertObjectResponse>> UpsertAsyncCore(
        OneOf<object> request,
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
                    Method = HttpMethod.Put,
                    Path = "objects",
                    Body = request,
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
                var responseData = JsonUtils.Deserialize<UpsertObjectResponse>(responseBody)!;
                return new WithRawResponse<UpsertObjectResponse>()
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

    private async Task<WithRawResponse<WorkspaceObject>> GetAsyncCore(
        GetObjectsRequest request,
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
                        "objects/{0}",
                        ValueConvert.ToPathParameterString(request.ObjectId)
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
                var responseData = JsonUtils.Deserialize<WorkspaceObject>(responseBody)!;
                return new WithRawResponse<WorkspaceObject>()
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

    private async Task<WithRawResponse<DeleteObjectResponse>> DeleteAsyncCore(
        DeleteObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new RulebricksApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("values", request.Values)
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
                    Path = string.Format(
                        "objects/{0}",
                        ValueConvert.ToPathParameterString(request.ObjectId)
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
                var responseData = JsonUtils.Deserialize<DeleteObjectResponse>(responseBody)!;
                return new WithRawResponse<DeleteObjectResponse>()
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

    /// <summary>
    /// Lists the workspace's objects (JSON Schemas). The provided API key must have permission to view vocabulary values. Results are scoped to the API key holder's user groups.
    /// </summary>
    /// <example><code>
    /// await client.Objects.ListAsync();
    /// </code></example>
    public WithRawResponseTask<IEnumerable<WorkspaceObject>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<WorkspaceObject>>(
            ListAsyncCore(options, cancellationToken)
        );
    }

    /// <summary>
    /// Creates or updates an object by ID or name and syncs enum values it generates. `content` and at least one of `id` or `name` are required. Objects help workspace admins programmatically determine multiple collections of values based on Rulebricks' contracts with external systems from a single JSON Schema source. Renaming the object's display name does not move its managed collection paths: those paths derive from schema field keys. When a schema field key itself is renamed, `field_rename` can preserve the generated values' identities.
    /// </summary>
    /// <example><code>
    /// await client.Objects.UpsertAsync(
    ///     new Dictionary&lt;object, object?&gt;()
    ///     {
    ///         {
    ///             "content",
    ///             "{\n  \"type\": \"object\",\n  \"properties\": {\n    \"countryCode\": { \"type\": \"string\", \"title\": \"Country Code\", \"enum\": [\"US\", \"CA\", \"GB\"] }\n  }\n}"
    ///         },
    ///         { "name", "Claim" },
    ///         {
    ///             "user_groups",
    ///             new List&lt;object?&gt;() { "underwriting" }
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<UpsertObjectResponse> UpsertAsync(
        OneOf<object> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpsertObjectResponse>(
            UpsertAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Fetches one object by ID or exact name. The provided API key must have permission to view vocabulary values.
    /// </summary>
    /// <example><code>
    /// await client.Objects.GetAsync(new RulebricksApi.GetObjectsRequest { ObjectId = "objectId" });
    /// </code></example>
    public WithRawResponseTask<WorkspaceObject> GetAsync(
        GetObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<WorkspaceObject>(
            GetAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Deletes the object. By default, unused values are permanently deleted while values referenced by draft, current, or historical rules, flows, or other vocabulary values are archived. Pass values=detach to keep every generated value active as an ordinary, hand-editable value.
    /// </summary>
    /// <example><code>
    /// await client.Objects.DeleteAsync(new RulebricksApi.DeleteObjectsRequest { ObjectId = "objectId" });
    /// </code></example>
    public WithRawResponseTask<DeleteObjectResponse> DeleteAsync(
        DeleteObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DeleteObjectResponse>(
            DeleteAsyncCore(request, options, cancellationToken)
        );
    }
}
