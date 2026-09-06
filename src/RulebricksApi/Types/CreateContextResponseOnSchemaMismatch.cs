using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(CreateContextResponseOnSchemaMismatch.CreateContextResponseOnSchemaMismatchSerializer)
)]
[Serializable]
public readonly record struct CreateContextResponseOnSchemaMismatch : IStringEnum
{
    public static readonly CreateContextResponseOnSchemaMismatch Ignore = new(Values.Ignore);

    public static readonly CreateContextResponseOnSchemaMismatch Reject = new(Values.Reject);

    public static readonly CreateContextResponseOnSchemaMismatch Store = new(Values.Store);

    public CreateContextResponseOnSchemaMismatch(string value)
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
    public static CreateContextResponseOnSchemaMismatch FromCustom(string value)
    {
        return new CreateContextResponseOnSchemaMismatch(value);
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

    public static bool operator ==(CreateContextResponseOnSchemaMismatch value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateContextResponseOnSchemaMismatch value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateContextResponseOnSchemaMismatch value) =>
        value.Value;

    public static explicit operator CreateContextResponseOnSchemaMismatch(string value) =>
        new(value);

    internal class CreateContextResponseOnSchemaMismatchSerializer
        : JsonConverter<CreateContextResponseOnSchemaMismatch>
    {
        public override CreateContextResponseOnSchemaMismatch Read(
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
            return new CreateContextResponseOnSchemaMismatch(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateContextResponseOnSchemaMismatch value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateContextResponseOnSchemaMismatch ReadAsPropertyName(
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
            return new CreateContextResponseOnSchemaMismatch(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateContextResponseOnSchemaMismatch value,
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
        public const string Ignore = "ignore";

        public const string Reject = "reject";

        public const string Store = "store";
    }
}
