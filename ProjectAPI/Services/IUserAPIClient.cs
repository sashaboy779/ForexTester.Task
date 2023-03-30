using ProjectAPI.Enums;

namespace ProjectAPI.Services
{
    public interface IUserAPIClient
    {
        public Task<IEnumerable<int>> GetUserIdsBySubscriptionTypeAsync(ESubscriptionType type);
    }
}
