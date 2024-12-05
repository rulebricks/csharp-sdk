using System.Net.Http;
using System.Text.Json;
using RulebricksApi;
using RulebricksApi.Core;

#nullable enable

namespace RulebricksApi;

public class DecisionsClient
{
    private RawClient _client;

    public DecisionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve logs for a specific user and rule, with optional date range and pagination.
    /// </summary>
    public async Task<QueryResponse> QueryAsync(QueryRequest request)
    {
        var _query = new Dictionary<string, object>() { { "slug", request.Slug }, };
        if (request.From != null)
        {
            _query["from"] = request.From.Value.ToString("o0");
        }
        if (request.To != null)
        {
            _query["to"] = request.To.Value.ToString("o0");
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.ToString();
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "api/v1/decisions/query",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<QueryResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
