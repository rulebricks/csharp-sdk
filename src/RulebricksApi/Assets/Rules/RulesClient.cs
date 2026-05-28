using global::System.Text.Json;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

public partial class RulesClient : IRulesClient
{
    private readonly RawClient _client;

    internal RulesClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<SuccessMessage>> DeleteAsyncCore(
        DeleteRuleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new RulebricksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Delete,
                    Path = "admin/rules/delete",
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SuccessMessage>(responseBody)!;
                return new WithRawResponse<SuccessMessage>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new RulebricksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<Error>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<Error>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<Error>(responseBody));
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> PullAsyncCore(
        PullRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new RulebricksApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("id", request.Id)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new RulebricksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "admin/rules/export",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new RulebricksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<Error>(responseBody));
                    case 404:
                        throw new NotFoundError(JsonUtils.Deserialize<Error>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<Error>(responseBody));
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

    private async Task<WithRawResponse<Dictionary<string, object?>>> PushAsyncCore(
        ImportRuleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new RulebricksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "admin/rules/import",
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Dictionary<string, object?>>(
                    responseBody
                )!;
                return new WithRawResponse<Dictionary<string, object?>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new RulebricksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<Error>(responseBody));
                    case 403:
                        throw new ForbiddenError(JsonUtils.Deserialize<Error>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<Error>(responseBody));
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

