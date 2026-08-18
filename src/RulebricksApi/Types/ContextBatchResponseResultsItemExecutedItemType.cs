using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(ContextBatchResponseResultsItemExecutedItemType.ContextBatchResponseResultsItemExecutedItemTypeSerializer)
)]
[Serializable]
public readonly record struct ContextBatchResponseResultsItemExecutedItemType : IStringEnum
{
    public static readonly ContextBatchResponseResultsItemExecutedItemType Rule = new(Values.Rule);

    public static readonly ContextBatchResponseResultsItemExecutedItemType Flow = new(Values.Flow);

    public ContextBatchResponseResultsItemExecutedItemType(string value)
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
    public static ContextBatchResponseResultsItemExecutedItemType FromCustom(string value)
    {
        return new ContextBatchResponseResultsItemExecutedItemType(value);
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

    public static bool operator ==(
        ContextBatchResponseResultsItemExecutedItemType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ContextBatchResponseResultsItemExecutedItemType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ContextBatchResponseResultsItemExecutedItemType value) =>
        value.Value;

    public static explicit operator ContextBatchResponseResultsItemExecutedItemType(string value) =>
        new(value);

    internal class ContextBatchResponseResultsItemExecutedItemTypeSerializer
        : JsonConverter<ContextBatchResponseResultsItemExecutedItemType>
    {
        public override ContextBatchResponseResultsItemExecutedItemType Read(
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
            return new ContextBatchResponseResultsItemExecutedItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContextBatchResponseResultsItemExecutedItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ContextBatchResponseResultsItemExecutedItemType ReadAsPropertyName(
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
            return new ContextBatchResponseResultsItemExecutedItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContextBatchResponseResultsItemExecutedItemType value,
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
        public const string Rule = "rule";

        public const string Flow = "flow";
    }
}
