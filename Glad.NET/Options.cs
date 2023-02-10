namespace Glad.Net;
using Glad.Net.Spec;

public record Options(Api Api, Profile Profile = default, HashSet<string>? Extensions = default, Version? Version = default);

