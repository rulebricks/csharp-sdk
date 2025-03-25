using System.Net.Http;
using System.Text.Json;
using System.Threading;
using RulebricksApi.Core;
using RulebricksApi.Users;

namespace RulebricksApi;

public partial class UsersClient
{
    private RawClient _client;

    internal UsersClient(RawClient client)
    {
        _client = client;
        Groups = new GroupsClient(_client);
    }

    public GroupsClient Groups { get; }

    /// <summary>
    /// Invite a new user to the organization or update role or access group data for an existing user.
    /// </summary>
    /// <example><code>
    /// await client.Users.InviteAsync(
    ///     new UserInviteRequest
    ///     {
    ///         Email = "newuser@example.com",
    ///         Role = UserInviteRequestRole.Developer,
    ///         AccessGroups = new List&lt;string&gt;() { "group1", "group2" },
    ///     }
    /// );
    /// </code></example>
    public async Task<UserInviteResponse> InviteAsync(
        UserInviteRequest request,
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
                    Path = "admin/users/invite",
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
                return JsonUtils.Deserialize<UserInviteResponse>(responseBody)!;
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
