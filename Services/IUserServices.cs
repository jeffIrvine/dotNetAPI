using dotNetAPI.Models;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetAllUsers();
    Task<UserModel> GetUser(Guid id);
    Task<UserModel> CreateUser(UserModel user);
    Task UpdateUser(UserModel user);
    Task<Boolean> UserExists(Guid id);
    Task DeleteUser(Guid id);
}
