using UserAPI.Entities;
using UserAPI.Enums;

namespace UserAPI.Services
{
    public interface ISubscriptionsService
    {
        Task<bool> CreateSubscriptionAsync(int userId, Subscription subscription);
        Task<Subscription> GetSubscriptionAsync(int userId, int subscriptionId);
        Task<IEnumerable<int>> GetUserIdsBySubscriptionTypeAsync(ESubscriptionType type);
    }
}
