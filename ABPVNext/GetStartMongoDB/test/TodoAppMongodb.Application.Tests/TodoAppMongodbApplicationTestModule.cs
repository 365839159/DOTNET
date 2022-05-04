using Volo.Abp.Modularity;

namespace TodoAppMongodb;

[DependsOn(
    typeof(TodoAppMongodbApplicationModule),
    typeof(TodoAppMongodbDomainTestModule)
    )]
public class TodoAppMongodbApplicationTestModule : AbpModule
{

}
