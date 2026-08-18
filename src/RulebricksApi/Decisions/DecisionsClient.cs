using global::System.Text.Json;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class DecisionsClient : IDecisionsClient
{
    private readonly RawClient _client;

    internal DecisionsClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<DecisionLogResponse>> QueryAsyncCore(
        QueryDecisionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new RulebricksApi.Core.QueryStringBuilder.Builder(capacity: 15)
            .Add("search", request.Search)
            .Add("rules", request.Rules)
            .Add("flows", request.Flows)
            .Add("contexts", request.Contexts)
            .Add("trace", request.Trace)
            .Add("statuses", request.Statuses)
            .Add("include_traces", request.IncludeTraces)
            .Add("item_filter", request.ItemFilter)
            .Add("start", request.Start)
            .Add("end", request.End)
            .Add("sort", request.Sort)
            .Add("order", request.Order)
            .Add("cursor", request.Cursor)
            .Add("limit", request.Limit)
            .Add("count", request.Count)
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
                    Path = "decisions/query",
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
                var responseData = JsonUtils.Deserialize<DecisionLogResponse>(responseBody)!;
                return new WithRawResponse<DecisionLogResponse>()
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
    /// Query decision logs with support for the decision data query language, rule/status filters, date ranges, and pagination. The query language supports field comparisons (e.g., `alpha=0`, `score&gt;10`), contains/not-contains (e.g., `name:John`, `status!:error`), boolean logic (`AND`, `OR`), and parentheses for grouping.
    /// </summary>
    /// <example><code>
    /// await client.Decisions.QueryAsync(
    ///     new QueryDecisionsRequest
    ///     {
    ///         Search = "status=200",
    ///         Rules = "Lead Qualification,Pricing Calculator",
    ///         Flows = "Loan Approval Flow",
    ///         Contexts = "loans",
    ///         Trace = "7db50259-31a0-42c1-aa3c-36409ad3c756",
    ///         Statuses = "200,400,500",
    ///         ItemFilter = "customer.id=cst_8f3a12",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<DecisionLogResponse> QueryAsync(
        QueryDecisionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<DecisionLogResponse>(
            QueryAsyncCore(request, options, cancellationToken)
        );
    }
}
