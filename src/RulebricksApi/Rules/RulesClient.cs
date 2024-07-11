using System.Net.Http;
using System.Text.Json;
using RulebricksApi;
using RulebricksApi.Core;

#nullable enable

namespace RulebricksApi;

public class RulesClient
{
    private RawClient _client;

    public RulesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Executes a single rule identified by a unique slug. The request and response formats are dynamic, dependent on the rule configuration.
    /// </summary>
    public async Task<Dictionary<string, object>> SolveAsync(
        string slug,
        Dictionary<string, object> request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = $"api/v1/solve/{slug}",
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

    /// <summary>
    /// Executes a particular rule against multiple request data payloads provided in a list.
    /// </summary>
    public async Task<IEnumerable<Dictionary<string, object>>> BulkSolveAsync(
        string slug,
        IEnumerable<Dictionary<string, object>> request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = $"api/v1/bulk-solve/{slug}",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IEnumerable<Dictionary<string, object>>>(
                responseBody
            )!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Executes multiple rules in parallel based on a provided mapping of rule slugs to payloads.
    /// </summary>
    public async Task<Dictionary<string, object>> ParallelSolveAsync(
        Dictionary<string, object> request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = "api/v1/parallel-solve",
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

    /// <summary>
    /// List all rules in the organization.
    /// </summary>
    public async Task<IEnumerable<ListResponseItem>> ListAsync()
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Get, Path = "api/v1/list" }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IEnumerable<ListResponseItem>>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Get the rule execution usage of your organization.
    /// </summary>
    public async Task<UsageResponse> UsageAsync()
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Get, Path = "api/v1/usage" }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<UsageResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
