using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace TodoAppMongodb.Pages;

[Collection(TodoAppMongodbTestConsts.CollectionDefinitionName)]
public class Index_Tests : TodoAppMongodbWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
