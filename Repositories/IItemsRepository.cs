using RestService.Entities;

namespace RestService.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> GetItemAsync(Guid id);

        Task<IEnumerable<Item>> GetItemsAsync();

        Task CreateItemAsync (Item item);

        Task ReplaseItemAsync(Item item);

        Task DeleteItemAsync (Guid id);
    }
}