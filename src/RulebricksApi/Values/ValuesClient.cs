using System.Net.Http;
using System.Text.Json;
using System.Threading;
using RulebricksApi.Core;

namespace RulebricksApi;

public partial class ValuesClient
{
    private RawClient _client;

    internal ValuesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve all dynamic values for the authenticated user.
    /// </summary>
    /// <example><code>
    /// await client.Values.ListDynamicValuesAsync(new ListDynamicValuesRequest());
    /// </code></example>
    public async Task<IEnumerable<object>> ListDynamicValuesAsync(
        ListDynamicValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Name != null)
        {
            _query["name"] = request.Name;
        }
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "api/v1/values",
                    Query = _query,
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
                return JsonUtils.Deserialize<IEnumerable<object>>(responseBody)!;
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

    /// <summary>
    /// Update existing dynamic values or add new ones for the authenticated user.
    /// </summary>
    /// <example><code>
    /// await client.Values.UpdateValuesAsync(
    ///     new UpdateValuesRequest
    ///     {
    ///         Values = new Dictionary&lt;string, OneOf&lt;string, double, bool, IEnumerable&lt;string&gt;&gt;&gt;()
    ///         {
    ///             { "Favorite Color", "blue" },
    ///             { "Age", 30 },
    ///             { "Is Student", false },
    ///             {
    ///                 "Hobbies",
    ///                 new List&lt;string&gt;() { "reading", "cycling" }
    ///             },
    ///         },
    ///         AccessGroups = new List&lt;string&gt;() { "marketing", "developers" },
    ///     }
    /// );
    /// </code></example>
    public async Task<IEnumerable<object>> UpdateValuesAsync(
        UpdateValuesRequest request,
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
                    Path = "api/v1/values",
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
                return JsonUtils.Deserialize<IEnumerable<object>>(responseBody)!;
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

    /// <summary>
    /// Delete a specific dynamic value for the authenticated user by its ID.
    /// </summary>
    /// <example><code>
    /// await client.Values.DeleteDynamicValueAsync(new DeleteDynamicValueRequest { Id = "id" });
    /// </code></example>
    public async Task<SuccessMessage> DeleteDynamicValueAsync(
        DeleteDynamicValueRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["id"] = request.Id;
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = "api/v1/values",
                    Query = _query,
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
                return JsonUtils.Deserialize<SuccessMessage>(responseBody)!;
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
}
