using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(ContextBatchResponseResultsItemReason.ContextBatchResponseResultsItemReasonSerializer)
)]
[Serializable]
public readonly record struct ContextBatchResponseResultsItemReason : IStringEnum
{
    public static readonly ContextBatchResponseResultsItemReason NotReady = new(Values.NotReady);

    public static readonly ContextBatchResponseResultsItemReason InputsUnchanged = new(
        Values.InputsUnchanged
    );

    public static readonly ContextBatchResponseResultsItemReason NoBoundAssets = new(
        Values.NoBoundAssets
    );

    public static readonly ContextBatchResponseResultsItemReason AutoExecuteDisabled = new(
        Values.AutoExecuteDisabled
    );

    public static readonly ContextBatchResponseResultsItemReason ExecutionUnavailable = new(
        Values.ExecutionUnavailable
    );

    public ContextBatchResponseResultsItemReason(string value)
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
    public static ContextBatchResponseResultsItemReason FromCustom(string value)
    {
        return new ContextBatchResponseResultsItemReason(value);
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

    public static bool operator ==(ContextBatchResponseResultsItemReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ContextBatchResponseResultsItemReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ContextBatchResponseResultsItemReason value) =>
        value.Value;

    public static explicit operator ContextBatchResponseResultsItemReason(string value) =>
        new(value);

    internal class ContextBatchResponseResultsItemReasonSerializer
        : JsonConverter<ContextBatchResponseResultsItemReason>
    {
        public override ContextBatchResponseResultsItemReason Read(
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
            return new ContextBatchResponseResultsItemReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ContextBatchResponseResultsItemReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ContextBatchResponseResultsItemReason ReadAsPropertyName(
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
            return new ContextBatchResponseResultsItemReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ContextBatchResponseResultsItemReason value,
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
        public const string NotReady = "not_ready";

        public const string InputsUnchanged = "inputs_unchanged";

        public const string NoBoundAssets = "no_bound_assets";

        public const string AutoExecuteDisabled = "auto_execute_disabled";

        public const string ExecutionUnavailable = "execution_unavailable";
    }
}
