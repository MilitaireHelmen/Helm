using helm.Models;

namespace helm.Services;

public interface ICollectibleService
{
    IReadOnlyList<Collectible> GetAll();
    Collectible? GetById(string id);
    IReadOnlyList<string> GetCountries();
    IReadOnlyList<string> GetItemTypes();
}
