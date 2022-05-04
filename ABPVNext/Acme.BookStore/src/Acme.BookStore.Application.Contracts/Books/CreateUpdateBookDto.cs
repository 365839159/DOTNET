#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：CreateUpdateBookDto
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月02日 星期一 21:59
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Books;

public class CreateUpdateBookDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [Required]
    public BookType Type { get; set; } = BookType.Undefined;

    [Required]
    [DataType(DataType.Date)]
    public DateTime PublishDate { get; set; } = DateTime.Now;

    [Required]
    public float Price { get; set; }
    
    public Guid AuthorId { get; set; }
}