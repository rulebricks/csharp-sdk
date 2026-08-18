using global::System.Globalization;
using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Assets;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets.Rules;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PushTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "rule": {
                "name": "Basic Pricing Rule",
                "description": "",
                "createdAt": "2026-02-12T01:29:23.000Z",
                "updatedAt": "2026-02-12T01:29:23.000Z",
                "published": false,
                "testRequest": {
                  "customer_tier": "STANDARD",
                  "order_total": 250,
                  "expedited": false
                },
                "sampleRequest": {
                  "customer_tier": "STANDARD",
                  "order_total": 250,
                  "expedited": false
                },
                "sampleResponse": {
                  "discount_rate": 0,
                  "approval_status": "standard"
                },
                "requestSchema": [
                  {
                    "key": "customer_tier",
                    "show": true,
                    "name": "Customer Tier",
                    "type": "string"
                  },
                  {
                    "key": "order_total",
                    "show": true,
                    "name": "Order Total",
                    "type": "number"
                  },
                  {
                    "key": "expedited",
                    "show": true,
                    "name": "Expedited",
                    "type": "boolean"
                  }
                ],
                "responseSchema": [
                  {
                    "key": "discount_rate",
                    "show": true,
                    "name": "Discount Rate",
                    "type": "number"
                  },
                  {
                    "key": "approval_status",
                    "show": true,
                    "name": "Approval Status",
                    "type": "string"
                  }
                ],
                "conditions": [
                  {
                    "request": {
                      "customer_tier": {
                        "op": "equals",
                        "args": [
                          "VIP"
                        ]
                      }
                    },
                    "response": {
                      "discount_rate": {
                        "value": 0.2
                      },
                      "approval_status": {
                        "value": "priority"
                      }
                    },
                    "settings": {
                      "enabled": true,
                      "priority": 0,
                      "schedule": []
                    }
                  },
                  {
                    "request": {
                      "expedited": {
                        "op": "equals",
                        "args": [
                          true
                        ]
                      }
                    },
                    "response": {
                      "discount_rate": {
                        "value": 0.05
                      },
                      "approval_status": {
                        "value": "expedited"
                      }
                    },
                    "settings": {
                      "enabled": true,
                      "priority": 0,
                      "schedule": []
                    }
                  },
                  {
                    "request": {},
                    "response": {
                      "discount_rate": {
                        "value": 0
                      },
                      "approval_status": {
                        "value": "standard"
                      }
                    },
                    "settings": {
                      "enabled": true,
                      "priority": 0,
                      "schedule": []
                    }
                  }
                ],
                "history": []
              }
            }
            """;

        const string mockResponse = """
            {}
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/rules/import")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Assets.Rules.PushAsync(
            new ImportRuleRequest
            {
                Rule = new RuleImportPayload
                {
                    Name = "Basic Pricing Rule",
                    Description = "",
                    CreatedAt = DateTime.Parse(
                        "2026-02-12T01:29:23.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    UpdatedAt = DateTime.Parse(
                        "2026-02-12T01:29:23.000Z",
                        null,
                        DateTimeStyles.AdjustToUniversal
                    ),
                    Published = false,
                    TestRequest = new Dictionary<string, object?>()
                    {
                        { "customer_tier", "STANDARD" },
                        { "order_total", 250 },
                        { "expedited", false },
                    },
                    SampleRequest = new Dictionary<string, object?>()
                    {
                        { "customer_tier", "STANDARD" },
                        { "order_total", 250 },
                        { "expedited", false },
                    },
                    SampleResponse = new Dictionary<string, object?>()
                    {
                        { "discount_rate", 0 },
                        { "approval_status", "standard" },
                    },
                    RequestSchema = new List<RuleImportSchemaField>()
                    {
                        new RuleImportSchemaField
                        {
                            Key = "customer_tier",
                            Show = true,
                            Name = "Customer Tier",
                            Type = RuleImportSchemaFieldType.String,
                        },
                        new RuleImportSchemaField
                        {
                            Key = "order_total",
                            Show = true,
                            Name = "Order Total",
                            Type = RuleImportSchemaFieldType.Number,
                        },
                        new RuleImportSchemaField
                        {
                            Key = "expedited",
                            Show = true,
                            Name = "Expedited",
                            Type = RuleImportSchemaFieldType.Boolean,
                        },
                    },
                    ResponseSchema = new List<RuleImportSchemaField>()
                    {
                        new RuleImportSchemaField
                        {
                            Key = "discount_rate",
                            Show = true,
                            Name = "Discount Rate",
                            Type = RuleImportSchemaFieldType.Number,
                        },
                        new RuleImportSchemaField
                        {
                            Key = "approval_status",
                            Show = true,
                            Name = "Approval Status",
                            Type = RuleImportSchemaFieldType.String,
                        },
                    },
                    Conditions = new List<RuleImportConditionRow>()
                    {
                        new RuleImportConditionRow
                        {
                            Request = new Dictionary<string, RuleImportRequestCell>()
                            {
                                {
                                    "customer_tier",
                                    new RuleImportRequestCell
                                    {
                                        Op = "equals",
                                        Args = new List<object>() { "VIP" },
                                    }
                                },
                            },
                            Response = new Dictionary<string, RuleImportResponseCell>()
                            {
                                {
                                    "discount_rate",
                                    new RuleImportResponseCell { Value = 0.2 }
                                },
                                {
                                    "approval_status",
                                    new RuleImportResponseCell { Value = "priority" }
                                },
                            },
                            Settings = new RuleImportRowSettings
                            {
                                Enabled = true,
                                GroupId = null,
                                Priority = 0,
                                Schedule = new List<Dictionary<string, object?>>() { },
                            },
                        },
                        new RuleImportConditionRow
                        {
                            Request = new Dictionary<string, RuleImportRequestCell>()
                            {
                                {
                                    "expedited",
                                    new RuleImportRequestCell
                                    {
                                        Op = "equals",
                                        Args = new List<object>() { true },
                                    }
                                },
                            },
                            Response = new Dictionary<string, RuleImportResponseCell>()
                            {
                                {
                                    "discount_rate",
                                    new RuleImportResponseCell { Value = 0.05 }
                                },
                                {
                                    "approval_status",
                                    new RuleImportResponseCell { Value = "expedited" }
                                },
                            },
                            Settings = new RuleImportRowSettings
                            {
                                Enabled = true,
                                GroupId = null,
                                Priority = 0,
                                Schedule = new List<Dictionary<string, object?>>() { },
                            },
                        },
                        new RuleImportConditionRow
                        {
                            Request = new Dictionary<string, RuleImportRequestCell>() { },
                            Response = new Dictionary<string, RuleImportResponseCell>()
                            {
                                {
                                    "discount_rate",
                                    new RuleImportResponseCell { Value = 0 }
                                },
                                {
                                    "approval_status",
                                    new RuleImportResponseCell { Value = "standard" }
                                },
                            },
                            Settings = new RuleImportRowSettings
                            {
                                Enabled = true,
                                GroupId = null,
                                Priority = 0,
                                Schedule = new List<Dictionary<string, object?>>() { },
                            },
                        },
                    },
                    History = new List<Dictionary<string, object?>>() { },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "rule": {
                "id": "11111111-2222-4333-8444-555555555555",
                "name": "Updated Rule Name"
              }
            }
            """;

        const string mockResponse = """
            {}
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/rules/import")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Assets.Rules.PushAsync(
            new ImportRuleRequest
            {
                Rule = new RuleImportPayload
                {
                    Id = "11111111-2222-4333-8444-555555555555",
                    Name = "Updated Rule Name",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
