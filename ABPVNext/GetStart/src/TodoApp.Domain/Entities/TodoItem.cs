#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：TodoItem
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月01日 星期日 15:56
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using Microsoft.IdentityModel.Tokens;
using Volo.Abp.Domain.Entities;

namespace TodoApp.Entities;

public class TodoItem:BasicAggregateRoot<Guid>
{
    public string Text { get; set; }
}