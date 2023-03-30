namespace UserAPI.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int? SubscriptionId { get; set; }
    }
}
