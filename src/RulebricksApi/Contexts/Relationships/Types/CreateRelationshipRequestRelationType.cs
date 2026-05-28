using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Contexts;

[JsonConverter(
    typeof(CreateRelationshipRequestRelationType.CreateRelationshipRequestRelationTypeSerializer)
)]
[Serializable]
public readonly record struct CreateRelationshipRequestRelationType : IStringEnum
{
    public static readonly CreateRelationshipRequestRelationType HasMany = new(Values.HasMany);

    public static readonly CreateRelationshipRequestRelationType HasOne = new(Values.HasOne);

    public static readonly CreateRelationshipRequestRelationType BelongsTo = new(Values.BelongsTo);

    public CreateRelationshipRequestRelationType(string value)
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
    public static CreateRelationshipRequestRelationType FromCustom(string value)
    {
        return new CreateRelationshipRequestRelationType(value);
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

    public static bool operator ==(CreateRelationshipRequestRelationType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateRelationshipRequestRelationType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateRelationshipRequestRelationType value) =>
        value.Value;

    public static explicit operator CreateRelationshipRequestRelationType(string value) =>
        new(value);

    internal class CreateRelationshipRequestRelationTypeSerializer
        : JsonConverter<CreateRelationshipRequestRelationType>
    {
        public override CreateRelationshipRequestRelationType Read(
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
            return new CreateRelationshipRequestRelationType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateRelationshipRequestRelationType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateRelationshipRequestRelationType ReadAsPropertyName(
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
            return new CreateRelationshipRequestRelationType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateRelationshipRequestRelationType value,
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
        public const string HasMany = "has_many";

        public const string HasOne = "has_one";

        public const string BelongsTo = "belongs_to";
    }
}
