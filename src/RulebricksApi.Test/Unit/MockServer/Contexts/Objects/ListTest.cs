using NUnit.Framework;
using RulebricksApi.Contexts;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Contexts.Objects;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            []
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/admin/contexts").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Contexts.Objects.ListAsync(new ListObjectsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
