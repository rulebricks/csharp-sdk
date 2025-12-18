using System.Text.Json;
using RulebricksApi.Assets;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class AssetsClient
{
    private RawClient _client;

    internal AssetsClient(RawClient client)
    {
        _client = client;
        Rules = new RulebricksApi.Assets.RulesClient(_client);
        Flows = new RulebricksApi.Assets.FlowsClient(_client);
        Folders = new FoldersClient(_client);
    }

    public RulebricksApi.Assets.RulesClient Rules { get; }

    public RulebricksApi.Assets.FlowsClient Flows { get; }

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
                new JsonRequest
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
