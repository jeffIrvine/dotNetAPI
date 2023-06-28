using MongoDB.Driver;
using dotNetAPI.Models;

public class ItemService : IItemService
{
    private readonly IMongoCollection<Item> _items;

    public ItemService(MongoDBContext context)
    {
        _items = context.Items;
    }

    public async Task<IEnumerable<Item>> GetAllItems()
    {
        return await _items.Find(item => true).ToListAsync();
    }

    public async Task<Item> GetItem(Guid id)
    {
        return await _items.Find<Item>(item => item.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Item> CreateItem(Item item)
    {
        await _items.InsertOneAsync(item);
        return item;
    }

    public async Task UpdateItem(Item itemIn)
    {
        await _items.ReplaceOneAsync(item => item.Id == itemIn.Id, itemIn);
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
