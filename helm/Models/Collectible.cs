using System.Xml.Serialization;

namespace helm.Models;

[XmlRoot("collectible")]
public sealed class Collectible
{
    [XmlIgnore]
    public string Id { get; set; } = string.Empty;

    [XmlElement("name")]
    public string Name { get; set; } = string.Empty;

    [XmlElement("type")]
    public string ItemType { get; set; } = string.Empty;

    [XmlElement("country")]
    public string Country { get; set; } = string.Empty;

    [XmlElement("date")]
    public string? Date { get; set; }

    [XmlElement("description")]
    public string Description { get; set; } = string.Empty;

    [XmlArray("images")]
    [XmlArrayItem("image")]
    public List<CollectibleImage> Images { get; set; } = [];

    [XmlIgnore]
    public CollectibleImage? PrimaryImage =>
        Images.FirstOrDefault(i => i.IsPrimary) ?? Images.FirstOrDefault();
}
