using MongoDB.Driver;
using ProjectAPI.Entities;

namespace ProjectAPI.Data
{
    public interface IProjectContext
    {
        IMongoCollection<Project> Projects { get; }
    }
}
