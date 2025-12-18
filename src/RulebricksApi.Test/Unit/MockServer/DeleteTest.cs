using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Test_.Unit.MockServer;

[TestFixture]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "message": "Value \"Favorite Color\" deleted successfully"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
                    .WithParam("id", "id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Values.DeleteAsync(new DeleteValuesRequest { Id = "id" });
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SuccessMessage>(mockResponse)).UsingDefaults()
        );
    }
}
