using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Decisions;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
                    "key": "value"
                  },
                  "response": {
                    "key": "value"
                  },
                  "decision": {
                    "key": "value"
                  },
                  "trace_id": "trace_id",
                  "path_trace": {
                    "key": "value"
                  },
                  "matched_items": [
                    1
                  ],
                  "abbreviated": false,
                  "error": {
                    "key": "value"
                  }
                }
              ],
              "cursor": "eyJ0IjoiMTc1MzY1MDAwMDEyMyIsInMiOjB9",
              "count": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/decisions/query")
                    .WithParam("search", "status=200")
                    .WithParam("rules", "Lead Qualification", "Pricing Calculator")
                    .WithParam("flows", "Loan Approval Flow")
                    .WithParam("contexts", "loans")
                    .WithParam("trace", "7db50259-31a0-42c1-aa3c-36409ad3c756")
                    .WithParam("statuses", "200", "400", "500")
                    .WithParam("item_filter", "customer.id=cst_8f3a12")
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
                Flows = "Loan Approval Flow",
                Contexts = "loans",
                Trace = "7db50259-31a0-42c1-aa3c-36409ad3c756",
                Statuses = "200,400,500",
                ItemFilter = "customer.id=cst_8f3a12",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
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
                  "trace_id": "trace_id",
                  "path_trace": {
                    "key": "value"
                  },
                  "matched_items": [
                    1
                  ],
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
                    .WithParam("rules", "Lead Qualification", "Pricing Calculator")
                    .WithParam("flows", "Loan Approval Flow")
                    .WithParam("contexts", "loans")
                    .WithParam("trace", "7db50259-31a0-42c1-aa3c-36409ad3c756")
                    .WithParam("statuses", "200", "400", "500")
                    .WithParam("item_filter", "customer.id=cst_8f3a12")
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
                Flows = "Loan Approval Flow",
                Contexts = "loans",
                Trace = "7db50259-31a0-42c1-aa3c-36409ad3c756",
                Statuses = "200,400,500",
                ItemFilter = "customer.id=cst_8f3a12",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
