#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：GetAuthorListDto
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月03日 星期二 13:14
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors;

public class GetAuthorListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}