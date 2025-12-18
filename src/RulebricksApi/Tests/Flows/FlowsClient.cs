using System.Text.Json;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Tests;

public partial class FlowsClient
{
    private RawClient _client;

    internal FlowsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves a list of tests associated with the flow identified by the slug.
    /// </summary>
    /// <example><code>
    /// await client.Tests.Flows.ListAsync(new ListFlowsRequest { Slug = "slug" });
    /// </code></example>
    public async Task<IEnumerable<RulebricksApi.Test>> ListAsync(
        ListFlowsRequest request,
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
                    Path = string.Format(
                        "admin/flows/{0}/tests",
                        ValueConvert.ToPathParameterString(request.Slug)
                    ),
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
                return JsonUtils.Deserialize<IEnumerable<RulebricksApi.Test>>(responseBody)!;
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
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
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

    /// <summary>
    /// Adds a new test to the test suite of a flow identified by the slug.
    /// </summary>
    /// <example><code>
    /// await client.Tests.Flows.CreateAsync(
    ///     new CreateFlowsRequest
    ///     {
    ///         Slug = "slug",
    ///         Body = new CreateTestRequest
    ///         {
    ///             Name = "Test 3",
    ///             Request = new Dictionary&lt;string, object?&gt;() { { "param1", "value1" } },
    ///             Response = new Dictionary&lt;string, object?&gt;() { { "status", "success" } },
    ///             Critical = true,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<RulebricksApi.Test> CreateAsync(
        CreateFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "admin/flows/{0}/tests",
                        ValueConvert.ToPathParameterString(request.Slug)
                    ),
                    Body = request.Body,
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
                return JsonUtils.Deserialize<RulebricksApi.Test>(responseBody)!;
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
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
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

    /// <summary>
    /// Deletes a test from the test suite of a flow identified by the slug.
    /// </summary>
    /// <example><code>
    /// await client.Tests.Flows.DeleteAsync(new DeleteFlowsRequest { Slug = "slug", TestId = "testId" });
    /// </code></example>
    public async Task<RulebricksApi.Test> DeleteAsync(
        DeleteFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "admin/flows/{0}/tests/{1}",
                        ValueConvert.ToPathParameterString(request.Slug),
                        ValueConvert.ToPathParameterString(request.TestId)
                    ),
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
                return JsonUtils.Deserialize<RulebricksApi.Test>(responseBody)!;
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
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<object>(responseBody));
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
