using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TodoAppMongodb.Data;

/* This is used if database provider does't define
 * ITodoAppMongodbDbSchemaMigrator implementation.
 */
public class NullTodoAppMongodbDbSchemaMigrator : ITodoAppMongodbDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
