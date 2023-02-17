namespace Glad.Net;

using Glad.Net.Specifications.Enums;

public record Options
{
    public required Api Api { get; init; } = Api.All;

    public Profile         Profile    { get; init; } = Profile.All;
    public HashSet<string> Extensions { get; init; } = new();
    public Version?        Version    { get; init; }
    public string?         Output     { get; init; }
};
