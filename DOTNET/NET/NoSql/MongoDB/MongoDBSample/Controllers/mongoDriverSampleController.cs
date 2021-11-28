using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace MongoDBSample.Controllers
{
    public class mongoDriverSampleController : BaseController
    {
        private readonly ILogger<MongoDbSampleController> _logger;
        private readonly IMongoClient _mongoClient = new MongoClient("mongodb://47.94.85.108:27017");
        private readonly IMongoDatabase _mongoDatabase;

        public mongoDriverSampleController(ILogger<MongoDbSampleController> logger)
        {
            _logger = logger;
            _mongoDatabase = _mongoClient.GetDatabase("mongodbSample");
        }
    }
}