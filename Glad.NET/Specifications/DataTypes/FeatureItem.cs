namespace Glad.Net.Specifications.DataTypes;

using System.Xml;
using Glad.Net.Specifications.Enums;

public class FeatureItem : NamedEntry
{
    public Profile       Profile { get; }

    public FeatureType   Type    { get; }

    public FeatureAction Action  { get; }

    public FeatureItem(XmlElement node, Profile profile, FeatureAction action)
    {
        Profile = profile;
        Action  = action;
        Type    = GetFeatureType(node);
        Name    = node.GetAttribute("name");
    }

    private static FeatureType GetFeatureType(XmlElement node)
    {
        var type = node.Name;
        if (type.Equals("command", StringComparison.Ordinal))
        {
            return FeatureType.Command;
        }

        if (type.Equals("enum", StringComparison.Ordinal))
        {
            return FeatureType.Enum;
        }

        return type.Equals("type", StringComparison.Ordinal) ? FeatureType.Type : throw new XmlException($"Unknown feature type: {type}");
    }
}
