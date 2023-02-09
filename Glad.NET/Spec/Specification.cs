namespace Glad.Net.Spec;

using System.Reflection.Metadata.Ecma335;
using System.Xml;

public abstract class Specification
{
    private XmlElement root = null!;

    public abstract string ApiUrl { get; }

    public Dictionary<string, Command>     Commands   { get; } = new();
    public Dictionary<string, Enumeration> Enums      { get; } = new();
    public Dictionary<string, Extension>   Extensions { get; } = new();
    public Dictionary<string, Feature>     Features   { get; } = new();

    public async Task Load()
    {
        using var client = new HttpClient();
        using var stream = await client.GetStreamAsync(ApiUrl);

        var doc = new XmlDocument();

        doc.Load(stream);

        root = doc.DocumentElement!;

        Parse();
    }

    public void Load(string path)
    {
        var doc = new XmlDocument();

        using var stream = File.Open(path, FileMode.OpenOrCreate);

        doc.Load(stream);

        root = doc.DocumentElement!;

        Parse();
    }

    private void Parse()
    {
        ParseEnums();
        ParseCommands();
        ParseFeatures();
        ParseExtensions();
    }

    private void ParseExtensions()
    {
        foreach (XmlElement ext in root["extensions"]!.GetElementsByTagName("extension"))
        {
            var extension = new Extension(ext);
            Extensions.Add(extension.Name, extension);
        }
    }

    private void ParseFeatures()
    {
        foreach (var node in root.GetElementsByTagName("feature"))
        {
            if (node is XmlElement entry)
            {
                var feature = new Feature(entry);
                Features.Add(feature.Name, feature);
            }
        }
    }

    public async Task ParseAsync() => await new Task(Parse);

    private void ParseEnums()
    {
        foreach (XmlElement enums in root.GetElementsByTagName("enums"))
        {
            var group      = enums.HasAttribute("group") ? enums.GetAttribute("group") : null;
            var @namespace = enums.GetAttribute("namespace");

            if (group != null)
            {
                if (!Enums.TryGetValue(group, out var enumeration))
                {
                    enumeration = new Enumeration
                    {
                        Group     = group,
                        Namespace = @namespace,
                        Type      = enums.HasAttribute("type")    ? enums.GetAttribute("type")   : null,
                        Vendor    = enums.HasAttribute("vendor")  ? enums.GetAttribute("vendor") : null,
                    };

                    Enums.Add(group, enumeration);
                }
                else
                {
                    enumeration.Type   ??= enums.HasAttribute("type")   ? enums.GetAttribute("type") : null;
                    enumeration.Vendor ??= enums.HasAttribute("vendor") ? enums.GetAttribute("vendor") : null;
                }
            }

            foreach (XmlElement @enum in enums.GetElementsByTagName("enum"))
            {
                var member = new EnumMember
                {
                    Name    = @enum.GetAttribute("name") ?? throw new XmlException("Item must have name attribute."),
                    Value   = @enum.GetAttribute("value") ?? throw new XmlException("Value cannot be null/empty."),
                    Alias   = @enum.HasAttribute("alias") ? @enum.GetAttribute("alias") : null,
                    Comment = @enum.HasAttribute("comment") ? @enum.GetAttribute("comment") : null
                };

                if (@enum.HasAttribute("group"))
                {
                    foreach (var anotherGroup in @enum.GetAttribute("group").Split(','))
                    {
                        if (!Enums.TryGetValue(anotherGroup, out var anotherEnumeration))
                        {
                            Enums.Add(anotherGroup, anotherEnumeration = new() { Group = anotherGroup, Namespace = @namespace });
                        }

                        anotherEnumeration.Values.TryAdd(member.Name, member);
                    }
                }
                else if (group == null)
                {
                    var key = "Constants";

                    if (!Enums.TryGetValue(key, out var anotherEnumeration))
                    {
                        Enums.Add(key, anotherEnumeration = new() { Group = key, Namespace = @namespace });
                    }

                    anotherEnumeration.Values.TryAdd(member.Name, member);
                }

                if (group != null)
                {
                    Enums[group].Values.TryAdd(member.Name, member);
                }
            }
        }
    }

    private void ParseCommands()
    {
        foreach (XmlElement node in root["commands"]!.GetElementsByTagName("command"))
        {
            var command = new Command(node);
            Commands.Add(command.Name, command);
        }
    }

    public IEnumerable<Command?> GetCommands(Api api, Version version, Profile profile)
    {
        foreach (var name in Fetch(api, version, profile, FeatureType.Command))
        {
            yield return Commands[name];
        }
    }

    private IEnumerable<string> Fetch(Api api, Version version, Profile profile, FeatureType type)
    {
        var set = new HashSet<string>();
        foreach (var feature in Features.Values)
        {
            if (feature.Version > version)
            {
                continue;
            }

            if (!api.HasFlag(feature.Api))
            {
                continue;
            }

            foreach (var extensionItem in Extensions.Values.SelectMany(x => x).Where(x => x.Type == FeatureType.Command))
            {
                if (!api.HasFlag(extensionItem.RequiredApi))
                {
                    continue;
                }

                if (!profile.HasFlag(extensionItem.RequiredProfile))
                {
                    continue;
                }

                set.Add(extensionItem.Name);
            }

            foreach (var item in feature)
            {
                if (!item.Type.HasFlag(type))
                {
                    continue;
                }

                if (!item.Profile.HasFlag(profile))
                {
                    continue;
                }

                if (item.Action == FeatureAction.Require)
                {
                    set.Add(item.Name);
                }

                if (item.Action == FeatureAction.Remove)
                {
                    set.Remove(item.Name);
                }
            }
        }

        return set;
    }

    public bool TryGetExtension(string extensionItemName, out string? extensionName)
    {
        foreach (var extension in Extensions.Values)
        {
            foreach (var extensionItem in extension)
            {
                if (extensionItem.Name == extensionItemName)
                {
                    extensionName = extension.Name;
                    return true;
                }
            }
        }

        extensionName = null;
        return false;
    }
}
