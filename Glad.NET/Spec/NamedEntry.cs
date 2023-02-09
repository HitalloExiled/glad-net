namespace Glad.Net.Spec;

using System.Xml;

public class NamedEntry : Entry, INamed
{
    public string Name { get; init; } = null!;

    public NamedEntry() { }

    public NamedEntry(XmlElement node) : base(node)
    {
        Name = node.GetAttribute("name");

        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new XmlException("Item must have name attribute.");
        }
    }

    public override string ToString() => Name;
}
