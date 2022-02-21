using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;

namespace RedisSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisSetAndZSetController : ControllerBase
    {
        //private readonly string redisConn = "192.168.159.25";
        private readonly string redisConn = "127.0.0.1";
        private readonly int redisPoint = 6379;
        //set 是一个自动去重的集合

        /// <summary>
        /// 向 set 集合中添加 item
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> AddItemToSet(string setId, string item)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                redisClient.AddItemToSet(setId, item);
                return Task.FromResult(true);
            }
        }


        /// <summary>
        /// 向 set 集合中批量添加 item
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> AddRangeToSet(string setId, List<string> item)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                redisClient.AddRangeToSet(setId, item);
                return Task.FromResult(true);
            }
        }


        /// <summary>
        /// 获取所有得项
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<object> GetAllItemFromSet(string setId)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.GetAllItemsFromSet(setId);
                return Task.FromResult<object>(result.ToList());
            }
        }


        /// <summary>
        /// 随机获取一个值
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> GetRandomItemFromSet(string setId)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.GetRandomItemFromSet(setId);
                return Task.FromResult<object>(result);
            }
        }

        /// <summary>
        /// 随机删除集合中得元素，返回结果并删除
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> PopItemFromSet(string setId)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.PopItemFromSet(setId);
                return Task.FromResult<object>(result);
            }
        }



        /// <summary>
        /// 根据值删除
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> RemoveItemFromSet(string setId, string item)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                redisClient.RemoveItemFromSet(setId, item);
                return Task.FromResult<object>(true);
            }
        }

        /// <summary>
        /// 从原集合移除值，写到新得集合中去
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> MoveBetweenSets(string fromSetId, string toSetId, string item)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                redisClient.MoveBetweenSets(fromSetId, toSetId, item);
                return Task.FromResult<object>(true);
            }
        }


        /// <summary>
        /// 交集
        /// </summary>
        /// <param name="fromSetId"></param>
        /// <param name="toSetId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> GetIntersectFromSets(string setId1, string setId2)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.GetIntersectFromSets(setId1, setId2);
                return Task.FromResult<object>(result.ToList());
            }
        }


        /// <summary>
        /// 并集
        /// </summary>
        /// <param name="fromSetId"></param>
        /// <param name="toSetId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> GetUnionFromSets(string setId1, string setId2)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.GetUnionFromSets(setId1, setId2);
                return Task.FromResult<object>(result.ToList());
            }
        }



        //===================zset 自动去重，而且多了一个权重，或者分数得字段，自动排序

        /// <summary>
        /// 添加项
        /// </summary>
        /// <param name="zsetId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> AddItemToSortedSet(string zsetId, string item, double score)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {

                var result = redisClient.AddItemToSortedSet(zsetId, item, score);
                return Task.FromResult<object>(result);
            }
        }

        /// <summary>
        /// 批量添加添加项
        /// </summary>
        /// <param name="zsetId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> AddRangeToSortedSet(string zsetId, List<string> values, double score)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {

                var result = redisClient.AddRangeToSortedSet(zsetId, values, score);
                return Task.FromResult<object>(result);
            }
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="zsetId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> GetAllItemsFromSortedSet(string zsetId)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.GetAllItemsFromSortedSet(zsetId);
                return Task.FromResult<object>(result);
            }
        }

        /// <summary>
        ///  获取范围数据
        /// </summary>
        /// <param name="zsetId"></param>
        /// <param name="fromRank"></param>
        /// <param name="toRank"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<object> GetRangeFromSortedSet(string zsetId, int fromRank, int toRank)
        {
            using (IRedisClient redisClient = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClient.GetRangeFromSortedSet(zsetId, fromRank, toRank);
                return Task.FromResult<object>(result);
            }
        }

    }
}
