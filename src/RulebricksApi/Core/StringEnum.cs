using System.Text.Json.Serialization;

namespace RulebricksApi.Core;

public interface IStringEnum : IEquatable<string>
{
    public string Value { get; }
}
