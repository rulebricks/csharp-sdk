using System.Net.Http;
using System.Text.Json;
using RulebricksApi.Core;

#nullable enable

namespace RulebricksApi;

public class FlowsClient
{
    private RawClient _client;

    public FlowsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Execute a flow by its slug.
    /// </summary>
    public async Task<Dictionary<string, object>> ExecuteAsync(
        string slug,
        Dictionary<string, object> request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = $"api/v1/flows/{slug}",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
