using System.Net.Http;
using System.Text.Json;
using System.Threading;
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
    /// Retrieve logs for a specific user and rule, with optional date range and pagination.
    /// </summary>
    /// <example><code>
    /// await client.Decisions.QueryDecisionsAsync(new QueryDecisionsRequest { Slug = "slug" });
    /// </code></example>
    public async Task<DecisionLogResponse> QueryDecisionsAsync(
        QueryDecisionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["slug"] = request.Slug;
        if (request.From != null)
        {
            _query["from"] = request.From.Value.ToString(Constants.DateTimeFormat);
        }
        if (request.To != null)
        {
            _query["to"] = request.To.Value.ToString(Constants.DateTimeFormat);
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "api/v1/decisions/query",
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
