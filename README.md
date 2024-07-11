# Rulebricks C# SDK

## Overview

The Rulebricks C# SDK provides a convenient way to interact with the Rulebricks API. It allows you to manage rules, flows, and values within your application.

## Installation

To install the Rulebricks C# SDK, add the following package reference to your project file:

```xml
<PackageReference Include="RulebricksApi" Version="0.0.43" />
```

## Usage

### Initialization

To use the SDK, you need to initialize the `RulebricksApiClient` with your API key:

```csharp
using RulebricksApi;

var apiKey = "your_api_key";
var client = new RulebricksApiClient(apiKey);
```

### Managing Rules

You can use the `Rules` client to manage rules:

```csharp
// Create a new rule
var rule = new Rule
{
    Name = "Example Rule",
    Conditions = new List<Condition>
    {
        new Condition
        {
            Type = "equals",
            Field = "status",
            Value = "active"
        }
    },
    Actions = new List<Action>
    {
        new Action
        {
            Type = "notify",
            Message = "User is active"
        }
    }
};

var createdRule = client.Rules.CreateRule(rule);
Console.WriteLine($"Created rule with ID: {createdRule.Id}");
```

### Managing Flows

You can use the `Flows` client to manage flows:

```csharp
// Create a new flow
var flow = new Flow
{
    Name = "Example Flow",
    Steps = new List<Step>
    {
        new Step
        {
            Type = "action",
            Action = new Action
            {
                Type = "notify",
                Message = "Flow started"
            }
        }
    }
};

var createdFlow = client.Flows.CreateFlow(flow);
Console.WriteLine($"Created flow with ID: {createdFlow.Id}");
```

### Managing Values

You can use the `Values` client to manage values:

```csharp
// Set a value
var key = "example_key";
var value = "example_value";

client.Values.SetValue(key, value);
Console.WriteLine($"Set value for key: {key}");
```

## Running Tests

To run the tests for the SDK, use the following command:

```bash
dotnet test src/RulebricksApi.Test/RulebricksApi.Test.csproj --configuration Release --framework net6.0
```

## Contributing

We welcome contributions to the Rulebricks C# SDK. Please open an issue or submit a pull request on GitHub.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
