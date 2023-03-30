using UserAPI.Enums;

namespace UserAPI.Models
{
    public class SubscriptionModel : BaseModel
    {
        public ESubscriptionType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
