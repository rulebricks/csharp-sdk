using System.Text.Json;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class RulesClient
{
    private RawClient _client;

    internal RulesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Executes a single rule identified by a unique slug. The request and response formats are dynamic, dependent on the rule configuration.
    /// </summary>
    /// <example><code>
    /// await client.Rules.SolveAsync(
    ///     new SolveRulesRequest
    ///     {
    ///         Slug = "slug",
    ///         Body = new Dictionary&lt;string, object?&gt;()
    ///         {
    ///             {
    ///                 "body",
    ///                 new Dictionary&lt;object, object?&gt;()
    ///                 {
    ///                     { "age", 28 },
    ///                     { "email", "alice.johnson@example.com" },
    ///                     { "name", "Alice Johnson" },
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> SolveAsync(
        SolveRulesRequest request,
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
                    Path = string.Format(
                        "solve/{0}",
                        ValueConvert.ToPathParameterString(request.Slug)
                    ),
                    Body = request.Body,
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
    /// Executes a particular rule against multiple request data payloads provided in a list.
    /// </summary>
    /// <example><code>
    /// await client.Rules.BulkSolveAsync(
    ///     new BulkSolveRulesRequest
    ///     {
    ///         Slug = "slug",
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
    public async Task<
        IEnumerable<OneOf<Dictionary<string, object?>, BulkRuleResponseItemError>>
    > BulkSolveAsync(
        BulkSolveRulesRequest request,
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
                    Path = string.Format(
                        "bulk-solve/{0}",
                        ValueConvert.ToPathParameterString(request.Slug)
                    ),
                    Body = request.Body,
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
                    IEnumerable<OneOf<Dictionary<string, object?>, BulkRuleResponseItemError>>
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

    /// <summary>
    /// Executes multiple rules or flows in parallel based on a provided mapping of rule/flow slugs to payloads.
    /// </summary>
    /// <example><code>
    /// await client.Rules.ParallelSolveAsync(
    ///     new Dictionary&lt;string, ParallelSolveRequestValue&gt;()
    ///     {
    ///         { "body", new ParallelSolveRequestValue() },
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, Dictionary<string, object?>>> ParallelSolveAsync(
        Dictionary<string, ParallelSolveRequestValue> request,
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
                    Path = "parallel-solve",
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
                return JsonUtils.Deserialize<Dictionary<string, Dictionary<string, object?>>>(
                    responseBody
                )!;
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
