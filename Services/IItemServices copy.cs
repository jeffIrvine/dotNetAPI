using dotNetAPI.Models;

public interface IItemService
{
    Task<IEnumerable<Item>> GetAllItems();
    Task<Item> GetItem(Guid id);
    Task<Item> CreateItem(Item item);
    Task UpdateItem(Item item);
    Task<Boolean> ItemExists(Guid id);
    Task DeleteItem(Guid id);
}
