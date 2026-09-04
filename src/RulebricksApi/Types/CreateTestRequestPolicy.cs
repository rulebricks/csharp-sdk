using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(CreateTestRequestPolicy.CreateTestRequestPolicySerializer))]
[Serializable]
public readonly record struct CreateTestRequestPolicy : IStringEnum
{
    public static readonly CreateTestRequestPolicy Contains = new(Values.Contains);

    public static readonly CreateTestRequestPolicy Matches = new(Values.Matches);

    public static readonly CreateTestRequestPolicy Excludes = new(Values.Excludes);

    public CreateTestRequestPolicy(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static CreateTestRequestPolicy FromCustom(string value)
    {
        return new CreateTestRequestPolicy(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(CreateTestRequestPolicy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateTestRequestPolicy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateTestRequestPolicy value) => value.Value;

    public static explicit operator CreateTestRequestPolicy(string value) => new(value);

    internal class CreateTestRequestPolicySerializer : JsonConverter<CreateTestRequestPolicy>
    {
        public override CreateTestRequestPolicy Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new CreateTestRequestPolicy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTestRequestPolicy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTestRequestPolicy ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new CreateTestRequestPolicy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTestRequestPolicy value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Contains = "contains";

        public const string Matches = "matches";

        public const string Excludes = "excludes";
    }
}
