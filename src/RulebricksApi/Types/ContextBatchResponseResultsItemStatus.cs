using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(ContextBatchResponseResultsItemStatus.ContextBatchResponseResultsItemStatusSerializer)
)]
[Serializable]
public readonly record struct ContextBatchResponseResultsItemStatus : IStringEnum
{
    public static readonly ContextBatchResponseResultsItemStatus Complete = new(Values.Complete);

    public static readonly ContextBatchResponseResultsItemStatus Pending = new(Values.Pending);

    public ContextBatchResponseResultsItemStatus(string value)
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
    public static ContextBatchResponseResultsItemStatus FromCustom(string value)
    {
        return new ContextBatchResponseResultsItemStatus(value);
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

    public static bool operator ==(ContextBatchResponseResultsItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContextBatchResponseResultsItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContextBatchResponseResultsItemStatus value) =>
        value.Value;

    public static explicit operator ContextBatchResponseResultsItemStatus(string value) =>
        new(value);

    internal class ContextBatchResponseResultsItemStatusSerializer
        : JsonConverter<ContextBatchResponseResultsItemStatus>
    {
        public override ContextBatchResponseResultsItemStatus Read(
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
            return new ContextBatchResponseResultsItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContextBatchResponseResultsItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ContextBatchResponseResultsItemStatus ReadAsPropertyName(
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
            return new ContextBatchResponseResultsItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContextBatchResponseResultsItemStatus value,
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
