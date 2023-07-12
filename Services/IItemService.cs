using dotNetAPI.Models;

public interface IItemService
{
    Task<IEnumerable<ItemModel>> GetAllItems();
    Task<ItemModel> GetItem(Guid id);
    Task<ItemModel> CreateItem(ItemModel item);
    Task UpdateItem(Guid id, ItemModel item);
    Task<Boolean> ItemExists(Guid id);
    Task DeleteItem(Guid id);
}
