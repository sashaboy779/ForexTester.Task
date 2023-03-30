using Riok.Mapperly.Abstractions;
using UserAPI.Entities;
using UserAPI.Models;

namespace UserAPI.Mappers
{
    [Mapper]
    public partial class SubscriptionMapper
    {
        public partial SubscriptionModel MapSubscriptionEntityToModel(Subscription entity);

        public Subscription MapSubscriptionModelToEntity(SubscriptionModel model)
        {
            var result = FromModelToEntity(model);

            result.StartDate = new DateTime(result.StartDate.Ticks, DateTimeKind.Utc);
            result.EndDate = new DateTime(result.EndDate.Ticks, DateTimeKind.Utc);

            return result;
        }

        private partial Subscription FromModelToEntity(SubscriptionModel model);

    }
}
