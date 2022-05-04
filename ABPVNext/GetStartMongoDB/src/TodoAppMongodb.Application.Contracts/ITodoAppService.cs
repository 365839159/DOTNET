#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：ITodoAppService
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月02日 星期一 10:25
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
using Volo.Abp.Application.Services;

namespace TodoAppMongodb;

public interface ITodoAppService:IApplicationService
{
    Task<List<TodoItemDto>> GetListAsync();
    Task<TodoItemDto> CreateAsync(string text);
    Task DeleteAsync(Guid id);
}