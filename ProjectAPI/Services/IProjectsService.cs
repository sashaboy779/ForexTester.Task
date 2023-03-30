using ProjectAPI.Entities;

namespace ProjectAPI.Services
{
    public interface IProjectsService
    {
        Task<Project> GetAsync(string id);
        Task CreateAsync(Project project);
        Task<bool> UpdateAsync(string id, Project project);
        Task<bool> DeleteAsync(string id);
        Task<IEnumerable<(string IndicatorName, int Count)>> GetMostUsedIndicatorNames(int top);
    }
}
