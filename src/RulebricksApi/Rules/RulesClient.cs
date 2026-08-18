using global::System.Text.Json;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class RulesClient : IRulesClient
{
    private readonly RawClient _client;

    internal RulesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<Dictionary<string, object?>>> SolveAsyncCore(
        SolveRulesRequest request,
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
                        "solve/{0}/{1}",
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
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
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
        WithRawResponse<IEnumerable<OneOf<Dictionary<string, object?>, BulkRuleResponseItemError>>>
    > BulkSolveAsyncCore(
        BulkSolveRulesRequest request,
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
                        "bulk-solve/{0}/{1}",
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
                    IEnumerable<OneOf<Dictionary<string, object?>, BulkRuleResponseItemError>>
                >(responseBody)!;
                return new WithRawResponse<
                    IEnumerable<OneOf<Dictionary<string, object?>, BulkRuleResponseItemError>>
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

    private async Task<
        WithRawResponse<Dictionary<string, Dictionary<string, object?>>>
    > ParallelSolveAsyncCore(
        Dictionary<string, ParallelSolveRequestValue> request,
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
                    Path = "parallel-solve",
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
                var responseData = JsonUtils.Deserialize<
                    Dictionary<string, Dictionary<string, object?>>
                >(responseBody)!;
                return new WithRawResponse<Dictionary<string, Dictionary<string, object?>>>()
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
    /// Executes a single rule identified by a unique slug. The request and response formats are dynamic, dependent on the rule configuration. Optionally target a specific published version (e.g. `3`) or a release environment (e.g. `production`) via the `version` path segment; `latest` (the default) executes the current published version.
    /// </summary>
    /// <example><code>
    /// await client.Rules.SolveAsync(
    ///     new SolveRulesRequest
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
    public WithRawResponseTask<Dictionary<string, object?>> SolveAsync(
        SolveRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            SolveAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Executes a particular rule against multiple request data payloads provided in a list. Optionally target a specific published version (e.g. `3`) or a release environment (e.g. `production`) via the `version` path segment; `latest` (the default) executes the current published version.
    /// </summary>
    /// <example><code>
    /// await client.Rules.BulkSolveAsync(
    ///     new BulkSolveRulesRequest
    ///     {
    ///         Slug = "slug",
    ///         Version = "version",
    ///         Body = new List&lt;Dictionary&lt;string, object?&gt;&gt;()
    ///         {
    ///             new Dictionary&lt;string, object?&gt;()
    ///             {
    ///                 { "name", "John Doe" },
    ///                 { "age", 30 },
    ///                 { "email", "jdoe@acme.co" },
    ///             },
    ///             new Dictionary&lt;string, object?&gt;()
    ///             {
    ///                 { "name", "Jane Doe" },
    ///                 { "age", 28 },
    ///                 { "email", "jane@example.com" },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<
        IEnumerable<OneOf<Dictionary<string, object?>, BulkRuleResponseItemError>>
    > BulkSolveAsync(
        BulkSolveRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<
            IEnumerable<OneOf<Dictionary<string, object?>, BulkRuleResponseItemError>>
        >(BulkSolveAsyncCore(request, options, cancellationToken));
    }

    /// <summary>
    /// Executes multiple rules or flows in parallel based on a provided mapping of rule/flow slugs to payloads.
    /// </summary>
    /// <example><code>
    /// await client.Rules.ParallelSolveAsync(
    ///     new Dictionary&lt;string, ParallelSolveRequestValue&gt;()
    ///     {
    ///         {
    ///             "eligibility",
    ///             new ParallelSolveRequestValue
    ///             {
    ///                 Rule = "1ef03ms",
    ///                 AdditionalProperties = new AdditionalProperties
    ///                 {
    ///                     ["name"] = "John Doe",
    ///                     ["age"] = 30,
    ///                     ["email"] = "jdoe@acme.co",
    ///                 },
    ///             }
    ///         },
    ///         {
    ///             "offers",
    ///             new ParallelSolveRequestValue
    ///             {
    ///                 Flow = "OvmsYwn",
    ///                 AdditionalProperties = new AdditionalProperties
    ///                 {
    ///                     ["customer_id"] = "12345",
    ///                     ["last_purchase_days_ago"] = 30,
    ///                     ["selected_plan"] = "premium",
    ///                 },
    ///             }
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<Dictionary<string, Dictionary<string, object?>>> ParallelSolveAsync(
        Dictionary<string, ParallelSolveRequestValue> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, Dictionary<string, object?>>>(
            ParallelSolveAsyncCore(request, options, cancellationToken)
        );
    }
}
