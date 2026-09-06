using global::System.Text.Json;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class FlowsClient : IFlowsClient
{
    private readonly RawClient _client;

    internal FlowsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<
            OneOf<
                OneOf<Dictionary<string, object?>, ExecutionErrorResult>,
                IEnumerable<OneOf<Dictionary<string, object?>, ExecutionErrorResult>>
            >
        >
    > ExecuteAsyncCore(
        ExecuteFlowsRequest request,
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
                        "flows/{0}/{1}",
                        ValueConvert.ToPathParameterString(request.Slug),
                        ValueConvert.ToPathParameterString(request.Version)
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
                var responseData = JsonUtils.Deserialize<
                    OneOf<
                        OneOf<Dictionary<string, object?>, ExecutionErrorResult>,
                        IEnumerable<OneOf<Dictionary<string, object?>, ExecutionErrorResult>>
                    >
                >(responseBody)!;
                return new WithRawResponse<
                    OneOf<
                        OneOf<Dictionary<string, object?>, ExecutionErrorResult>,
                        IEnumerable<OneOf<Dictionary<string, object?>, ExecutionErrorResult>>
                    >
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
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<object>(responseBody)
                        );
                    case 504:
                        throw new GatewayTimeoutError(JsonUtils.Deserialize<object>(responseBody));
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
    /// Execute a flow by slug and optional version. The flow setting `failedResponseMode` controls execution-failure responses: a missing or invalid value is treated as `return` (the default), which returns an `{ "error": "..." }` payload with HTTP 200; `fail` returns HTTP 400 for input/schema failures and HTTP 500 for escalated policy/runtime failures. Request- and entity-level errors, capacity errors, and infrastructure failures remain non-2xx responses as documented.
    /// </summary>
    /// <example><code>
    /// await client.Flows.ExecuteAsync(
    ///     new ExecuteFlowsRequest
    ///     {
    ///         Slug = "slug",
    ///         Version = "version",
    ///         Body = new Dictionary&lt;string, object?&gt;()
    ///         {
    ///             { "name", "John Doe" },
    ///             { "age", 30 },
    ///             { "email", "jdoe@acme.co" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<
        OneOf<
            OneOf<Dictionary<string, object?>, ExecutionErrorResult>,
            IEnumerable<OneOf<Dictionary<string, object?>, ExecutionErrorResult>>
        >
    > ExecuteAsync(
        ExecuteFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<
            OneOf<
                OneOf<Dictionary<string, object?>, ExecutionErrorResult>,
                IEnumerable<OneOf<Dictionary<string, object?>, ExecutionErrorResult>>
            >
        >(ExecuteAsyncCore(request, options, cancellationToken));
    }
}
