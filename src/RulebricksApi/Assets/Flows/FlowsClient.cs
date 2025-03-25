using System.Net.Http;
using System.Text.Json;
using System.Threading;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

public partial class FlowsClient
{
    private RawClient _client;

    internal FlowsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// List all flows in the organization.
    /// </summary>
    /// <example><code>
    /// await client.Assets.Flows.ListAsync();
    /// </code></example>
    public async Task<IEnumerable<FlowDetail>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "admin/flows/list",
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
                return JsonUtils.Deserialize<IEnumerable<FlowDetail>>(responseBody)!;
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
