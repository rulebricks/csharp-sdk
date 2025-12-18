using System.Text.Json;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class DecisionsClient
{
    private RawClient _client;

    internal DecisionsClient(RawClient client)
    {
        _client = client;
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
    ///         Statuses = "200,400,500",
    ///     }
    /// );
    /// </code></example>
    public async Task<DecisionLogResponse> QueryAsync(
        QueryDecisionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Search != null)
        {
            _query["search"] = request.Search;
        }
        if (request.Rules != null)
        {
            _query["rules"] = request.Rules;
        }
        if (request.Statuses != null)
        {
            _query["statuses"] = request.Statuses;
        }
        if (request.Start != null)
        {
            _query["start"] = request.Start.Value.ToString(Constants.DateTimeFormat);
        }
        if (request.End != null)
        {
            _query["end"] = request.End.Value.ToString(Constants.DateTimeFormat);
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.Count != null)
        {
            _query["count"] = request.Count.Value.Stringify();
        }
        if (request.Slug != null)
        {
            _query["slug"] = request.Slug;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "decisions/query",
                    Query = _query,
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
                return JsonUtils.Deserialize<DecisionLogResponse>(responseBody)!;
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
