using ProjectAPI.Entities;

namespace ProjectAPI.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetAsync(string id);
        Task CreateAsync(Project project);
        Task<bool> UpdateAsync(string id, Project replacement);
        Task<bool> DeleteAsync(string id);
        IEnumerable<(string IndicatorName, int Count)> GetMostUsedIndicatorNames(int top, IEnumerable<int> userIds);
    }
}