using MongoDB.Driver;
using dotNetAPI.Models;
using dotNetAPI.Services;

public class UserService : IUserService
{
    private readonly IMongoCollection<UserModel> _users;

    public UserService(IMongoDBContext context)
    {
        _users = context.Users;
    }

    public async Task<IEnumerable<UserModel>> GetAllUsers()
    {
        return await _users.Find(user => true).ToListAsync();
    }

    public async Task<UserModel> GetUser(Guid id)
    {
        return await _users.Find<UserModel>(user => user.Id == id).FirstOrDefaultAsync();
    }

    public async Task<UserModel> CreateUser(UserModel user)
    {
        await _users.InsertOneAsync(user);
        return user;
    }

    public async Task UpdateUser(UserModel user)
    {
        var filter = Builders<UserModel>.Filter.Eq(u => u.Id, user.Id);
        await _users.ReplaceOneAsync(filter, user);
    }

    public async Task<bool> UserExists(Guid id)
    {
        return await _users.Find(user => user.Id == id).AnyAsync();
    }

    public async Task DeleteUser(Guid id)
    {
        await _users.DeleteOneAsync(user => user.Id == id);
    }
}
