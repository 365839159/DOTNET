#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：TodoItemDto
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月02日 星期一 10:27
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;

namespace TodoAppMongodb;

public class TodoItemDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
}