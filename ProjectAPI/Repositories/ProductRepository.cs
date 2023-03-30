using MongoDB.Bson;
using MongoDB.Driver;
using ProjectAPI.Data;
using ProjectAPI.Entities;

namespace ProjectAPI.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IProjectContext _context;

        public ProjectRepository(IProjectContext context)
        {
            _context = context;
        }

        public async Task<Project> GetAsync(string id)
        {
            return await _context.Projects
                .Find(project => project.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Project project)
        {
            await _context.Projects
                .InsertOneAsync(project);
        }

        public async Task<bool> UpdateAsync(string id, Project replacement)
        {
            var result = await _context.Projects
                .ReplaceOneAsync(project => project.Id == id, replacement);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.Projects
                .DeleteOneAsync(project => project.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public IEnumerable<(string IndicatorName, int Count)> GetMostUsedIndicatorNames(int top, IEnumerable<int> userIds)
        {
            var pipeline = new List<BsonDocument>
            {
                new BsonDocument("$match", new BsonDocument("userId", new BsonDocument("$in", new BsonArray(userIds)))),
                new BsonDocument("$unwind", "$charts"),
                new BsonDocument("$unwind", "$charts.indicators"),
                new BsonDocument("$group", new BsonDocument
                {
                    { "_id", "$charts.indicators.name" },
                    { "count", new BsonDocument("$sum", 1) }
                }),
                new BsonDocument("$sort", new BsonDocument("count", -1)),
                new BsonDocument("$limit", top),
                new BsonDocument("$project", new BsonDocument
                {
                    { "_id", 0 },
                    { "name", "$_id" },
                    { "used", "$count" }
                })
            };

            return _context.Projects
                .Aggregate<BsonDocument>(pipeline)
                .ToList()
                .Select(bd => ValueTuple.Create(bd["name"].AsString, bd["used"].AsInt32))
                .ToList();
        }
    }
}
