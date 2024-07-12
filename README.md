# Rulebricks C# SDK

## Overview

The Rulebricks C# SDK provides a convenient way to interact with the Rulebricks API. It allows you to manage rules, flows, and values within your application.

## Installation

To install the Rulebricks C# SDK, add the following package reference to your project file:

```xml
<PackageReference Include="RulebricksApi" Version="1.0.0" />
```

## Usage

### Initialization

To use the SDK, you need to initialize the `RulebricksApiClient` with your API key:

```csharp
using RulebricksApi;

var apiKey = "your_api_key";
var client = new RulebricksApiClient(apiKey);
```

### Solving a Rule

Here's a simple example of how to solve a rule:

```csharp
var requestData = new Dictionary<string, object>
{
    { "exampleKey", "exampleValue" } // Replace with actual rule data keys and values
};

var result = client.Rules.Solve("example-rule-slug", requestData);
Console.WriteLine($"Result: {result}");
```

### Solving a Flow

Here's a simple example of how to solve a flow:

```csharp
var requestData = new Dictionary<string, object>
{
    { "exampleKey", "exampleValue" } // Replace with actual flow data keys and values
};

var result = client.Flows.Solve("example-flow-slug", requestData);
Console.WriteLine($"Result: {result}");
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

The tests cover various functionalities of the SDK, including rule solving, flow solving, and value management. Ensure that you have the necessary environment setup and dependencies installed before running the tests.

## Contributing

We welcome contributions to the Rulebricks C# SDK. Please follow these steps to contribute:

1. Fork the repository on GitHub.
2. Create a new branch with a descriptive name.
3. Make your changes and commit them with clear and concise messages.
4. Push your changes to your forked repository.
5. Open a pull request on the main repository.

For major changes, please open an issue first to discuss what you would like to change.

## Troubleshooting

If you encounter any issues while using the SDK, please check the following:

- Ensure that you have the correct API key and that it has the necessary permissions.
- Verify that you are using the correct version of the SDK and .NET framework.
- Check the API reference documentation for any changes or updates to the API endpoints.

If the issue persists, please open an issue on GitHub with detailed information about the problem.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
