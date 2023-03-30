using UserAPI.Data;
using UserAPI.Entities;

namespace UserAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserDbContext _context;

        public UsersService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
