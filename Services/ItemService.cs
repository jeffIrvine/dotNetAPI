using MongoDB.Driver;
using dotNetAPI.Models;
using dotNetAPI.Services;

public class ItemService : IItemService
{
    private readonly IMongoCollection<ItemModel> _items;

    public ItemService(IMongoDBContext context)
    {
        _items = context.Items;
    }

    public async Task<IEnumerable<ItemModel>> GetAllItems()
    {
        return await _items.Find(item => true).ToListAsync();
    }

    public async Task<ItemModel> GetItem(Guid id)
    {
        return await _items.Find<ItemModel>(item => item.Id == id).FirstOrDefaultAsync();
    }

    public async Task<ItemModel> CreateItem(ItemModel item)
    {
        await _items.InsertOneAsync(item);
        return item;
    }

    public async Task UpdateItem(Guid id, ItemModel item)
    {
        await _items.ReplaceOneAsync(item => item.Id == id, item);
    }

        public async Task<bool> ItemExists(Guid id)
    {
        return await _items.Find(item => item.Id == id).AnyAsync();
    }

    public async Task DeleteItem(Guid id)
    {
        await _items.DeleteOneAsync(item => item.Id == id);
    }
}
