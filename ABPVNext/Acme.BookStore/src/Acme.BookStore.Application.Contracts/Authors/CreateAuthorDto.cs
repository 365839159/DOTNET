#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：CreateAuthorDto
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月03日 星期二 13:15
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Authors;

public class CreateAuthorDto
{
    [Required]
    [StringLength(AuthorConsts.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    public string ShortBio { get; set; }
}