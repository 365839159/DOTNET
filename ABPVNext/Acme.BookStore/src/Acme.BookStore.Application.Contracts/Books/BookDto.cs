#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：BookDto
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月02日 星期一 21:57
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Books;

public class BookDto:AuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public BookType Type { get; set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }
    
    public Guid AuthorId { get; set; }
    
    public string AuthorName { get; set; }
}