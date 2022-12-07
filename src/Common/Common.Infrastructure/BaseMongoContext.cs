using MongoDB.Driver;

namespace Common.Infrastructure
{
    public class BaseMongoContext
    {
        private readonly IMongoDatabase _database;
        public BaseMongoContext(MongoSettings settings, IMongoClient client)
        {
            _database = client.GetDatabase(settings.DatabaseName);
        }
        public IMongoDatabase GetDataBase()
        {
            return _database;
        }
    }
}
