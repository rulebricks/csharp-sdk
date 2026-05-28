using NUnit.Framework;
using RulebricksApi.Contexts;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Contexts.Objects;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "Updated Customer",
              "description": "Updated description for premium customers"
            }
            """;

        const string mockResponse = """
            {
              "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
              "slug": "updated-customer",
              "name": "Updated Customer",
              "updated_at": "2024-01-15T12:00:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/contexts/a1b2c3d4-e5f6-7890-abcd-ef1234567890")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Contexts.Objects.UpdateAsync(
            new UpdateContextRequest
            {
                Id = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                Name = "Updated Customer",
                Description = "Updated description for premium customers",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
