#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：AuthorManager
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月03日 星期二 11:41
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Authors;

public class AuthorManager : DomainService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorManager(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<Author> CreateAsync(
        [NotNull] string name,
        DateTime birthDate,
        [CanBeNull] string shortBio = null)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingAuthor = await _authorRepository.FindByNameAsync(name);
        if (existingAuthor != null)
        {
            throw new AuthorAlreadyExistsException(name);
        }

        return new Author(
            GuidGenerator.Create(),
            name,
            birthDate,
            shortBio
        );
    }

    public async Task ChangeNameAsync(
        [NotNull] Author author,
        [NotNull] string newName)
    {
        Check.NotNull(author, nameof(author));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingAuthor = await _authorRepository.FindByNameAsync(newName);
        if (existingAuthor != null && existingAuthor.Id != author.Id)
        {
            throw new AuthorAlreadyExistsException(newName);
        }

        author.ChangeName(newName);
    }
}