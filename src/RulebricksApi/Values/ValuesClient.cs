using System.Text.Json;
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
    /// Retrieve all dynamic values for the authenticated user. Use the 'include' parameter to control whether usage information is returned.
    /// </summary>
    /// <example><code>
    /// await client.Values.ListAsync(new ListValuesRequest { Include = "usage" });
    /// </code></example>
    public async Task<IEnumerable<DynamicValue>> ListAsync(
        ListValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Name != null)
        {
            _query["name"] = request.Name;
        }
        if (request.Include != null)
        {
            _query["include"] = request.Include;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "values",
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
                return JsonUtils.Deserialize<IEnumerable<DynamicValue>>(responseBody)!;
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
    /// Update existing dynamic values or add new ones for the authenticated user. Supports both flat and nested object structures. Nested objects are automatically flattened using dot notation and keys are converted to readable format (e.g., 'user_name' becomes 'User Name', nested 'user.contact_info.email' becomes 'User.Contact Info.Email').
    /// </summary>
    /// <example><code>
    /// await client.Values.UpdateAsync(
    ///     new UpdateValuesRequest
    ///     {
    ///         Values = new Dictionary&lt;string, object?&gt;()
    ///         {
    ///             { "Favorite Color", "blue" },
    ///             { "Age", 30 },
    ///             { "Is Student", false },
    ///             {
    ///                 "Hobbies",
    ///                 new List&lt;object?&gt;() { "reading", "cycling" }
    ///             },
    ///         },
    ///         AccessGroups = new List&lt;string&gt;() { "marketing", "developers" },
    ///     }
    /// );
    /// </code></example>
    public async Task<IEnumerable<DynamicValue>> UpdateAsync(
        UpdateValuesRequest request,
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
                    Path = "values",
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
                return JsonUtils.Deserialize<IEnumerable<DynamicValue>>(responseBody)!;
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
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<object>(responseBody));
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
    /// await client.Values.DeleteAsync(new DeleteValuesRequest { Id = "id" });
    /// </code></example>
    public async Task<SuccessMessage> DeleteAsync(
        DeleteValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        _query["id"] = request.Id;
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = "values",
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
