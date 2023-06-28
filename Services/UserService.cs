using MongoDB.Driver;
using dotNetAPI.Models;

public class UserService : IUserService
{
    private readonly IMongoCollection<User> _users;

    public UserService(MongoDBContext context)
    {
        _users = context.Users;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _users.Find(user => true).ToListAsync();
    }

    public async Task<User> GetUser(Guid id)
    {
        return await _users.Find<User>(user => user.Id == id).FirstOrDefaultAsync();
    }

    public async Task<User> CreateUser(User user)
    {
        await _users.InsertOneAsync(user);
        return user;
    }

    public async Task UpdateUser(User userIn)
    {
        await _users.ReplaceOneAsync(user => user.Id == userIn.Id, userIn);
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
