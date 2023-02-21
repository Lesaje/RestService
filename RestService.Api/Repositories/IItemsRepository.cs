using RestService.Api.Entities;

namespace RestService.Api.Repositories
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