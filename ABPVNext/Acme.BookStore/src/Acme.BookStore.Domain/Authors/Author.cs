#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：Author
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月03日 星期二 11:18
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Authors;

public class Author : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
    public DateTime BirthDate { get; set; }
    public string ShortBio { get; set; }

    private Author()
    {
    }

    internal Author(
        Guid id,
        [NotNull] string name,
        DateTime birthDate,
        [CanBeNull] string shortBio)
        : base(id)
    {
        SetName(name);
        BirthDate = birthDate;
        ShortBio = shortBio;
    }

    internal Author ChangeName([NotNull] string name)
    {
        SetName(name);
        return this;
    }

    private void SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: AuthorConsts.MaxNameLength);
    }
}