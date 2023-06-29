using MongoDB.Driver;
using dotNetAPI.Models;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;


public class MongoDBContext
{
    private readonly IMongoDatabase _db;

    public MongoDBContext(IConfiguration config)
    {
        var connectionString = config.GetSection("MongoDbSettings:ConnectionString").Value;
        var databaseName = config.GetSection("MongoDbSettings:DatabaseName").Value;
        var client = new MongoClient(connectionString);
        _db = client.GetDatabase(databaseName);
    }

    public IMongoCollection<UserModel> Users => _db.GetCollection<UserModel>("Users");

    public IMongoCollection<ItemModel> Items => _db.GetCollection<ItemModel>("Items");
}
