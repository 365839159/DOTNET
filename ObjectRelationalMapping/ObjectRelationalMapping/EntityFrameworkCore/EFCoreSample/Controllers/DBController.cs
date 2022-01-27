using EFCoreSample.DbContexts;
using EFCoreSample.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DBController : ControllerBase
    {
        private readonly DbContextBase  _dbContextBase;
        public DBController(DbContextBase  dbContextBase)
        {
            _dbContextBase = dbContextBase;
        }
        [HttpGet(Name = "GetTestsAsync")]
        public async Task<object> GetTestsAsync()
        {
            var response = await _dbContextBase.Test.ToListAsync();
            return response;
        }

        [HttpPost(Name = "InsertTestAsync")]
        public async Task<object> InsertTestAsync(Test test)
        {
            var response = await _dbContextBase.Test.AddAsync(test);
            var count = await _dbContextBase.SaveChangesAsync();
            return new { response.Entity  , count };
        }
    }
}
