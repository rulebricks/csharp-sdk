using System.Net.Http;
using System.Text.Json;
using System.Threading;
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
    ///     "slug",
    ///     new Dictionary&lt;string, object&gt;()
    ///     {
    ///         { "name", "John Doe" },
    ///         { "age", 30 },
    ///         { "email", "jdoe@acme.co" },
    ///     }
    /// );
    /// </code></example>
    public async Task<object> ExecuteAsync(
        string slug,
        object request,
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
                    Path = string.Format(
                        "api/v1/flows/{0}",
                        ValueConvert.ToPathParameterString(slug)
                    ),
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
                return JsonUtils.Deserialize<object>(responseBody)!;
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
