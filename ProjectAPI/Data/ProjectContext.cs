using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectAPI.Configurations;
using ProjectAPI.Entities;

namespace ProjectAPI.Data
{
    public class ProjectContext : IProjectContext
    {
        public IMongoCollection<Project> Projects { get; }

        public ProjectContext(IOptions<MongoDBSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var db = client.GetDatabase(options.Value.Database);
            Projects = db.GetCollection<Project>(nameof(Projects));
        }
    }
}
