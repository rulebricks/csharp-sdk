using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets.Flows;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "id": "3855f8da-2654-4df9-8903-8f797cbfe8ec",
                "name": "Customer Onboarding Flow",
                "description": "Automate the onboarding process for new customers.",
                "slug": "x6Q4zhD_Lm",
                "published": true,
                "updated_at": "2024-05-15T10:30:22.000Z",
                "origin_rule": {
                  "id": "rule-1234-5678-90ab",
                  "name": "Customer Eligibility",
                  "slug": "customer-eligibility"
                },
                "context": {
                  "id": "ctx-abcd-efgh-ijkl",
                  "name": "Customer",
                  "slug": "customer"
                }
              },
              {
                "id": "2a163563-8ef4-4f32-ba62-6242071b58b7",
                "name": "Order Processing Flow",
                "description": "Streamline order processing and fulfillment.",
                "slug": "uKPCd8hdsZ",
                "published": false,
                "updated_at": "2024-04-18T14:45:33.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/admin/flows/list").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Assets.Flows.ListAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
