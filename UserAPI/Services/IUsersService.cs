using UserAPI.Entities;

namespace UserAPI.Services
{
    public interface IUsersService
    {
        Task<bool> CreateUserAsync(User user);
        Task<User> GetUserAsync(int id);
    }
}
