namespace Glad.Net.Spec;

public class EnumMember : NamedEntry
{
    public required string Value { get; init; }
    public required string? Alias { get; init; }
}
