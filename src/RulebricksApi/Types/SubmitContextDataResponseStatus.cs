using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(SubmitContextDataResponseStatus.SubmitContextDataResponseStatusSerializer))]
[Serializable]
public readonly record struct SubmitContextDataResponseStatus : IStringEnum
{
    public static readonly SubmitContextDataResponseStatus Complete = new(Values.Complete);

    public static readonly SubmitContextDataResponseStatus Pending = new(Values.Pending);

    public SubmitContextDataResponseStatus(string value)
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
    public static SubmitContextDataResponseStatus FromCustom(string value)
    {
        return new SubmitContextDataResponseStatus(value);
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

    public static bool operator ==(SubmitContextDataResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmitContextDataResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmitContextDataResponseStatus value) => value.Value;

    public static explicit operator SubmitContextDataResponseStatus(string value) => new(value);

    internal class SubmitContextDataResponseStatusSerializer
        : JsonConverter<SubmitContextDataResponseStatus>
    {
        public override SubmitContextDataResponseStatus Read(
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
            return new SubmitContextDataResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmitContextDataResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmitContextDataResponseStatus ReadAsPropertyName(
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
            return new SubmitContextDataResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmitContextDataResponseStatus value,
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
        public const string Complete = "complete";

        public const string Pending = "pending";
    }
}
