using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Contexts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SubmitTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "email": "customer@example.com",
              "age": 30
            }
            """;

        const string mockResponse = """
            {}
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/contexts/customer/cust-12345")
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

        var response = await Client.Contexts.SubmitAsync(
            new SubmitContextsRequest
            {
                Slug = "customer",
                Instance = "cust-12345",
                Body = new Dictionary<string, object?>()
                {
                    { "email", "customer@example.com" },
                    { "age", 30 },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
