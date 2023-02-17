namespace Glad.Net.Specifications.DataTypes;

using System.Xml;

public class Parameter : CommandItem
{
    public string? LengthParam { get; }

    public ParsedType Type { get; }

    public Parameter(XmlElement node) : base(node)
    {
        LengthParam = node.HasAttribute("len") ? node.GetAttribute("len") : null;
        Type        = new ParsedType(node);
    }
}
