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
    public async Task<IEnumerable<ListDynamicValuesResponseItem>> ListDynamicValuesAsync(
        ListDynamicValuesRequest request
    )
    {
        var _query = new Dictionary<string, object>() { };
        if (request.Name != null)
        {
            _query["name"] = request.Name;
        }
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "api/v1/values",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IEnumerable<ListDynamicValuesResponseItem>>(
                responseBody
            )!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Update existing dynamic values or add new ones for the authenticated user.
    /// </summary>
    public async Task<IEnumerable<UpdateResponseItem>> UpdateAsync(
        Dictionary<string, OneOf<string, double, bool, IEnumerable<object>>> request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = "api/v1/values",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IEnumerable<UpdateResponseItem>>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Delete a specific dynamic value for the authenticated user by its ID.
    /// </summary>
    public async Task<DeleteDynamicValueResponse> DeleteDynamicValueAsync(
        DeleteDynamicValueRequest request
    )
    {
        var _query = new Dictionary<string, object>() { { "id", request.Id }, };
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = "api/v1/values",
                Query = _query
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<DeleteDynamicValueResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
