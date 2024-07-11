using System.Net.Http;
using System.Text.Json;
using OneOf;
using RulebricksApi;
using RulebricksApi.Core;

#nullable enable

namespace RulebricksApi;

public class ValuesClient
{
    private RawClient _client;

    public ValuesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve all dynamic values for the authenticated user.
    /// </summary>
    public async Task<IEnumerable<ListValuesResponseItem>> ListValuesAsync()
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest(HttpMethod.Get, "api/v1/values")
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IEnumerable<ListValuesResponseItem>>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Update existing dynamic values or add new ones for the authenticated user.
    /// </summary>
    public async Task<IEnumerable<UpdateValuesResponseItem>> UpdateValuesAsync(
        Dictionary<string, OneOf<string, double, bool, IEnumerable<object>>> request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest(HttpMethod.Post, "api/v1/values")
            {
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IEnumerable<UpdateValuesResponseItem>>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Delete a specific dynamic value for the authenticated user by its ID.
    /// </summary>
    public async Task<DeleteValueResponse> DeleteValueAsync(DeleteValueRequest request)
    {
        var _query = new Dictionary<string, object>() { { "id", request.Id }, };
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest(HttpMethod.Delete, "api/v1/values")
            {
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<DeleteValueResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
