using TodoAppMongodb.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace TodoAppMongodb.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TodoAppMongodbMongoDbModule),
    typeof(TodoAppMongodbApplicationContractsModule)
    )]
public class TodoAppMongodbDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
