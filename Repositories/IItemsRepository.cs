using RestService.Entities;

namespace RestService.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);

        IEnumerable<Item> GetItems();
    }
}