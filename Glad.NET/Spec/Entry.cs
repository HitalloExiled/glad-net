namespace Glad.Net.Spec;

using System.Xml;

public abstract class Entry
{
    public string? Comment { get; init; }

    protected Entry()
    { }

    protected Entry(XmlElement node) =>
        Comment = node.HasAttribute("comment") ? node.GetAttribute("comment") : null;
}
