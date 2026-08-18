using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(ContextBatchResponseResultsItemExecutedItemStatus.ContextBatchResponseResultsItemExecutedItemStatusSerializer)
)]
[Serializable]
public readonly record struct ContextBatchResponseResultsItemExecutedItemStatus : IStringEnum
{
    public static readonly ContextBatchResponseResultsItemExecutedItemStatus Success = new(
        Values.Success
    );

    public static readonly ContextBatchResponseResultsItemExecutedItemStatus EvaluationError = new(
        Values.EvaluationError
    );

    public static readonly ContextBatchResponseResultsItemExecutedItemStatus InfrastructureError =
        new(Values.InfrastructureError);

    public static readonly ContextBatchResponseResultsItemExecutedItemStatus SkippedAlreadyRun =
        new(Values.SkippedAlreadyRun);

    public ContextBatchResponseResultsItemExecutedItemStatus(string value)
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
    public static ContextBatchResponseResultsItemExecutedItemStatus FromCustom(string value)
    {
        return new ContextBatchResponseResultsItemExecutedItemStatus(value);
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
        ContextBatchResponseResultsItemExecutedItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ContextBatchResponseResultsItemExecutedItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ContextBatchResponseResultsItemExecutedItemStatus value
    ) => value.Value;

    public static explicit operator ContextBatchResponseResultsItemExecutedItemStatus(
        string value
    ) => new(value);

    internal class ContextBatchResponseResultsItemExecutedItemStatusSerializer
        : JsonConverter<ContextBatchResponseResultsItemExecutedItemStatus>
    {
        public override ContextBatchResponseResultsItemExecutedItemStatus Read(
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
            return new ContextBatchResponseResultsItemExecutedItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContextBatchResponseResultsItemExecutedItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ContextBatchResponseResultsItemExecutedItemStatus ReadAsPropertyName(
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
            return new ContextBatchResponseResultsItemExecutedItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContextBatchResponseResultsItemExecutedItemStatus value,
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
        public const string Success = "success";

        public const string EvaluationError = "evaluation_error";

        public const string InfrastructureError = "infrastructure_error";

        public const string SkippedAlreadyRun = "skipped_already_run";
    }
}
