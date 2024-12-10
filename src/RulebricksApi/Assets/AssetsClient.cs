using System.Net.Http;
using System.Text.Json;
using RulebricksApi;
using RulebricksApi.Core;

#nullable enable

namespace RulebricksApi;

public class AssetsClient
{
    private RawClient _client;

    public AssetsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Delete a specific rule by its ID.
    /// </summary>
    public async Task<DeleteRuleResponse> DeleteRuleAsync(DeleteRuleRequest request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = "api/v1/admin/rules/delete",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<DeleteRuleResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Export a specific rule by its ID.
    /// </summary>
    public async Task<Dictionary<string, object>> ExportRuleAsync(ExportRuleRequest request)
    {
        var _query = new Dictionary<string, object>() { { "id", request.Id }, };
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "api/v1/admin/rules/export",
                Query = _query
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
    /// Import a rule into the user's account.
    /// </summary>
    public async Task<ImportRuleResponse> ImportRuleAsync(ImportRuleRequest request)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = "api/v1/admin/rules/import",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<ImportRuleResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// List all rules in the organization.
    /// </summary>
    public async Task<IEnumerable<ListRulesResponseItem>> ListRulesAsync()
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "api/v1/admin/rules/list"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IEnumerable<ListRulesResponseItem>>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// List all flows in the organization.
    /// </summary>
    public async Task ListFlowsAsync()
    {
        await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = "api/v1/admin/flows/list"
            }
        );
    }

    /// <summary>
    /// Get the rule execution usage of your organization.
    /// </summary>
    public async Task<UsageResponse> UsageAsync()
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest { Method = HttpMethod.Get, Path = "api/v1/admin/usage" }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<UsageResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
