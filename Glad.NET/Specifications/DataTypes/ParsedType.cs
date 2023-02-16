namespace Glad.Net.Specifications.DataTypes;

using System.Text.RegularExpressions;
using System.Xml;

public partial class ParsedType : NamedEntry
{
    private static readonly Regex ArrayPattern = GenerateArrayPattern();
    public bool    IsArray      { get; }
    public bool    IsConst      { get; }
    public bool    IsPointer    { get; }
    public bool    IsStruct     { get; }
    public bool    IsUnsigned   { get; }
    public string? OriginalType { get; }
    public string  Type         { get; }

    public ParsedType(XmlElement node) : base(node)
    {
        OriginalType = node["type"]?.InnerText;

        var ptype = node["ptype"];

        if (ptype != null)
        {
            Type = ptype.InnerText.Replace("struct", "");
        }
        else
        {
            Type = node.InnerText
                .Replace("const", "")
                .Replace("unsigned", "")
                .Replace("struct", "")
                .Replace("*", "")
                .Trim()
                .Split(" ", 1)[0];
        }

        IsPointer  = node.InnerText.Contains('*');
        IsArray    = ArrayPattern.IsMatch(node.InnerText);
        IsConst    = node.InnerText.Contains("const");
        IsUnsigned = node.InnerText.Contains("unsigned");
        IsStruct   = node.InnerText.Contains("struct");
    }

    [GeneratedRegex(@"\[(\d+)\]")]
    private static partial Regex GenerateArrayPattern();
}
