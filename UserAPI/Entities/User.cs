namespace UserAPI.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int? SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }
    }
}
