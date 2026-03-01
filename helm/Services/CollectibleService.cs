using helm.Models;

namespace helm.Services;

public sealed class CollectibleService(ICollectibleIndexer indexer,ILogger<CollectibleService> logger) : ICollectibleService
{
    private readonly Dictionary<string, Collectible> _cache = BuildIndex(indexer, logger);

    private static Dictionary<string, Collectible> BuildIndex(ICollectibleIndexer indexer, ILogger<CollectibleService> logger)
    {
        var items = indexer.GetCollectibleFolders()
            .AsParallel()
            .Select(indexer.LoadFromFolder)
            .Where(item => item is not null)
            .ToDictionary(item => item!.Id, item => item!, StringComparer.OrdinalIgnoreCase);

        logger.LogInformation("Indexed {Count} collectibles", items.Count);
        return items;
    }

    public IReadOnlyList<Collectible> GetAll() => [.. _cache.Values];

    public Collectible? GetById(string id) => _cache.GetValueOrDefault(id);

    public IReadOnlyList<string> GetCountries() =>
        [.. GetAll()
            .Select(c => c.Country)
            .Where(c => !string.IsNullOrWhiteSpace(c))
            .Distinct()
            .OrderBy(c => c)];

    public IReadOnlyList<string> GetItemTypes() =>
        [.. GetAll()
            .Select(c => c.ItemType)
            .Where(t => !string.IsNullOrWhiteSpace(t))
            .Distinct()
            .OrderBy(t => t)];
}

