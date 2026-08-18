using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Contexts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkIngestTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            [
              {
                "loan_id": "APP-1",
                "amount": 12000
              },
              {
                "loan_id": "APP-2",
                "amount": 7300
              }
            ]
            """;

        const string mockResponse = """
            {
              "context": "loan-application",
              "accepted": 2,
              "rejected": 0,
              "executed": 1,
              "rejections": [],
              "results": []
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/contexts/batch/loan-application")
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

        var response = await Client.Contexts.BulkIngestAsync(
            new BulkIngestContextsRequest
            {
                Slug = "loan-application",
                Body = new List<Dictionary<string, object?>>()
                {
                    new Dictionary<string, object?>()
                    {
                        { "loan_id", "APP-1" },
                        { "amount", 12000 },
                    },
                    new Dictionary<string, object?>()
                    {
                        { "loan_id", "APP-2" },
                        { "amount", 7300 },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
