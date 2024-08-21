using MongoDB.Driver;
using ResolutionAndCommentsService.models;

namespace ResolutionAndCommentsService.Data
{
    public class ResolutionsAndCommentsDbContext
    {
        private readonly IMongoDatabase _database;

        public ResolutionsAndCommentsDbContext(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("resolutionsandcommentsdb");
        }

        public IMongoCollection<Resolution> Resolutions => _database.GetCollection<Resolution>("resolutions");
        public IMongoCollection<Comment> Comments => _database.GetCollection<Comment>("comments");
    }
}
