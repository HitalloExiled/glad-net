namespace Glad.Net.Specifications.DataTypes;

using System.Xml;

public abstract class CommandItem : Entry, INamed
{
    public string       Name      { get; }

    public List<string> Words    { get; }

    public string       Canonical => string.Join(' ', Words);

    public string?      Group     { get; }

    protected CommandItem(XmlElement node) : base(node)
    {
        Name = node["name"]!.InnerText;
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new XmlException("Prototype name cannot be null/empty.");
        }

        Words = new List<string>();
        foreach (XmlNode child in node.ChildNodes)
        {
            Words.Add(child.InnerText.Trim());
        }

        Group = node.HasAttribute("group") ? node.GetAttribute("group") : null;
    }

    public override string ToString() => Name;
}
