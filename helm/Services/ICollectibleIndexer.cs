using helm.Models;

namespace helm.Services;

public interface ICollectibleIndexer
{
    string CollectiblesPath { get; }
    Collectible? LoadFromFolder(string folderPath);
    IEnumerable<string> GetCollectibleFolders();
}
