using System.Xml.Serialization;
using helm.Models;

namespace helm.Services;

public sealed class CollectibleIndexer(IWebHostEnvironment env, ILogger<CollectibleIndexer> logger) : ICollectibleIndexer
{
    private readonly XmlSerializer _xmlSerializer = new(typeof(Collectible));

    public string CollectiblesPath { get; init; } = Path.Combine(env.WebRootPath, "collectibles");

    public Collectible? LoadFromFolder(string folderPath)
    {
        var xmlPath = Path.Combine(folderPath, "info.xml");
        if (!File.Exists(xmlPath))
            return null;

        try
        {
            using var stream = File.OpenRead(xmlPath);
            if (_xmlSerializer.Deserialize(stream) is not Collectible item)
                return null;

            item.Id = Path.GetFileName(folderPath);
            foreach (var image in item.Images)
                image.Url = $"/collectibles/{item.Id}/{image.FileName}";

            return item;
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Failed to load collectible from {Path}", xmlPath);
            return null;
        }
    }

    /// <summary>
    /// scans the collectibles directory and returns a list of subdirectories that are not hidden (do not start with '_')
    /// </summary>
    /// <returns></returns>
    public IEnumerable<string> GetCollectibleFolders()
    {
        if (!Directory.Exists(CollectiblesPath))
            return [];

        return Directory.GetDirectories(CollectiblesPath)
            .Where(f => !Path.GetFileName(f).StartsWith('_'));
    }
}
