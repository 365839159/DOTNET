#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：TodoAppService
// 创 建 者：zhang xian cheng
// 创建时间：2022年05月02日 星期一 10:28
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TodoAppMongodb;

public class TodoAppService : ApplicationService, ITodoAppService
{
    private readonly IRepository<TodoItem, Guid> _todoItemRepository;

    public TodoAppService(IRepository<TodoItem, Guid> todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    [HttpGet("GetTodoItemList")]
    public async Task<List<TodoItemDto>> GetListAsync()
    {
        var items = await _todoItemRepository.GetListAsync();
        return items
            .Select(item => new TodoItemDto
            {
                Id = item.Id,
                Text = item.Text
            }).ToList();
    }

    [HttpPost("CreateTodoItem")]
    public async Task<TodoItemDto> CreateAsync(string text)
    {
        var todoItem = await _todoItemRepository.InsertAsync(
            new TodoItem {Text = text}
        );

        return new TodoItemDto
        {
            Id = todoItem.Id,
            Text = todoItem.Text
        };
    }

    [HttpDelete("DeleteTodoItem")]
    public async Task DeleteAsync(Guid id)
    {
        await _todoItemRepository.DeleteAsync(id);
    }
}