using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Entities;
using UserAPI.Enums;

namespace UserAPI.Services
{
    public class SubscriptionsService : ISubscriptionsService
    {
        private readonly UserDbContext _context;

        public SubscriptionsService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateSubscriptionAsync(int userId, Subscription subscription)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return false;
            }

            user.Subscription = subscription;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Subscription> GetSubscriptionAsync(int userId, int subscriptionId)
        {
            return await _context.Users
                .Where(u => u.Id == userId && u.SubscriptionId == subscriptionId)
                .Select(u => u.Subscription)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<int>> GetUserIdsBySubscriptionTypeAsync(ESubscriptionType type)
        {
            return await _context.Users
                .Where(u => u.Subscription.Type == type)
                .Select(u => u.Id)
                .Distinct()
                .ToListAsync();
        }
    }
}
