using ProjectAPI.Configurations;
using ProjectAPI.Enums;
using System.Text.Json;

namespace ProjectAPI.Services
{
    public class UserAPIClient : IUserAPIClient
    {
        private readonly HttpClient _httpClient;

        public UserAPIClient(HttpClient httpClient)
        {
            var url = Environment.GetEnvironmentVariable(Constants.UserAPIEnvironmentVariable);
            url = url.EndsWith("/") ? url : url + "/";

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(url);
        }

        public async Task<IEnumerable<int>> GetUserIdsBySubscriptionTypeAsync(ESubscriptionType type)
        {
            var response = await _httpClient.GetAsync($"/api/v1/users/subscriptions/{type}");
            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<int>();
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<int>>(json);
        }
    }
}
