using TodoAppMongodb.MongoDB;
using Xunit;

namespace TodoAppMongodb;

[CollectionDefinition(TodoAppMongodbTestConsts.CollectionDefinitionName)]
public class TodoAppMongodbDomainCollection : TodoAppMongodbMongoDbCollectionFixtureBase
{

}
