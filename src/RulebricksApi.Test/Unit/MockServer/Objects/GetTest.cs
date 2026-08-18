using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Objects;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "content": "content",
              "schema_type": "schema_type",
              "source_format": "source_format",
              "parsed_fields": [
                {
                  "key": "value"
                }
              ],
              "user_groups": [
                "user_groups"
              ],
              "archived_at": "2024-01-15T09:30:00.000Z",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/objects/objectId").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Objects.GetAsync(
            new RulebricksApi.GetObjectsRequest { ObjectId = "objectId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
