#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：IAuthorRepository
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月03日 星期二 11:46
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Authors;

public interface IAuthorRepository:IRepository<Author,Guid>
{
    Task<Author> FindByNameAsync(string name);

    Task<List<Author>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
    );
}