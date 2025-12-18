using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Test_.Unit.MockServer;

[TestFixture]
public class ListTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            [
              {
                "id": "abc123",
                "name": "Favorite Color",
                "type": "string",
                "value": "blue",
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing"
                ]
              },
              {
                "id": "def456",
                "name": "Age",
                "type": "number",
                "value": 30,
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing"
                ]
              },
              {
                "id": "ghi789",
                "name": "Is Student",
                "type": "boolean",
                "value": false,
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing"
                ]
              },
              {
                "id": "jkl012",
                "name": "Hobbies",
                "type": "list",
                "value": [
                  "reading",
                  "cycling"
                ],
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing"
                ]
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
                    .WithParam("include", "usage")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Values.ListAsync(new ListValuesRequest { Include = "usage" });
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<DynamicValue>>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            [
              {
                "id": "abc123",
                "name": "Favorite Color",
                "type": "string",
                "value": "blue",
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing"
                ]
              },
              {
                "id": "def456",
                "name": "Age",
                "type": "number",
                "value": 30,
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing"
                ]
              },
              {
                "id": "ghi789",
                "name": "Is Student",
                "type": "boolean",
                "value": false,
                "usages": [
                  {
                    "id": "2855f8da-2654-4df9-8903-8f797cbfe8eb",
                    "name": "Qualify Leads from HubSpot",
                    "description": "Qualify leads based on incoming HubSpot data.",
                    "slug": "w5Q4zhD_Kp",
                    "published": false,
                    "updated_at": "2024-04-23T23:55:38.000Z"
                  }
                ],
                "accessGroups": [
                  "marketing"
                ]
              },
              {
                "id": "jkl012",
                "name": "Hobbies",
                "type": "list",
                "value": [
                  "reading",
                  "cycling"
                ],
                "usages": [
                  {
                    "id": "1a163563-8ef4-4f32-ba62-6242071b58a6",
                    "name": "Returning Customer Discount",
                    "description": "E-commerce discounts & offers for returning customers to our storefront.",
                    "slug": "tJOCd8hdsY",
                    "published": true,
                    "updated_at": "2024-03-22T00:27:41.000Z"
                  }
                ],
                "accessGroups": [
                  "marketing"
                ]
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
                    .WithParam("include", "usage")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Values.ListAsync(new ListValuesRequest { Include = "usage" });
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<DynamicValue>>(mockResponse))
                .UsingDefaults()
        );
    }
}
