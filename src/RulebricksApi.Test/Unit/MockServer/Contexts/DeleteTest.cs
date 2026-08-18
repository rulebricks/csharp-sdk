using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Contexts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "message": "Instance deleted"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/contexts/customer/cust-12345")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Contexts.DeleteAsync(
            new DeleteContextsRequest { Slug = "customer", Instance = "cust-12345" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
