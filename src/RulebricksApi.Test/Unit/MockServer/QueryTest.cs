using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Test_.Unit.MockServer;

[TestFixture]
public class QueryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "timestamp": "2024-12-17T10:30:00.000Z",
                  "name": "Lead Qualification",
                  "endpoint": "/api/v1/solve/lead-qual",
                  "status": 200,
                  "request": {
                    "email": "user@example.com",
                    "score": 75
                  },
                  "response": {
                    "qualified": true,
                    "tier": "gold"
                  },
                  "decision": {
                    "matchedRows": [
                      0,
                      2
                    ],
                    "duration": 0.05
                  },
                  "abbreviated": false
                }
              ],
              "cursor": "100",
              "count": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/decisions/query")
                    .WithParam("search", "status=200")
                    .WithParam("rules", "Lead Qualification,Pricing Calculator")
                    .WithParam("statuses", "200,400,500")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Decisions.QueryAsync(
            new QueryDecisionsRequest
            {
                Search = "status=200",
                Rules = "Lead Qualification,Pricing Calculator",
                Statuses = "200,400,500",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DecisionLogResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "timestamp": "2024-01-15T09:30:00.000Z",
                  "name": "name",
                  "endpoint": "endpoint",
                  "status": 1,
                  "request": {
                    "key": "value"
                  },
                  "response": {
                    "key": "value"
                  },
                  "decision": {
                    "key": "value"
                  },
                  "error": "error",
                  "abbreviated": true
                }
              ],
              "cursor": "cursor",
              "count": 1542
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/decisions/query")
                    .WithParam("search", "status=200")
                    .WithParam("rules", "Lead Qualification,Pricing Calculator")
                    .WithParam("statuses", "200,400,500")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Decisions.QueryAsync(
            new QueryDecisionsRequest
            {
                Search = "status=200",
                Rules = "Lead Qualification,Pricing Calculator",
                Statuses = "200,400,500",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DecisionLogResponse>(mockResponse)).UsingDefaults()
        );
    }
}
