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
    /// Retrieves a list of tests associated with the flow identified by the slug.
    /// </summary>
    public async Task<IEnumerable<ListTestsResponseItem>> ListTestsAsync(string slug)
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
            return JsonSerializer.Deserialize<IEnumerable<ListTestsResponseItem>>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Adds a new test to the test suite of a flow identified by the slug.
    /// </summary>
    public async Task<CreateTestResponse> CreateTestAsync(string slug, CreateTestRequest request)
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
            return JsonSerializer.Deserialize<CreateTestResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Deletes a test from the test suite of a flow identified by the slug.
    /// </summary>
    public async Task<DeleteTestResponse> DeleteTestAsync(string slug, string testId)
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
            return JsonSerializer.Deserialize<DeleteTestResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
