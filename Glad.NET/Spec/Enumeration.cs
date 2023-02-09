namespace Glad.Net.Spec;

public class Enumeration
{
    public required string Group { get; init; }
    public required string Namespace { get; init; }

    public string? Type { get; set; }
    public string? Vendor { get; set; }

    public Dictionary<string, EnumMember> Values { get; } = new();
}
