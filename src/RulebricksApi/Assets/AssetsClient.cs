using System.Net.Http;
using System.Text.Json;
using System.Threading;
using RulebricksApi.Assets;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class AssetsClient
{
    private RawClient _client;

    internal AssetsClient(RawClient client)
    {
        _client = client;
        Rules = new RulesClient(_client);
        Flows = new FlowsClient(_client);
        Folders = new FoldersClient(_client);
    }

    public RulesClient Rules { get; }

    public FlowsClient Flows { get; }

    public FoldersClient Folders { get; }

    /// <summary>
    /// Get the rule execution usage of your organization.
    /// </summary>
    /// <example><code>
    /// await client.Assets.GetUsageAsync();
    /// </code></example>
    public async Task<UsageStatistics> GetUsageAsync(
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
                    Path = "admin/usage",
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
                return JsonUtils.Deserialize<UsageStatistics>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new RulebricksApiException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new RulebricksApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
