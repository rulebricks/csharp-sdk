using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(ScaleStatusResponseStatus.ScaleStatusResponseStatusSerializer))]
[Serializable]
public readonly record struct ScaleStatusResponseStatus : IStringEnum
{
    public static readonly ScaleStatusResponseStatus Idle = new(Values.Idle);

    public static readonly ScaleStatusResponseStatus Scaling = new(Values.Scaling);

    public static readonly ScaleStatusResponseStatus Ready = new(Values.Ready);

    public ScaleStatusResponseStatus(string value)
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
    public static ScaleStatusResponseStatus FromCustom(string value)
    {
        return new ScaleStatusResponseStatus(value);
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

    public static bool operator ==(ScaleStatusResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScaleStatusResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScaleStatusResponseStatus value) => value.Value;

    public static explicit operator ScaleStatusResponseStatus(string value) => new(value);

    internal class ScaleStatusResponseStatusSerializer : JsonConverter<ScaleStatusResponseStatus>
    {
        public override ScaleStatusResponseStatus Read(
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
            return new ScaleStatusResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScaleStatusResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScaleStatusResponseStatus ReadAsPropertyName(
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
            return new ScaleStatusResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScaleStatusResponseStatus value,
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
        public const string Idle = "idle";

        public const string Scaling = "scaling";

        public const string Ready = "ready";
    }
}
