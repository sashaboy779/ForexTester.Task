using UserAPI.Enums;

namespace UserAPI.Entities
{
    public class Subscription : BaseEntity
    {
        public ESubscriptionType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
