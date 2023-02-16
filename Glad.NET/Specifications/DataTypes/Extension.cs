namespace Glad.Net.Specifications.DataTypes;

using System.Collections.Generic;
using System.Xml;
using Glad.Net.Specifications.Enums;

public class Extension : NamedEntryCollection<ExtensionItem>
{
    public GLApi    Supported { get; }
    public string Type { get; }

    public Extension(XmlElement node) : base(node)
    {
        Type = Name.Split("_")[1];

        var supported = node.GetAttribute("supported");
        if (string.IsNullOrWhiteSpace(supported))
        {
            throw new XmlException("Extension must define supported API(s).");
        }

        foreach (var api in supported.Split('|'))
        {
            var flag = Enum.Parse<GLApi>(api, true);
            Supported |= flag;
        }

        foreach (XmlElement child in node.GetElementsByTagName("require"))
        {
            var api = child.HasAttribute("api")
                ? Enum.Parse<GLApi>(child.GetAttribute("api"), true)
                : Supported;

            var profile = child.HasAttribute("profile")
                ? Enum.Parse<Profile>(child.GetAttribute("profile"), true)
                : Profile.All;

            foreach (var element in child.ChildNodes)
            {
                if (element is XmlElement item)
                {
                    Add(new ExtensionItem(item, api, profile));
                }
            }
        }
    }

    public bool CanInclude(HashSet<string> extensions) =>
        extensions.Contains(Type) || extensions.Contains(Name);
}

public class ExtensionItem : FeatureItem
{
    public GLApi     RequiredApi { get; }

    public Profile RequiredProfile { get; }

    public ExtensionItem(XmlElement node, GLApi api, Profile profile) : base(node, profile, FeatureAction.Require)
    {
        RequiredApi     = api;
        RequiredProfile = profile;
    }
}
