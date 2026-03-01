using System.Xml.Serialization;

namespace helm.Models;

public sealed class CollectibleImage
{
    [XmlAttribute("primary")]
    public bool IsPrimary { get; set; }

    [XmlAttribute("caption")]
    public string? Caption { get; set; }

    [XmlText]
    public string FileName { get; set; } = string.Empty;

    [XmlIgnore]
    public string Url { get; set; } = string.Empty;
}
