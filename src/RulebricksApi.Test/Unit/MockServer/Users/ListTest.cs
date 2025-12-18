using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;
using RulebricksApi.Test_.Unit.MockServer;

namespace RulebricksApi.Test_.Unit.MockServer.Users;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            []
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/admin/users/groups").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.Groups.ListAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<UserGroup>>(mockResponse)).UsingDefaults()
        );
    }
}
