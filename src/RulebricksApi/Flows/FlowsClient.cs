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
            OneOf<Dictionary<string, object?>, IEnumerable<Dictionary<string, object?>>>
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
                    OneOf<Dictionary<string, object?>, IEnumerable<Dictionary<string, object?>>>
                >(responseBody)!;
                return new WithRawResponse<
                    OneOf<Dictionary<string, object?>, IEnumerable<Dictionary<string, object?>>>
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
    /// Execute a flow by slug and optional version. Policy failures return `{ error }` with status 200, including per-item errors for bulk requests. Errors: 400 invalid input, 500 unhandled execution failure, 503 unavailable, 504 timeout.
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
        OneOf<Dictionary<string, object?>, IEnumerable<Dictionary<string, object?>>>
    > ExecuteAsync(
        ExecuteFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<
            OneOf<Dictionary<string, object?>, IEnumerable<Dictionary<string, object?>>>
        >(ExecuteAsyncCore(request, options, cancellationToken));
    }
}
