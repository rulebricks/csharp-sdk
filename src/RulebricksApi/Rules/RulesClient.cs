using System.Net.Http;
using System.Text.Json;
using System.Threading;
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
    ///     "slug",
    ///     new Dictionary&lt;string, object&gt;()
    ///     {
    ///         { "name", "John Doe" },
    ///         { "age", 30 },
    ///         { "email", "jdoe@acme.co" },
    ///     }
    /// );
    /// </code></example>
    public async Task<object> SolveAsync(
        string slug,
        object request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "api/v1/solve/{0}",
                        ValueConvert.ToPathParameterString(slug)
                    ),
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
                return JsonUtils.Deserialize<object>(responseBody)!;
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
    ///     "slug",
    ///     new List&lt;object&gt;()
    ///     {
    ///         new Dictionary&lt;string, object&gt;()
    ///         {
    ///             { "name", "John Doe" },
    ///             { "age", 30 },
    ///             { "email", "jdoe@acme.co" },
    ///         },
    ///         new Dictionary&lt;string, object&gt;()
    ///         {
    ///             { "name", "Jane Doe" },
    ///             { "age", 28 },
    ///             { "email", "jane@example.com" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<IEnumerable<OneOf<object, BulkRuleResponseItemError>>> BulkSolveAsync(
        string slug,
        IEnumerable<object> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "api/v1/bulk-solve/{0}",
                        ValueConvert.ToPathParameterString(slug)
                    ),
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
                return JsonUtils.Deserialize<IEnumerable<OneOf<object, BulkRuleResponseItemError>>>(
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

    /// <summary>
    /// Executes multiple rules or flows in parallel based on a provided mapping of rule/flow slugs to payloads.
    /// </summary>
    /// <example><code>
    /// await client.Rules.ParallelSolveAsync(
    ///     new Dictionary&lt;string, ParallelSolveRequestValue&gt;()
    ///     {
    ///         {
    ///             "eligibility",
    ///             new ParallelSolveRequestValue { Rule = "1ef03ms" }
    ///         },
    ///         {
    ///             "offers",
    ///             new ParallelSolveRequestValue { Flow = "OvmsYwn" }
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object>> ParallelSolveAsync(
        Dictionary<string, ParallelSolveRequestValue> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "api/v1/parallel-solve",
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
                return JsonUtils.Deserialize<Dictionary<string, object>>(responseBody)!;
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
