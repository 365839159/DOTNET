#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：AuthorDto
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月03日 星期二 13:14
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors;

public class AuthorDto : EntityDto<Guid>
{
    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    public string ShortBio { get; set; }
}