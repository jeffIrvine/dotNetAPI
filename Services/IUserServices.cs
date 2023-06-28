using dotNetAPI.Models;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUser(Guid id);
    Task<User> CreateUser(User user);
    Task UpdateUser(User user);
    Task<Boolean> UserExists(Guid id);
    Task DeleteUser(Guid id);
}
