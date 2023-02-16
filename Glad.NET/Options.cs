namespace Glad.Net;

using Glad.Net.Specifications.Enums;

public record GLOptions
{
    public required SpecType Spec      { get; init; }
    public GLApi            Api        { get; init; } = GLApi.All;
    public Profile          Profile    { get; init; } = Profile.All;
    public HashSet<string>  Extensions { get; init; } = new();
    public Version?         Version    { get; init; }
    public string?          Output     { get; init; }
};

