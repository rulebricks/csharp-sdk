using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(TestPolicy.TestPolicySerializer))]
[Serializable]
public readonly record struct TestPolicy : IStringEnum
{
    public static readonly TestPolicy Contains = new(Values.Contains);

    public static readonly TestPolicy Matches = new(Values.Matches);

    public static readonly TestPolicy Excludes = new(Values.Excludes);

    public TestPolicy(string value)
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
    public static TestPolicy FromCustom(string value)
    {
        return new TestPolicy(value);
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

    public static bool operator ==(TestPolicy value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(TestPolicy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TestPolicy value) => value.Value;

    public static explicit operator TestPolicy(string value) => new(value);

    internal class TestPolicySerializer : JsonConverter<TestPolicy>
    {
        public override TestPolicy Read(
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
            return new TestPolicy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TestPolicy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TestPolicy ReadAsPropertyName(
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
            return new TestPolicy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TestPolicy value,
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
