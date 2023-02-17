namespace Glad.Net.Specifications.DataTypes;

using System.Xml;

public class Prototype : CommandItem
{
    public ParsedType Type { get; }

    public Prototype(XmlElement node) : base(node) => Type = new(node);
}
