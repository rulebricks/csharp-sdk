using System.Text.Json;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class FlowsClient
{
    private RawClient _client;

    internal FlowsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Execute a flow by its slug.
    /// </summary>
    /// <example><code>
    /// await client.Flows.ExecuteAsync(
    ///     new ExecuteFlowsRequest
    ///     {
    ///         Slug = "slug",
    ///         Body = new Dictionary&lt;string, object?&gt;()
    ///         {
    ///             {
    ///                 "body",
    ///                 new Dictionary&lt;object, object?&gt;()
    ///                 {
    ///                     { "age", 28 },
    ///                     { "email", "alice.johnson@example.com" },
    ///                     { "name", "Alice Johnson" },
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<Dictionary<string, object?>> ExecuteAsync(
        ExecuteFlowsRequest request,
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
                        "flows/{0}",
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
