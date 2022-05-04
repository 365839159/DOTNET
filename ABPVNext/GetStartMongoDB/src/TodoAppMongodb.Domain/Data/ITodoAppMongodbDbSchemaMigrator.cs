using System.Threading.Tasks;

namespace TodoAppMongodb.Data;

public interface ITodoAppMongodbDbSchemaMigrator
{
    Task MigrateAsync();
}
