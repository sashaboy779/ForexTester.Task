using ProjectAPI.Entities;
using ProjectAPI.Enums;
using ProjectAPI.Repositories;

namespace ProjectAPI.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectRepository _repository;
        private readonly IUserAPIClient _userClient;

        public ProjectsService(IProjectRepository repository, IUserAPIClient userClient)
        {
            _repository = repository;
            _userClient = userClient;
        }

        public async Task CreateAsync(Project project)
        {
            await _repository.CreateAsync(project);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<Project> GetAsync(string id)
        {
            return _repository.GetAsync(id);
        }

        public Task<bool> UpdateAsync(string id, Project project)
        {
            return _repository.UpdateAsync(id, project);
        }

        public async Task<IEnumerable<(string IndicatorName, int Count)>> GetMostUsedIndicatorNames(int top)
        {
            var userIds = await _userClient.GetUserIdsBySubscriptionTypeAsync(ESubscriptionType.Super);

            if (!userIds.Any())
                return Enumerable.Empty<(string, int)>();

            var result = _repository.GetMostUsedIndicatorNames(top, userIds);
            return result;
        }
    }
}
