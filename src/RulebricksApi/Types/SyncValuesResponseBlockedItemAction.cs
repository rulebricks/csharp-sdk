using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(
    typeof(SyncValuesResponseBlockedItemAction.SyncValuesResponseBlockedItemActionSerializer)
)]
[Serializable]
public readonly record struct SyncValuesResponseBlockedItemAction : IStringEnum
{
    public static readonly SyncValuesResponseBlockedItemAction Archived = new(Values.Archived);

    public SyncValuesResponseBlockedItemAction(string value)
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
    public static SyncValuesResponseBlockedItemAction FromCustom(string value)
    {
        return new SyncValuesResponseBlockedItemAction(value);
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

    public static bool operator ==(SyncValuesResponseBlockedItemAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SyncValuesResponseBlockedItemAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SyncValuesResponseBlockedItemAction value) =>
        value.Value;

    public static explicit operator SyncValuesResponseBlockedItemAction(string value) => new(value);

    internal class SyncValuesResponseBlockedItemActionSerializer
        : JsonConverter<SyncValuesResponseBlockedItemAction>
    {
        public override SyncValuesResponseBlockedItemAction Read(
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
            return new SyncValuesResponseBlockedItemAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SyncValuesResponseBlockedItemAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SyncValuesResponseBlockedItemAction ReadAsPropertyName(
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
            return new SyncValuesResponseBlockedItemAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SyncValuesResponseBlockedItemAction value,
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
        public const string Archived = "archived";
    }
}
