using NUnit.Framework;
using RulebricksApi.Core;
using RulebricksApi.Test_.Unit.MockServer;

namespace RulebricksApi.Test_.Unit.MockServer.Tests;

[TestFixture]
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
                "testState": {
                  "duration": 0.10000038146972656,
                  "response": {
                    "error": false,
                    "status": "success"
                  },
                  "conditions": [
                    {
                      "alpha": {
                        "result": true
                      }
                    }
                  ],
                  "httpStatus": 200,
                  "successIdxs": [
                    0
                  ],
                  "evaluationError": false
                },
                "lastExecuted": "2024-09-24T17:26:54.000Z"
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
                "testState": {
                  "duration": 0.09999942779541016,
                  "conditions": [
                    {
                      "alpha": {
                        "result": false,
                        "err": "missing"
                      }
                    }
                  ],
                  "httpStatus": 400,
                  "successIdxs": [
                    1
                  ],
                  "evaluationError": "No successful rows found. If this is not what you were expecting, check your input data and rule conditions."
                },
                "lastExecuted": "2024-09-24T17:26:54.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/rules/slug/tests")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tests.Rules.ListAsync(
            new RulebricksApi.Tests.ListRulesRequest { Slug = "slug" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<RulebricksApi.Test>>(mockResponse))
                .UsingDefaults()
        );
    }
}
