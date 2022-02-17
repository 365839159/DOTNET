using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;

namespace RedisSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RedisListController : ControllerBase
    {
        private readonly string redisConn = "192.168.159.25";
        //private readonly string redisConn = "127.0.0.1";
        private readonly int redisPoint = 6379;

        /// <summary>
        /// 修改 listId 索引 listIndex 的值
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> SetItemInList(string listId, int listIndex, string value)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                redisClinet.SetItemInList(listId, listIndex, value);
                return Task.FromResult(true);
            }
        }

        /// <summary>
        /// 顺序添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> AddItemToList(string listId, string value)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                redisClinet.AddItemToList(listId, value);
                return Task.FromResult(true);
            }
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> PushItemToList(string listId, string value)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                redisClinet.PushItemToList(listId, value);
                return Task.FromResult(true);
            }
        }

        /// <summary>
        /// 倒加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> PrependItemToList(string listId, string value)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                redisClinet.PrependItemToList(listId, value);
                redisClinet.ExpireEntryAt(listId, DateTime.Now.AddSeconds(10));
                //Task.Delay(1 * 1000).Wait();
                return Task.FromResult(true);
            }
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> AddRangeToList(string listId, List<string> values)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                redisClinet.AddRangeToList(listId, values);
                return Task.FromResult(true);
            }
        }

        /// <summary>
        /// 批量查询
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<List<string>> GetAllItemsFromList(string listId, List<string> values)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClinet.GetAllItemsFromList(listId);
                return Task.FromResult(result);
            }
        }

        /// <summary>
        /// 移除单个
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<long> RemoveItemFromList(string listId, string value)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClinet.RemoveItemFromList(listId, value);
                return Task.FromResult(result);
            }
        }

        /// <summary>
        /// 移除单个
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<bool> RemoveAllFromList(string listId)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                redisClinet.RemoveAllFromList(listId);
                return Task.FromResult(true);
            }
        }


        /// <summary>
        /// 按下标查询
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<List<string>> GetRangeFromList(string listId, int startFrom, int endingAt)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClinet.GetRangeFromList(listId, startFrom, endingAt);
                return Task.FromResult(result);
            }
        }

        /// <summary>
        /// 移除尾部，返回结果
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<string> RemoveEndFromList(string listId, int startFrom, int endingAt)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClinet.RemoveEndFromList(listId);
                return Task.FromResult(result);
            }
        }

        /// <summary>
        /// 移除头部，返回结果
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<string> RemoveStartFromList(string listId)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClinet.RemoveStartFromList(listId);
                return Task.FromResult(result);
            }
        }


        /// <summary>
        /// 从一个 list 尾部移除 ，添加另一个 list 头部,并返回结果
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<string> PopAndPushItemBetweenLists(string listId, string newListId)
        {
            using (IRedisClient redisClinet = new RedisClient(redisConn, redisPoint))
            {
                var result = redisClinet.PopAndPushItemBetweenLists(listId, newListId);
                return Task.FromResult(result);
            }
        }

    }
}
