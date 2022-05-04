#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：TodoItem
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月02日 星期一 10:21
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using Volo.Abp.Domain.Entities;

namespace TodoAppMongodb;

public class TodoItem : BasicAggregateRoot<Guid>
{
    public string Text { set; get; }
}