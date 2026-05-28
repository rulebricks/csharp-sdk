using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Flows;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ExecuteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "John Doe",
              "age": 30,
              "email": "jdoe@acme.co"
            }
            """;

        const string mockResponse = """
            {
              "eligible": true,
              "message": "User is eligible for the promotion."
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/flows/slug")
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

        var response = await Client.Flows.ExecuteAsync(
            new ExecuteFlowsRequest
            {
                Slug = "slug",
                Body = new Dictionary<string, object?>()
                {
                    { "name", "John Doe" },
                    { "age", 30 },
                    { "email", "jdoe@acme.co" },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
