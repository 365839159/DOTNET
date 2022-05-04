using TodoAppMongodb.MongoDB;
using Volo.Abp.Modularity;

namespace TodoAppMongodb;

[DependsOn(
    typeof(TodoAppMongodbMongoDbTestModule)
    )]
public class TodoAppMongodbDomainTestModule : AbpModule
{

}
