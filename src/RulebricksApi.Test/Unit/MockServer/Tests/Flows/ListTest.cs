using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;
using RulebricksApi.Tests;

namespace RulebricksApi.Test_.Unit.MockServer.Tests.Flows;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "id": "Wk0CWqGcwrRnezjUJ5N7O",
                "name": "Test 1",
                "request": {
                  "beta": "a",
                  "alpha": 0,
                  "charlie": true
                },
                "response": {
                  "error": false,
                  "status": "success"
                },
                "critical": true,
                "error": false,
                "success": true,
                "test_state": {
                  "duration": 0.10000038146972656,
                  "response": {
                    "error": false,
                    "status": "success"
                  },
                  "conditions": [
                    {
                      "key": "value"
                    }
                  ],
                  "http_status": 200,
                  "success_idxs": [
                    1
                  ],
                  "evaluation_error": false
                },
                "last_executed": "2024-09-24T17:26:54.000Z"
              },
              {
                "id": "Mog-TOCOxUFBVXfuk2xVp",
                "name": "Test 2",
                "request": {
                  "key": "value"
                },
                "response": {
                  "error": false,
                  "status": "success"
                },
                "critical": true,
                "error": true,
                "success": false,
                "test_state": {
                  "duration": 0.09999942779541016,
                  "conditions": [
                    {
                      "key": "value"
                    }
                  ],
                  "http_status": 400,
                  "success_idxs": [
                    1
                  ],
                  "evaluation_error": "No successful rows found. If this is not what you were expecting, check your input data and rule conditions."
                },
                "last_executed": "2024-09-24T17:26:54.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/flows/slug/tests")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tests.Flows.ListAsync(new ListFlowsRequest { Slug = "slug" });
        JsonAssert.AreEqual(response, mockResponse);
    }
}
