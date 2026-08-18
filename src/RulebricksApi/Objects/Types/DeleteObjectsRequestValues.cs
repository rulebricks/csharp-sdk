using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[JsonConverter(typeof(DeleteObjectsRequestValues.DeleteObjectsRequestValuesSerializer))]
[Serializable]
public readonly record struct DeleteObjectsRequestValues : IStringEnum
{
    public static readonly DeleteObjectsRequestValues Archive = new(Values.Archive);

    public static readonly DeleteObjectsRequestValues Detach = new(Values.Detach);

    public DeleteObjectsRequestValues(string value)
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
    public static DeleteObjectsRequestValues FromCustom(string value)
    {
        return new DeleteObjectsRequestValues(value);
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

    public static bool operator ==(DeleteObjectsRequestValues value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeleteObjectsRequestValues value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeleteObjectsRequestValues value) => value.Value;

    public static explicit operator DeleteObjectsRequestValues(string value) => new(value);

    internal class DeleteObjectsRequestValuesSerializer : JsonConverter<DeleteObjectsRequestValues>
    {
        public override DeleteObjectsRequestValues Read(
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
            return new DeleteObjectsRequestValues(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DeleteObjectsRequestValues value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DeleteObjectsRequestValues ReadAsPropertyName(
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
            return new DeleteObjectsRequestValues(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DeleteObjectsRequestValues value,
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
        public const string Archive = "archive";

        public const string Detach = "detach";
    }
}
