#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：AuthorAlreadyExistsException
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月03日 星期二 11:50
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using Volo.Abp;

namespace Acme.BookStore.Authors;

public class AuthorAlreadyExistsException:BusinessException
{
    public AuthorAlreadyExistsException(string name)
        : base(BookStoreDomainErrorCodes.AuthorAlreadyExists)
    {
        WithData("name", name);
    }
}