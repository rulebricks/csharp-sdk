using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Test_.Unit.MockServer;

[TestFixture]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "values": {
                "Favorite Color": "blue",
                "Age": 30,
                "Is Student": false,
                "Hobbies": [
                  "reading",
                  "cycling"
                ]
              },
              "accessGroups": [
                "marketing",
                "developers"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "I5RzbYI64h",
                "name": "Favorite Color",
                "type": "string",
                "value": "blue",
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              },
              {
                "id": "J6SacZJ75i",
                "name": "Age",
                "type": "number",
                "value": 30,
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
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

        var response = await Client.Values.UpdateAsync(
            new UpdateValuesRequest
            {
                Values = new Dictionary<string, object?>()
                {
                    { "Favorite Color", "blue" },
                    { "Age", 30 },
                    { "Is Student", false },
                    {
                        "Hobbies",
                        new List<object?>() { "reading", "cycling" }
                    },
                },
                AccessGroups = new List<string>() { "marketing", "developers" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<DynamicValue>>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "values": {
                "user_profile": {
                  "first_name": "Alice",
                  "last_name": "Johnson",
                  "contact_info": {
                    "email_address": "alice@example.com",
                    "phone_number": "555-0123"
                  }
                },
                "account_settings": {
                  "is_premium_user": true,
                  "subscription_tier": "gold",
                  "preferences": [
                    "email_notifications",
                    "sms_alerts"
                  ]
                },
                "account_balance": 1250.75
              },
              "accessGroups": [
                "marketing",
                "developers"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "I5RzbYI64h",
                "name": "Favorite Color",
                "type": "string",
                "value": "blue",
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              },
              {
                "id": "J6SacZJ75i",
                "name": "Age",
                "type": "number",
                "value": 30,
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
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

        var response = await Client.Values.UpdateAsync(
            new UpdateValuesRequest
            {
                Values = new Dictionary<string, object?>()
                {
                    {
                        "user_profile",
                        new Dictionary<object, object?>()
                        {
                            {
                                "contact_info",
                                new Dictionary<object, object?>()
                                {
                                    { "email_address", "alice@example.com" },
                                    { "phone_number", "555-0123" },
                                }
                            },
                            { "first_name", "Alice" },
                            { "last_name", "Johnson" },
                        }
                    },
                    {
                        "account_settings",
                        new Dictionary<object, object?>()
                        {
                            { "is_premium_user", true },
                            {
                                "preferences",
                                new List<object?>() { "email_notifications", "sms_alerts" }
                            },
                            { "subscription_tier", "gold" },
                        }
                    },
                    { "account_balance", 1250.75 },
                },
                AccessGroups = new List<string>() { "marketing", "developers" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<DynamicValue>>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "values": {
                "Company Name": "Acme Corp",
                "company_details": {
                  "founded_year": 2020,
                  "employee_count": 150,
                  "headquarters": {
                    "city": "San Francisco",
                    "state": "CA",
                    "country": "USA"
                  }
                },
                "Is Public": false,
                "tags": [
                  "tech",
                  "startup",
                  "saas"
                ]
              },
              "accessGroups": [
                "marketing"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "I5RzbYI64h",
                "name": "Favorite Color",
                "type": "string",
                "value": "blue",
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              },
              {
                "id": "J6SacZJ75i",
                "name": "Age",
                "type": "number",
                "value": 30,
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
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

        var response = await Client.Values.UpdateAsync(
            new UpdateValuesRequest
            {
                Values = new Dictionary<string, object?>()
                {
                    { "Company Name", "Acme Corp" },
                    {
                        "company_details",
                        new Dictionary<object, object?>()
                        {
                            { "employee_count", 150 },
                            { "founded_year", 2020 },
                            {
                                "headquarters",
                                new Dictionary<object, object?>()
                                {
                                    { "city", "San Francisco" },
                                    { "country", "USA" },
                                    { "state", "CA" },
                                }
                            },
                        }
                    },
                    { "Is Public", false },
                    {
                        "tags",
                        new List<object?>() { "tech", "startup", "saas" }
                    },
                },
                AccessGroups = new List<string>() { "marketing" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<DynamicValue>>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "values": {
                "Favorite Color": "blue",
                "Age": 30,
                "Is Student": false,
                "Hobbies": [
                  "reading",
                  "cycling"
                ]
              },
              "accessGroups": [
                "marketing",
                "developers"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "I5RzbYI64h",
                "name": "Favorite Color",
                "type": "string",
                "value": "blue",
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              },
              {
                "id": "J6SacZJ75i",
                "name": "Age",
                "type": "number",
                "value": 30,
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
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

        var response = await Client.Values.UpdateAsync(
            new UpdateValuesRequest
            {
                Values = new Dictionary<string, object?>()
                {
                    { "Favorite Color", "blue" },
                    { "Age", 30 },
                    { "Is Student", false },
                    {
                        "Hobbies",
                        new List<object?>() { "reading", "cycling" }
                    },
                },
                AccessGroups = new List<string>() { "marketing", "developers" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<DynamicValue>>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string requestJson = """
            {
              "values": {
                "Favorite Color": "blue",
                "Age": 30,
                "Is Student": false,
                "Hobbies": [
                  "reading",
                  "cycling"
                ]
              },
              "accessGroups": [
                "marketing",
                "developers"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "A1BcdE23f4",
                "name": "User Profile.First Name",
                "type": "string",
                "value": "Alice",
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              },
              {
                "id": "B2CdeF34g5",
                "name": "User Profile.Last Name",
                "type": "string",
                "value": "Johnson",
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              },
              {
                "id": "C3DefG45h6",
                "name": "User Profile.Contact Info.Email Address",
                "type": "string",
                "value": "alice@example.com",
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              },
              {
                "id": "D4EfgH56i7",
                "name": "User Profile.Contact Info.Phone Number",
                "type": "string",
                "value": "555-0123",
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              },
              {
                "id": "E5FghI67j8",
                "name": "Account Settings.Is Premium User",
                "type": "boolean",
                "value": true,
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              },
              {
                "id": "F6GhiJ78k9",
                "name": "Account Settings.Subscription Tier",
                "type": "string",
                "value": "gold",
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              },
              {
                "id": "G7HijK89l0",
                "name": "Account Settings.Preferences",
                "type": "list",
                "value": [
                  "email_notifications",
                  "sms_alerts"
                ],
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              },
              {
                "id": "H8IjkL90m1",
                "name": "Account Balance",
                "type": "number",
                "value": 1250.75,
                "usages": [
                  {}
                ],
                "accessGroups": [
                  "marketing",
                  "developers"
                ]
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
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

        var response = await Client.Values.UpdateAsync(
            new UpdateValuesRequest
            {
                Values = new Dictionary<string, object?>()
                {
                    { "Favorite Color", "blue" },
                    { "Age", 30 },
                    { "Is Student", false },
                    {
                        "Hobbies",
                        new List<object?>() { "reading", "cycling" }
                    },
                },
                AccessGroups = new List<string>() { "marketing", "developers" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<DynamicValue>>(mockResponse))
                .UsingDefaults()
        );
    }
}
