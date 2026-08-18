using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Values;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "message": "Value \"Favorite Color\" deleted successfully",
              "cascade_deleted": [
                {
                  "id": "id",
                  "name": "name"
                }
              ],
              "updated_list_values": [
                {
                  "id": "id",
                  "name": "name"
                }
              ]
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