    private async Task<WithRawResponse<IEnumerable<RuleDetail>>> ListAsyncCore(
        ListRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new RulebricksApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("folder", request.Folder)
            .Add("user_group", request.UserGroup)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new RulebricksApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "admin/rules/list",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<IEnumerable<RuleDetail>>(responseBody)!;
                return new WithRawResponse<IEnumerable<RuleDetail>>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new RulebricksApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<Error>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<Error>(responseBody));
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
    /// Delete a specific rule by its ID.
    /// </summary>
    /// <example><code>
    /// await client.Assets.Rules.DeleteAsync(
    ///     new DeleteRuleRequest { Id = "2855f8da-2654-4df9-8903-8f797cbfe8eb" }
    /// );
    /// </code></example>
    public WithRawResponseTask<SuccessMessage> DeleteAsync(
        DeleteRuleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SuccessMessage>(
            DeleteAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Export a specific rule by its ID. This response preserves the raw rule document casing (for example, `requestSchema`, `sampleRequest`, and `createdAt`) so it can round-trip through `/admin/rules/import` and `.rbm` workflows.
    /// </summary>
    /// <example><code>
    /// await client.Assets.Rules.PullAsync(
    ///     new PullRulesRequest { Id = "2855f8da-2654-4df9-8903-8f797cbfe8eb" }
    /// );
    /// </code></example>
    public WithRawResponseTask<Dictionary<string, object?>> PullAsync(
        PullRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            PullAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Create or update a rule. If `id` is provided, the matching rule is partially updated (all other fields optional). If `id` is omitted, a new rule is created (`id` and `slug` are auto-generated; all other fields required).
    /// </summary>
    /// <example><code>
    /// await client.Assets.Rules.PushAsync(
    ///     new ImportRuleRequest
    ///     {
    ///         Rule = new RuleImportPayload
    ///         {
    ///             Name = "Basic Pricing Rule",
    ///             Description = "",
    ///             CreatedAt = new DateTime(2026, 02, 12, 01, 29, 23, 000),
    ///             UpdatedAt = new DateTime(2026, 02, 12, 01, 29, 23, 000),
    ///             Published = false,
    ///             TestRequest = new Dictionary&lt;string, object?&gt;()
    ///             {
    ///                 { "customer_tier", "STANDARD" },
    ///                 { "order_total", 250 },
    ///                 { "expedited", false },
    ///             },
    ///             SampleRequest = new Dictionary&lt;string, object?&gt;()
    ///             {
    ///                 { "customer_tier", "STANDARD" },
    ///                 { "order_total", 250 },
    ///                 { "expedited", false },
    ///             },
    ///             SampleResponse = new Dictionary&lt;string, object?&gt;()
    ///             {
    ///                 { "discount_rate", 0 },
    ///                 { "approval_status", "standard" },
    ///             },
    ///             RequestSchema = new List&lt;RuleImportSchemaField&gt;()
    ///             {
    ///                 new RuleImportSchemaField
    ///                 {
    ///                     Key = "customer_tier",
    ///                     Show = true,
    ///                     Name = "Customer Tier",
    ///                     Type = RuleImportSchemaFieldType.String,
    ///                 },
    ///                 new RuleImportSchemaField
    ///                 {
    ///                     Key = "order_total",
    ///                     Show = true,
    ///                     Name = "Order Total",
    ///                     Type = RuleImportSchemaFieldType.Number,
    ///                 },
    ///                 new RuleImportSchemaField
    ///                 {
    ///                     Key = "expedited",
    ///                     Show = true,
    ///                     Name = "Expedited",
    ///                     Type = RuleImportSchemaFieldType.Boolean,
    ///                 },
    ///             },
    ///             ResponseSchema = new List&lt;RuleImportSchemaField&gt;()
    ///             {
    ///                 new RuleImportSchemaField
    ///                 {
    ///                     Key = "discount_rate",
    ///                     Show = true,
    ///                     Name = "Discount Rate",
    ///                     Type = RuleImportSchemaFieldType.Number,
    ///                 },
    ///                 new RuleImportSchemaField
    ///                 {
    ///                     Key = "approval_status",
    ///                     Show = true,
    ///                     Name = "Approval Status",
    ///                     Type = RuleImportSchemaFieldType.String,
    ///                 },
    ///             },
    ///             Conditions = new List&lt;RuleImportConditionRow&gt;()
    ///             {
    ///                 new RuleImportConditionRow
    ///                 {
    ///                     Request = new Dictionary&lt;string, RuleImportRequestCell&gt;()
    ///                     {
    ///                         {
    ///                             "customer_tier",
    ///                             new RuleImportRequestCell
    ///                             {
    ///                                 Op = "equals",
    ///                                 Args = new List&lt;object&gt;() { "VIP" },
    ///                             }
    ///                         },
    ///                     },
    ///                     Response = new Dictionary&lt;string, RuleImportResponseCell&gt;()
    ///                     {
    ///                         {
    ///                             "discount_rate",
    ///                             new RuleImportResponseCell { Value = 0.2 }
    ///                         },
    ///                         {
    ///                             "approval_status",
    ///                             new RuleImportResponseCell { Value = "priority" }
    ///                         },
    ///                     },
    ///                     Settings = new RuleImportRowSettings
    ///                     {
    ///                         Enabled = true,
    ///                         GroupId = null,
    ///                         Priority = 0,
    ///                         Schedule = new List&lt;Dictionary&lt;string, object?&gt;&gt;() { },
    ///                     },
    ///                 },
    ///                 new RuleImportConditionRow
    ///                 {
    ///                     Request = new Dictionary&lt;string, RuleImportRequestCell&gt;()
    ///                     {
    ///                         {
    ///                             "expedited",
    ///                             new RuleImportRequestCell
    ///                             {
    ///                                 Op = "equals",
    ///                                 Args = new List&lt;object&gt;() { true },
    ///                             }
    ///                         },
    ///                     },
    ///                     Response = new Dictionary&lt;string, RuleImportResponseCell&gt;()
    ///                     {
    ///                         {
    ///                             "discount_rate",
    ///                             new RuleImportResponseCell { Value = 0.05 }
    ///                         },
    ///                         {
    ///                             "approval_status",
    ///                             new RuleImportResponseCell { Value = "expedited" }
    ///                         },
    ///                     },
    ///                     Settings = new RuleImportRowSettings
    ///                     {
    ///                         Enabled = true,
    ///                         GroupId = null,
    ///                         Priority = 1,
    ///                         Schedule = new List&lt;Dictionary&lt;string, object?&gt;&gt;() { },
    ///                     },
    ///                 },
    ///                 new RuleImportConditionRow
    ///                 {
    ///                     Request = new Dictionary&lt;string, RuleImportRequestCell&gt;() { },
    ///                     Response = new Dictionary&lt;string, RuleImportResponseCell&gt;()
    ///                     {
    ///                         {
    ///                             "discount_rate",
    ///                             new RuleImportResponseCell { Value = 0 }
    ///                         },
    ///                         {
    ///                             "approval_status",
    ///                             new RuleImportResponseCell { Value = "standard" }
    ///                         },
    ///                     },
    ///                     Settings = new RuleImportRowSettings
    ///                     {
    ///                         Enabled = true,
    ///                         GroupId = null,
    ///                         Priority = 2,
    ///                         Schedule = new List&lt;Dictionary&lt;string, object?&gt;&gt;() { },
    ///                     },
    ///                 },
    ///             },
    ///             History = new List&lt;Dictionary&lt;string, object?&gt;&gt;() { },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<Dictionary<string, object?>> PushAsync(
        ImportRuleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Dictionary<string, object?>>(
            PushAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// List all rules in the organization. Results are scoped to the API key holder's user groups. Optionally filter by folder name or ID, or by user group name or ID when the API key has access to that group.
    /// </summary>
    /// <example><code>
    /// await client.Assets.Rules.ListAsync(
    ///     new RulebricksApi.Assets.ListRulesRequest { Folder = "Marketing Rules" }
    /// );
    /// </code></example>
    public WithRawResponseTask<IEnumerable<RuleDetail>> ListAsync(
        ListRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<RuleDetail>>(
            ListAsyncCore(request, options, cancellationToken)
        );
    }
}
