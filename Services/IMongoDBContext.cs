using dotNetAPI.Models;
using MongoDB.Driver;

namespace dotNetAPI.Services
{
    public interface IMongoDBContext
    {
        IMongoCollection<UserModel> Users { get; }
        IMongoCollection<ItemModel> Items { get; }
    }
}