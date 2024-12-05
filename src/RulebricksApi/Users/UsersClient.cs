using System.Net.Http;
using System.Text.Json;
using RulebricksApi;
using RulebricksApi.Core;

#nullable enable

namespace RulebricksApi;

public class UsersClient
{
    private RawClient _client;

    public UsersClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Invite a new user to the organization or update groupspermissions for an existing user.
    /// </summary>
    public async Task<InviteResponse> InviteAsync(InviteRequest request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = "api/v1/admin/users/invite",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<InviteResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// List all user groups available in your Rulebricks organization.
    /// </summary>
    public async Task<IEnumerable<ListGroupsResponseItem>> ListGroupsAsync()
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "api/v1/admin/users/groups"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IEnumerable<ListGroupsResponseItem>>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Create a new user group in your Rulebricks organization.
    /// </summary>
    public async Task<CreateGroupResponse> CreateGroupAsync(CreateGroupRequest request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = "api/v1/admin/users/groups",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<CreateGroupResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
