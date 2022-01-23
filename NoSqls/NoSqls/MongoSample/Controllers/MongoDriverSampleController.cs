using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MongoSample.Controllers
{
    public class MongoDriverSampleController : BaseController
    {
        private readonly ILogger<MongoSampleController> _logger;
        private readonly IMongoClient _mongoClient = new MongoClient("mongodb://localhost:27017");
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDriverSampleController(ILogger<MongoSampleController> logger)
        {
            _logger = logger;
            _mongoDatabase = _mongoClient.GetDatabase("zxc");
        }

        /// <summary>
        /// 查询所有文档
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> FindAll(Dictionary<string, object> pram)
        {

            //var zoneListStr = JsonConvert.SerializeObject(pram);
            //var zoneList = JsonConvert.DeserializeObject<B>(zoneListStr);

            foreach (var item in pram)
            {

            }

            List<Dictionary<string, object>> filterList = new List<Dictionary<string, object>>();
            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            var collection = _mongoDatabase.GetCollection<BsonDocument>("inventory");
            var result = collection.Find(filter).Project(projection).ToList();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (var item in result)
            {
                var dic = item.ToDictionary();
                data.Add(dic);
            }

            return data;
        }

        //public void Digui(List<string> filterList, Dictionary<string, object> keys,Dictionary<string,object> obj)
        //{
        //    if (keys["Chinds"] != null)
        //        Digui(filterList, JsonConvert.DeserializeObject<Dictionary<string, object>>(keys["Chinds"].ToString()), obj);
        //}

    }
}