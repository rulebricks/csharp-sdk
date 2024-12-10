using System.Net.Http;
using System.Text.Json;
using RulebricksApi;
using RulebricksApi.Core;

#nullable enable

namespace RulebricksApi;

public class TestsClient
{
    private RawClient _client;

    public TestsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves a list of tests associated with the rule identified by the slug.
    /// </summary>
    public async Task<IEnumerable<ListRuleTestsResponseItem>> ListRuleTestsAsync(string slug)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"api/v1/admin/rules/{slug}/tests"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IEnumerable<ListRuleTestsResponseItem>>(
                responseBody
            )!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Adds a new test to the test suite of a rule identified by the slug.
    /// </summary>
    public async Task<CreateRuleTestResponse> CreateRuleTestAsync(
        string slug,
        CreateRuleTestRequest request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = $"api/v1/admin/rules/{slug}/tests",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<CreateRuleTestResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Deletes a test from the test suite of a rule identified by the slug.
    /// </summary>
    public async Task<DeleteRuleTestResponse> DeleteRuleTestAsync(string slug, string testId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"api/v1/admin/rules/{slug}/tests/{testId}"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<DeleteRuleTestResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Retrieves a list of tests associated with the flow identified by the slug.
    /// </summary>
    public async Task<IEnumerable<ListFlowTestsResponseItem>> ListFlowTestsAsync(string slug)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Get,
                Path = $"api/v1/admin/flows/{slug}/tests"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<IEnumerable<ListFlowTestsResponseItem>>(
                responseBody
            )!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Adds a new test to the test suite of a flow identified by the slug.
    /// </summary>
    public async Task<CreateFlowTestResponse> CreateFlowTestAsync(
        string slug,
        CreateFlowTestRequest request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = $"api/v1/admin/flows/{slug}/tests",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<CreateFlowTestResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Deletes a test from the test suite of a flow identified by the slug.
    /// </summary>
    public async Task<DeleteFlowTestResponse> DeleteFlowTestAsync(string slug, string testId)
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Delete,
                Path = $"api/v1/admin/flows/{slug}/tests/{testId}"
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<DeleteFlowTestResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
